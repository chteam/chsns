namespace MvcHelper
{
    public enum FlexigridSortOrder
    {
        [Description("asc")]
        Ascending = 0,
        [Description("desc")]
        Descending
    }




    public enum FlexigridAlign
    {
        [Description("left")]
        Left = 0,

        [Description("center")]
        Center,

        [Description("right")]
        Right
    }
    public enum FlexigridDataType
    {
        [Description("json")]
        JSON = 0,
        [Description("xml")]
        XML
    }
}