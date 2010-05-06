using System;
//using MVCControl.JQuery.Plugins.Core;

namespace MvcHelper
{
    /// <summary>
    /// Generic class that represents settings for a FlexiGrid.
    /// </summary>
    /// <typeparam name="T" >Model type</typeparam>
    public class FlexiGridSettings<T> where T : class 
    {
        #region Private Fields

        /// <summary>
        /// Variable that holds the columns.
        /// </summary>
        private readonly FlexiGridColumnCollection<T> _columns;

        /// <summary>
        /// Variable that holds the id of the Html table element.
        /// </summary>
        private string _gridId;

        /// <summary>
        /// Variable that holds the url from the which the grid populates data.
        /// </summary>
        private string _actionUrl;

        /// <summary>
        /// Variable that holds the data type in which Grid is expecting the data.
        /// </summary>
        private FlexiGridDataType _dataType;

        /// <summary>
        /// Variable that holds title of the Grid.
        /// </summary>
        private string _title;

        /// <summary>
        /// Variable that decides whether records per page is enabled or not.
        /// </summary>
        private bool _enableRecordsPerPage = false;

        /// <summary>
        /// Variable that holds, no:of records in a page.
        /// </summary>
        private int _recordsPerPage;

        /// <summary>
        /// Variable that decides whether to show the Table toggle button.
        /// </summary>
        private bool _enableTableToggleButton = false;

        /// <summary>
        /// Variable that decides whether to show Pager or not.
        /// </summary>
        private bool _enablePager;

        /// <summary>
        /// Variable that holds the name of default sort field.
        /// </summary>
        private string _defaultSortField;

        /// <summary>
        /// Variable that holds the default sort order.
        /// </summary>
        private FlexiGridSortOrder _defaultSortOrder;

        /// <summary>
        /// Variable that holds width of the Grid.
        /// </summary>
        private int _width;

        /// <summary>
        /// Variable that holds height of the Grid.
        /// </summary>
        private int _height;

