namespace MvcHelper
{
    public class FlexiGridColumn<T>
    {
        #region Private fields

        private string _fieldName;

        private FlexiGridColumnSettings _colSettings;

        #endregion

        #region Constructor

        public FlexiGridColumn(string fieldName)
        {
            this._colSettings = new FlexiGridColumnSettings();
            this._fieldName = fieldName;
        }

        #endregion

        #region Properties

        public string FieldName
        {
            get { return this._fieldName; }
        }

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
