using System;

namespace MvcHelper
{
    public class FlexigridColumnSettings
    {
        #region Private fields

        private int _width;

        private string _title;

        private bool _sortable;

        private FlexigridAlign _align;
        bool _hide;
        #endregion

        #region Public Properties

        internal FlexigridAlign ColumnAlignment
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

        public FlexigridColumnSettings Width(int width)
        {
            this._width = width;
            return this;
        }

        public FlexigridColumnSettings Title(string title)
        {
            this._title = title;
            return this;
        }

        public FlexigridColumnSettings Sortable()
        {
            this.Sortable(true);
            return this;
        }

        public FlexigridColumnSettings Sortable(bool sortable)
        {
            this._sortable = sortable;
            return this;
        }

        public FlexigridColumnSettings Align(FlexigridAlign align)
        {
            this._align = align;
            return this;
        }
        public FlexigridColumnSettings Hide()
        {
            this._hide = true;
            return this;
        }
        #endregion

  
    }
}
