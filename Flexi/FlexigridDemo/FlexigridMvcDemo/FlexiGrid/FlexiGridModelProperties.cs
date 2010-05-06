using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvcHelper
{
    /// <summary>
    /// Class that represents the properties that are part of the FlexiGrid Model.
    /// </summary>
    /// <typeparam name="T">Model Type</typeparam>
    public class FlexiGridModelProperties<T> where T : class
    {
        #region Private field

        /// <summary>
        /// Variable that holds the property items.
        /// </summary>
        private readonly IList<Func<T, object>> _propertyCollection = new List<Func<T, object>>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the propery item.
        /// </summary>
        /// <value>The propery item.</value>
        internal IList<Func<T, object>> ProperyItem
        {
            get
            {
                return this._propertyCollection;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The property item.</param>
        public void Add(Expression<Func<T, object>> item)
        {
            this.ProperyItem.Add(item.Compile());
        }

        #endregion
    }
}
