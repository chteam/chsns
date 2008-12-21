using System.Web.DynamicData;

static class MetaColumnExtensions {
    public static bool IsSerialized(this MetaColumn column) {
        return !(column.IsForeignKeyComponent || column is MetaChildrenColumn);
    }
}