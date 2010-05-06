using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace MvcHelper
{
    /// <summary>
    /// Class that represents the actual data requried for the FlexiGrid.
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
         Justification =
             "FlexiGrid pass data in lower case JSON format; so in order for the deserialization to work properly we need to give a lower case property name.")]
    public class FlexGridData<T> where T : class
    {
        #region Private fields

        /// <summary>
        /// Variable that holds actual data that is passed by the action method.
        /// </summary>
        private readonly IEnumerable<T> _data;

        /// <summary>
        /// Variable that holds the current page index.
        /// </summary>
        private readonly int _page;

        /// <summary>
        /// Variable that holds the total record count.
        /// </summary>
        private readonly int _total;

        /// <summary>
        /// Variable that holds the collection of FlexiGrid rows.
        /// </summary>
        private IList<FlexGridRowData> _rows;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FlexGridData&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="data">Actual data that needs to be converted to FlexiGrid data.</param>
        /// <param name="page">Current page index.</param>
        /// <param name="total">Total number of records.</param>
        /// <param name="identifier">The identity property.</param>
        /// <param name="properties">Properties that are going to part of this data.</param>
        public FlexGridData(IEnumerable<T> data, int page, int total, Expression<Func<T, object>> identifier, Action<FlexiGridModelProperties<T>> properties)
            : this(data, page, total, false)
        {
            this._rows = new List<FlexGridRowData>();

            // Get the identity delagate
            Func<T, object> identityDelegate = identifier.Compile();

            // Get the properties collection
            var dataCollection = new FlexiGridModelProperties<T>();

            properties.Invoke(dataCollection);

            foreach (T item in data)
            {
                IList<string> rowData = new List<string>();

                // Create  the data list.
                foreach (var properyItem in dataCollection.ProperyItem)
                {
                    rowData.Add(properyItem(item).ToString());
                }

                this._rows.Add(new FlexGridRowData(identityDelegate(item).ToString(), rowData));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlexGridData&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="data">Actual data that needs to be converted to FlexiGrid data.</param>
        /// <param name="page">Current page index.</param>
        /// <param name="total">Total number of records.</param>
        public FlexGridData(IEnumerable<T> data, int page, int total)
            : this(data, page, total, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlexGridData&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="data">Actual data that needs to be converted to FlexiGrid data.</param>
        /// <param name="page">Current page index.</param>
        /// <param name="total">Total number of records.</param>
        /// <param name="initializeRows">if set to <c>true</c> [initialize rows].</param>
        protected FlexGridData(IEnumerable<T> data, int page, int total, bool initializeRows)
        {
            this._data = data;
            this._page = page;
            this._total = total;

            if (initializeRows)
            {
                this._rows = new List<FlexGridRowData>();

                PropertyInfo[] propertyInfos = typeof(T).GetProperties();

                foreach (T item in data)
                {
                    string id = string.Empty;
                    IList<string> cells = new List<string>();

                    foreach (PropertyInfo info in propertyInfos)
                    {
                        cells.Add(info.GetValue(item, null).ToString());
                        if (id.Length == 0)
                        {
                            id = cells[0];
                        }
                    }

                    this._rows.Add(new FlexGridRowData(id, cells));
                }
            }
        }

        #endregion

        /// <summary>
        /// Gets the current page.
        /// </summary>
        /// <value>Current page.</value>
        public int page
        {
            get
            {
                return this._page;
            }
        }

        /// <summary>
        /// Gets the total number of records.
        /// </summary>
        /// <value>Total record count.</value>
        public int total
        {
            get
            {
                return this._total;
            }
        }

        /// <summary>
        /// Gets the actual rows.
        /// </summary>
        /// <value>Actual rows.</value>
        public IList<FlexGridRowData> rows
        {
            get
            {
                return this._rows;
            }
        }
    }
}