        /// <summary>
        /// Variable that holds the instance of FlexiGridRenderer.
        /// </summary>
        private IGridRenderer<FlexiGridSettings<T>> _renderer;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FlexiGridSettings&lt;T&gt;"/> class.
        /// </summary>
        public FlexiGridSettings()
        {
            this._columns = new FlexiGridColumnCollection<T>();
            this._renderer = new FlexiGridRenderer<T>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the height of the grid.
        /// </summary>
        /// <value>The height of the grid.</value>
        public int GridHeight
        {
            get { return this._height; }
        }

        /// <summary>
        /// Gets the width of the grid.
        /// </summary>
        /// <value>The width of the gird.</value>
        public int GridWidth
        {
            get { return this._width; }
        }

        /// <summary>
        /// Gets the default sort order.
        /// </summary>
        /// <value>The default sort order.</value>
        public FlexiGridSortOrder DefaultSortOrder
        {
            get { return this._defaultSortOrder; }
        }

        /// <summary>
        /// Gets the default sort field.
        /// </summary>
        /// <value>The default sort field.</value>
        public string DefaultSortField
        {
            get { return this._defaultSortField; }
        }

        /// <summary>
        /// Gets a value indicating whether [enable pager].
        /// </summary>
        /// <value><c>true</c> if [enable pager]; otherwise, <c>false</c>.</value>
        public bool EnablePager
        {
            get { return this._enablePager; }
        }

        /// <summary>
        /// Gets a value indicating whether [enable table toggle button].
        /// </summary>
        /// <value><c>true</c> if [enable table toggle button]; otherwise, <c>false</c>.</value>
        public bool EnableTableToggleButton
        {
            get { return this._enableTableToggleButton; }
        }

        /// <summary>
        /// Gets the records per page.
        /// </summary>
        /// <value>The records per page.</value>
        public int RecordsPerPage
        {
            get { return this._recordsPerPage; }
        }

        /// <summary>
        /// Gets a value indicating whether [enable records per page].
        /// </summary>
        /// <value><c>true</c> if [enable records per page]; otherwise, <c>false</c>.</value>
        public bool EnableRecordsPerPage
        {
            get { return this._enableRecordsPerPage; }
        }

        /// <summary>
        /// Gets the grid title.
        /// </summary>
        /// <value>The grid title.</value>
        public string GridTitle
        {
            get { return this._title; }
        }

        /// <summary>
        /// Gets the type of the grid data.
        /// </summary>
        /// <value>The type of the grid data.</value>
        public FlexiGridDataType GridDataType
        {
            get { return this._dataType; }
        }

        /// <summary>
        /// Gets the action URL.
        /// </summary>
        /// <value>The action URL.</value>
        public string ActionUrl
        {
            get { return this._actionUrl; }
        }

        /// <summary>
        /// Gets the grid id.
        /// </summary>
        /// <value>The grid id.</value>
        public string GridId
        {
            get { return this._gridId; }
        }

        /// <summary>
        /// Gets the grid columns.
        /// </summary>
        /// <value>The gri columns.</value>
        public FlexiGridColumnCollection<T> GridColumns
        {
            get { return this._columns; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the id of the HTML table element.
        /// </summary>
        /// <param name="elementId">The element id.</param>
        /// <returns>Instance of FlexiGridSettings</returns>
        public FlexiGridSettings<T> Name(string elementId)
        {
            this._gridId = elementId;
            return this;
        }

        /// <summary>
        /// Set the action url from which the Grid populated data.
        /// </summary>
        /// <param name="actionUrl">The action URL.</param>
        /// <returns>Instance of FlexiGridSettings</returns>
        public FlexiGridSettings<T> UpdateAction(string actionUrl)
        {
            this._actionUrl = actionUrl;
            return this;
        }

        /// <summary>
        /// Set the data type in which Grid is expecting the data.
        /// </summary>
        /// <param name="dataType">Type of the data.</param>
        /// <returns>Instance of FlexiGridSettings</returns>
        public FlexiGridSettings<T> DataType(FlexiGridDataType dataType)
        {
            this._dataType = dataType;
            return this;
        }

        /// <summary>
        /// Set the title of the Grid.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>Instance of FlexiGridSettings</returns>
        public FlexiGridSettings<T> Title(string title)
        {
            this._title = title;
            return this;
        }

        /// <summary>
        /// Sets the recordses per page option.
        /// </summary>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        /// <param name="numberOfRecordsPerPage">The number of records per page.</param>
        /// <returns>Instance of FlexiGridSettings</returns>
        public FlexiGridSettings<T> RecordsPerPageOption(bool enable, int numberOfRecordsPerPage)
        {
            this._enableRecordsPerPage = enable;
            this._recordsPerPage = numberOfRecordsPerPage;
            return this;
        }

        /// <summary>
        /// Sets show table toggle button option.
        /// </summary>
        /// <param name="show">if set to <c>true</c> [show].</param>
        /// <returns>Instance of FlexiGridSettings</returns>
        public FlexiGridSettings<T> ShowTableToggleButton(bool show)
        {
            this._enableTableToggleButton = show;
            return this;
        }

        /// <summary>
        /// Sets the pager option.
        /// </summary>
        /// <returns>Instance of FlexiGridSettings</returns>
        public FlexiGridSettings<T> UsePager()
        {
            this._enablePager = true;
            return this;
        }

        /// <summary>
        /// Set the defaults the sort option.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="order">The sort order.</param>
        /// <returns>Instance of FlexiGridSettings</returns>
        public FlexiGridSettings<T> DefaultSortOption(string fieldName, FlexiGridSortOrder order)
        {
            this._defaultSortField = fieldName;
            this._defaultSortOrder = order;
            return this;
        }



        /// <summary>
        /// Sets the columns and it's settings for this Grid.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>Instance of FlexiGridSettings</returns>
        public FlexiGridSettings<T> Columns(Action<FlexiGridColumnCollection<T>> action)
        {
            action(this._columns);
            return this;
        }

        /// <summary>
        /// Sets the width of the Grid.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns>Instance of FlexiGridSettings</returns>
        public FlexiGridSettings<T> Width(int width)
        {
            this._width = width;
            return this;
        }

        /// <summary>
        /// Sets the height of the Grid.
        /// </summary>
        /// <param name="height">The height.</param>
        /// <returns>Instance of FlexiGridSettings</returns>
        public FlexiGridSettings<T> Height(int height)
        {
            this._height = height;
            return this;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this._renderer.Render(this);
        }

        #endregion
    }
}
