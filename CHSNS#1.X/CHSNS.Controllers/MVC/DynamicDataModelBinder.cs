using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace CHSNS.Mvc {
    // REVIEW: This code makes a lot of assumptions about the shape of objects (LINQ to SQL style).
    // Eventually will replace this with a more generic version.
    [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public class DynamicDataModelBinder : IModelBinder {
        readonly IModelBinder defaultBinder;

        public DynamicDataModelBinder(IModelBinder defaultBinder) {
            this.defaultBinder = defaultBinder;
        }

        public ModelBinderResult BindModel(ModelBindingContext context) {
            MetaTable table;

            try {
                // REVIEW: Why is there no TryGetTable based on the entity type?
                table = MetaModel.Default.GetTable(context.ModelType);
            }
            catch (ArgumentException) {
                return defaultBinder.BindModel(context);
            }

            // REVIEW: Why doesn't context.Model create a new object for us?
            object entity = context.Model ?? Activator.CreateInstance(context.ModelType);
            Hashtable hash = GetEntityHashValues(context, table);

            foreach (string columnName in hash.Keys)
                ValidateAndSetValue(context, table, hash, columnName, entity);

            return new ModelBinderResult(entity);
        }

        static Hashtable GetEntityHashValues(ModelBindingContext context, MetaTable table) {
            // Try binding against the direct value, it might already be a full hash
            // (i.e., an "original" object that we serialized).
            Hashtable hash = GetObjectHash(context, context.ModelName);

            if (hash == null) {
                // If we're pulling values from the field, start with a hash filled with
                // values from the original, if it's in the form data (in edit scenarios)
                hash = GetObjectHash(context, "Original" + context.ModelName) ?? new Hashtable();

                // Supplement the hash with values from the form, when they're present
                foreach (var column in table.Columns.Where(c => c.IsSerialized())) {
                    ValueProviderResult vpr = context.ValueProvider.GetValue(GetFieldName(context, column.Name));
                    if (vpr != null)
                        hash[column.Name] = vpr.AttemptedValue;
                }
            }

            return hash;
        }

        static string GetFieldName(ModelBindingContext context, string columnName) {
            return context.ModelName + "." + columnName;
        }

        static Hashtable GetObjectHash(ModelBindingContext context, string fieldName) {
            ValueProviderResult vpr = context.ValueProvider.GetValue(fieldName);

            if (vpr != null && !String.IsNullOrEmpty(vpr.AttemptedValue))
                return HtmlSerializer.Deserialize(vpr.AttemptedValue);

            return null;
        }

        static void SetForeignKeyValue(MetaForeignKeyColumn fkColumn, object entity, object propValue) {
            var props = TypeDescriptor.GetProperties(entity);
            Hashtable fkValues = new Hashtable();
            fkColumn.ExtractForeignKey(fkValues, propValue.ToString());

            foreach (string fkPropName in fkValues.Keys) {
                PropertyDescriptor property = props[fkPropName];
                object value = TypeDescriptor.GetConverter(property.PropertyType).ConvertFrom(fkValues[fkPropName]);
                property.SetValue(entity, value);
            }
        }

        static void SetValue(ModelBindingContext context, MetaColumn column, object entity, object propValue, string fieldName) {
            if (!column.EntityTypeProperty.CanWrite)
                return;

            if (propValue != null) {
                if (propValue.GetType() != column.ColumnType)
                    propValue = TypeDescriptor.GetConverter(column.ColumnType).ConvertFrom(propValue);

                foreach (var validationAttribute in column.Attributes.OfType<ValidationAttribute>())
                    if (!validationAttribute.IsValid(propValue))
                        context.ModelState.AddModelError(fieldName, validationAttribute.FormatErrorMessage(column.Name));
            }

            column.EntityTypeProperty.SetValue(entity, propValue, null);
        }

        static void ValidateAndSetValue(ModelBindingContext context, MetaTable table, IDictionary hash, string columnName, object entity) {
            MetaColumn column = table.GetColumn(columnName);
            object propValue = hash[columnName];
            string fieldName = GetFieldName(context, columnName);

            context.ModelState.SetAttemptedValue(fieldName, propValue.ToString());

            if (propValue as string == String.Empty && column.ConvertEmptyStringToNull)
                propValue = null;

            if (propValue == null && column.IsRequired) {
                string error = column.RequiredErrorMessage;
                if (String.IsNullOrEmpty(error))
                    error = String.Format("The field '{0}' is required", column.Name); // TODO: Resource

                context.ModelState.AddModelError(fieldName, error);
                return;
            }

            try {
                var fkColumn = column as MetaForeignKeyColumn;

                if (fkColumn != null)
                    SetForeignKeyValue(fkColumn, entity, propValue);
                else
                    SetValue(context, column, entity, propValue, fieldName);
            }
            catch (TargetInvocationException e) {
                context.ModelState.AddModelError(fieldName, e.InnerException.Message);
            }
            catch (Exception e) {
                context.ModelState.AddModelError(fieldName, e.Message);
            }
        }
    }
}