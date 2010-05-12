using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace MvcHelper
{
    public class FlexgridData<T> where T : class
    {
        #region Private fields

        private readonly IEnumerable<T> _data;

        private readonly int _page;

        private readonly int _total;

        private IList<FlexGridRowData> _rows;

        #endregion

        #region Constructor

        public FlexgridData(IEnumerable<T> data, int page, int total, Expression<Func<T, object>> identifier, Action<FlexiGridModelProperties<T>> properties)
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

        public FlexgridData(IEnumerable<T> data, int page, int total)
            : this(data, page, total, true)
        {
        }

        protected FlexgridData(IEnumerable<T> data, int page, int total, bool initializeRows)
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

        public int page
        {
            get
            {
                return this._page;
            }
        }

        public int total
        {
            get
            { 
                return this._total;
            }
        }

        public IList<FlexGridRowData> rows
        {
            get
            {
                return this._rows;
            }
        }
    }
}