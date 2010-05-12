namespace MvcHelper
{
    public class FlexigridColumn<T>
    {
        public FlexigridColumn(string fieldName)
        {
            this.ColumnSettings = new FlexigridColumnSettings();
            this.FieldName = fieldName;
        }

        public string FieldName { get; private set; }

        public FlexigridColumnSettings ColumnSettings { get; private set; }
    }
}
