using System;
using System.Collections;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;

namespace CHSNS.Mvc {
    // REVIEW: In theory, this should be the responsibility of the agnostic serializer that we will
    // need after we convert DynamicDataModelBinder to be DAL-agnostic.
    [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public static class HtmlSerializer {
        public static Hashtable Deserialize(string serialization) {
            try {
                return (Hashtable)(new ObjectStateFormatter().Deserialize(serialization));
            }
            catch (Exception) {
                return null;
            }
        }

        public static string Serialize(MetaTable table, object entity) {
            Hashtable values = new Hashtable();

            foreach (var column in table.Columns.Where(c => c.IsSerialized())) {
                var fkColumn = column as MetaForeignKeyColumn;
                object fieldValue = DataBinder.Eval(entity, column.Name);

                if (fkColumn != null)
                    values.Add(column.Name, fkColumn.GetForeignKeyString(entity));
                else if (fieldValue != null)
                    values.Add(column.Name, fieldValue);
            }

            return new ObjectStateFormatter().Serialize(values);
        }
    }
}