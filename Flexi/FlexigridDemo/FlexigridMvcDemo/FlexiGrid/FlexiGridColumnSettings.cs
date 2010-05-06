using System;

namespace MvcHelper
{
    /// <summary>
    /// FlexiGrid columns settings.
    /// </summary>
    public class FlexiGridColumnSettings
    {
        #region Private fields

        /// <summary>
        /// Width of the column.
        /// </summary>
        private int _width;

        /// <summary>
        /// Title of the column.
        /// </summary>
        private string _title;

        /// <summary>
        /// Column sorting option.
        /// </summary>
        private bool _sortable;

        /// <summary>
        /// Text align option.
        /// </summary>
        private FlexiGridAlign _align;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the column alignment.
        /// </summary>
        /// <value>The column alignment.</value>
        public FlexiGridAlign ColumnAlignment
        {
            get { return this._align; }
        }

        /// <summary>
        /// Gets a value indicating whether [column sortable].
        /// </summary>
        /// <value><c>true</c> if column is sortable; otherwise, <c>false</c>.</value>
        public bool ColumnSortable
        {
            get { return this._sortable; }
        }

        /// <summary>
        /// Gets the column title.
        /// </summary>
        /// <value>The column title.</value>
        public string ColumnTitle
        {
            get { return this._title; }
        }

        /// <summary>
        /// Gets the width of the column.
        /// </summary>
        /// <value>The width of the column.</value>
        public int ColumnWidth
        {
            get { return this._width; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the width of the column.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns>Instance of <see cref="FlexiGridColumnSettings"/></returns>
        public FlexiGridColumnSettings Width(int width)
        {
            this._width = width;
            return this;
        }

        /// <summary>
        /// Set the Title of the column.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>Instance of <see cref="FlexiGridColumnSettings"/></returns>
        public FlexiGridColumnSettings Title(string title)
        {
            this._title = title;
            return this;
        }

        /// <summary>
        /// Sets whether the column is sortable or not.
        /// </summary>
        /// <returns>Instance of <see cref="FlexiGridColumnSettings"/></returns>
        public FlexiGridColumnSettings Sortable()
        {
            this.Sortable(true);
            return this;
        }

        /// <summary>
        /// Sets whether the column is sortable or not.
        /// </summary>
        /// <param name="sortable">if set to <c>true</c> [sortable].</param>
        /// <returns>Instance of <see cref="FlexiGridColumnSettings"/></returns>
        public FlexiGridColumnSettings Sortable(bool sortable)
        {
            this._sortable = sortable;
            return this;
        }

        /// <summary>
        /// Sets the text alignment of the column.
        /// </summary>
        /// <param name="align">The align.</param>
        /// <returns>Instance of <see cref="FlexiGridColumnSettings"/></returns>
        public FlexiGridColumnSettings Align(FlexiGridAlign align)
        {
            this._align = align;
            return this;
        } 

        #endregion
    }
}
