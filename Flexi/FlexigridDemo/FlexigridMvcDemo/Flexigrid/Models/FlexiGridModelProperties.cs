using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvcHelper
{
    public class FlexiGridModelProperties<T> where T : class
    {
        private readonly IList<Func<T, object>> _propertyCollection = new List<Func<T, object>>();

        internal IList<Func<T, object>> ProperyItem
        {
            get
            {
                return this._propertyCollection;
            }
        }

        public FlexiGridModelProperties<T> Add(Expression<Func<T, object>> item)
        {
            this.ProperyItem.Add(item.Compile());
            return this;
        }
    }
}
