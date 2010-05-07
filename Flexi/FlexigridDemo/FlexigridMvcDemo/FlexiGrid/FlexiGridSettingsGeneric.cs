﻿using System;
//using MVCControl.JQuery.Plugins.Core;

namespace MvcHelper
{
    public class FlexiGridSettings<T> where T : class
    {
        #region Private Fields

        private readonly FlexiGridColumnCollection<T> _columns;

        private string _gridId;

        private string _actionUrl;

        private FlexiGridDataType _dataType;

        private string _title;

        bool _autoLoad;

        private int _pageSize;

        private bool _enableTableToggleButton = false;

        private bool _enableDefaultPager;

        string _pagerFilter;

        private string _defaultSortField;

        private FlexiGridSortOrder _defaultSortOrder;

        private int _width;

        private int _height;

        private IGridRenderer<FlexiGridSettings<T>> _renderer;

        #endregion

        #region Constructor

        public FlexiGridSettings()
        {
            this._columns = new FlexiGridColumnCollection<T>();
            this._renderer = new FlexiGridRenderer<T>();
        }

        #endregion

        #region Public Properties

        public int GridHeight
        {
            get { return this._height; }
        }

        public int GridWidth
        {
            get { return this._width; }
        }

        public FlexiGridSortOrder DefaultSortOrder
        {
            get { return this._defaultSortOrder; }
        }

        public string DefaultSortField
        {
            get { return this._defaultSortField; }
        }

        public string PageFilter { get { return _pagerFilter; } }
        public bool EnableDefaultPager
        {
            get { return this._enableDefaultPager; }
        }


        public bool EnableTableToggleButton
        {
            get { return this._enableTableToggleButton; }
        }

        public int PageSize
        {
            get { return this._pageSize; }
        }



        public string GridTitle
        {
            get { return this._title; }
        }

        public FlexiGridDataType GridDataType
        {
            get { return this._dataType; }
        }

        public string ActionUrl
        {
            get { return this._actionUrl; }
        }

        public string GridId
        {
            get { return this._gridId; }
        }
        public bool EnableAutoLoad { get { return _autoLoad; } }
        public FlexiGridColumnCollection<T> GridColumns
        {
            get { return this._columns; }
        }

        #endregion

        #region Public Methods

        public FlexiGridSettings<T> TableId(string elementId)
        {
            this._gridId = elementId;
            return this;
        }

        public FlexiGridSettings<T> Action(string actionUrl)
        {
            this._actionUrl = actionUrl;
            return this;
        }

        public FlexiGridSettings<T> DataType(FlexiGridDataType dataType)
        {
            this._dataType = dataType;
            return this;
        }
         /// <summary>
         /// 设置FlexiGrid标题
         /// </summary>
         /// <param name="title"></param>
         /// <returns></returns>
        public FlexiGridSettings<T> Title(string title)
        {
            this._title = title;
            return this;
        }
        /// <summary>
        /// 允许自动加载
        /// </summary>
        /// <returns></returns>
        public FlexiGridSettings<T> AutoLoad()
        {
            this._autoLoad = true;
            return this;
        }
        /// <summary>
        /// 设置每页容纳条数
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public FlexiGridSettings<T> SetPageSize(int pageSize)
        {
            this._pageSize = pageSize;
            return this;
        }


        //public FlexiGridSettings<T> ShowTableToggleButton(bool show)
        //{
        //    this._enableTableToggleButton = show;
        //    return this;
        //}
        /// <summary>
        /// 设置为默认分页
        /// </summary>
        /// <returns></returns>
        public FlexiGridSettings<T> SetPager()
        {
            this._enableDefaultPager = true;
            return this;
        }
        /// <summary>
        /// 设置可分页并设定指定的分页元素
        /// </summary>
        /// <param name="pagerFilter">分页Div的Class或Id，支持.class或#Id</param>
        /// <returns></returns>
        public FlexiGridSettings<T> SetPager(string pagerFilter)
        {
            this._enableDefaultPager = false;
            this._pagerFilter = pagerFilter;
            return this;
        }
        public FlexiGridSettings<T> DefaultSortOption(string fieldName, FlexiGridSortOrder order)
        {
            this._defaultSortField = fieldName;
            this._defaultSortOrder = order;
            return this;
        }


        /// <summary>
        /// 设置列表的列项
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public FlexiGridSettings<T> Columns(Action<FlexiGridColumnCollection<T>> action)
        {
            action(this._columns);
            return this;
        }

        public FlexiGridSettings<T> Width(int width)
        {
            this._width = width;
            return this;
        }

        public FlexiGridSettings<T> Height(int height)
        {
            this._height = height;
            return this;
        }

        public override string ToString()
        {
            return this._renderer.Render(this);
        }

        #endregion
        bool _colMove;
        /// <summary>
        /// 设置可移动列
        /// </summary>
        public bool ColMove { get { return _colMove; } }
        /// <summary>
        /// 设置可移动列
        /// </summary>
        public FlexiGridSettings<T>  ColumnsMove()
        {
            _colMove=true;
            return this;
        }
        /// <summary>
        /// 设置列可自定义大小 
        /// </summary>
        public bool ColResize { get { return _colResize; } }

         bool _colResize { get; set; }
        /// <summary>
        /// 设置列可自定义大小 
        /// </summary>
        /// <returns></returns>
        public FlexiGridSettings<T> ColumnsResize()
        {
            _colResize = true;
            return this;
        }

        string _menuId = null;
        public string MenuId { get { return _menuId; } }
        string _menuProcess = null;
        public string MenuProcess { get { return _menuProcess; } }
        public FlexiGridSettings<T> ContextMenu(string menuId, string process)
        {
            _menuId = menuId;
            _menuProcess = process;
            return this;
        }

    }
}