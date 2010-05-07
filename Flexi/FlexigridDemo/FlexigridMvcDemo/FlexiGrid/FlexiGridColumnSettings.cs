using System;

namespace MvcHelper
{
    public class FlexiGridColumnSettings
    {
        #region Private fields

        private int _width;

        private string _title;

        private bool _sortable;

        private FlexiGridAlign _align;
        bool _hide;
        #endregion

        #region Public Properties

        internal FlexiGridAlign ColumnAlignment
        {
            get { return this._align; }
        }

        internal bool ColumnSortable
        {
            get { return this._sortable; }
        }

        internal string ColumnTitle
        {
            get { return this._title; }
        }

        internal int ColumnWidth
        {
            get { return this._width; }
        }
        internal bool ColumnHidden { get { return _hide; } }
        #endregion

        #region Public Methods

        public FlexiGridColumnSettings Width(int width)
        {
            this._width = width;
            return this;
        }

        public FlexiGridColumnSettings Title(string title)
        {
            this._title = title;
            return this;
        }

        public FlexiGridColumnSettings Sortable()
        {
            this.Sortable(true);
            return this;
        }

        public FlexiGridColumnSettings Sortable(bool sortable)
        {
            this._sortable = sortable;
            return this;
        }

        public FlexiGridColumnSettings Align(FlexiGridAlign align)
        {
            this._align = align;
            return this;
        }
        public FlexiGridColumnSettings Hide()
        {
            this._hide = true;
            return this;
        }
        #endregion

  
    }
}
