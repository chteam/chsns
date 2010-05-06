namespace MvcHelper
{
    /// <summary>
    /// Specifies the Sort order for the Grid.
    /// </summary>
    public enum FlexiGridSortOrder
    {
        /// <summary>
        /// Ascending Order.
        /// </summary>
        [Description("asc")]
        Ascending = 0,

        /// <summary>
        /// Descending Order.
        /// </summary>
        [Description("desc")]
        Descending
    }

    /// <summary>
    /// Specifies the Text Alignment
    /// </summary>
    public enum FlexiGridAlign
    {
        /// <summary>
        /// Left Align.
        /// </summary>
        [Description("left")]
        Left = 0,

        /// <summary>
        /// Centre Align.
        /// </summary>
        [Description("centre")]
        Centre,

        /// <summary>
        /// Right Align.
        /// </summary>
        [Description("right")]
        Right
    }

    /// <summary>
    /// Specifies the Data Type.
    /// </summary>
    public enum FlexiGridDataType
    {
        /// <summary>
        /// JSON data type.
        /// </summary>
        [Description("json")]
        JSON = 0,

        /// <summary>
        /// XML Data type
        /// </summary>
        [Description("xml")]
        XML
    }
}