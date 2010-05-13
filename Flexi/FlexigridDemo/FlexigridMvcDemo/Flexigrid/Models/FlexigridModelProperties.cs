﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvcHelper
{
    public class FlexigridModelProperties<T> where T : class
    {
        private readonly IList<Func<T, object>> _propertyCollection = new List<Func<T, object>>();

        internal IList<Func<T, object>> ProperyItem
        {
            get
            {
                return _propertyCollection;
            }
        }

        public FlexigridModelProperties<T> Add(Expression<Func<T, object>> item)
        {
            ProperyItem.Add(item.Compile());
            return this;
        }
    }
}