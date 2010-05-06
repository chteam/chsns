namespace MvcHelper
{
    /// <summary>
    /// Class that represents a FlexiGrid column.
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    public class FlexiGridColumn<T>
    {
        #region Private fields

        /// <summary>
        /// Name of the field.
        /// </summary>
        private string _fieldName;

        /// <summary>
        /// Instance of column settings.
        /// </summary>
        private FlexiGridColumnSettings _colSettings;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FlexiGridColumn&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        public FlexiGridColumn(string fieldName)
        {
            this._colSettings = new FlexiGridColumnSettings();
            this._fieldName = fieldName;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        /// <value>The name of the field.</value>
        public string FieldName
        {
            get { return this._fieldName; }
        }

        /// <summary>
        /// Gets the column settings.
        /// </summary>
        /// <value>The column settings.</value>
        public FlexiGridColumnSettings ColumnSettings
        {
            get
            {
                return this._colSettings;
            }
        }

        #endregion
    }
}
