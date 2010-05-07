using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvcHelper
{
    public class FlexiGridModelProperties<T> where T : class
    {
        #region Private field

        private readonly IList<Func<T, object>> _propertyCollection = new List<Func<T, object>>();

        #endregion

        #region Properties

        internal IList<Func<T, object>> ProperyItem
        {
            get
            {
                return this._propertyCollection;
            }
        }

        #endregion

        #region Public Methods

        public void Add(Expression<Func<T, object>> item)
        {
            this.ProperyItem.Add(item.Compile());
        }

        #endregion
    }
}
