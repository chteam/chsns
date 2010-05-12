using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvcHelper
{
    public class FlexigridColumnCollection<T> : ICollection<FlexigridColumn<T>> where T : class
    {
        #region Private fields

        private readonly IList<FlexigridColumn<T>> _columns = new List<FlexigridColumn<T>>();

        #endregion

        #region Bind
        public FlexigridColumnSettings Bind(Expression<Func<T, object>> action, string title, int width, bool sortable)
        {
            return Bind(action).Title(title).Width(width).Sortable();
        }
        public FlexigridColumnSettings Bind(Expression<Func<T, object>> action, string title)
        {
            return Bind(action).Title(title);
        }
        public FlexigridColumnSettings Bind(Expression<Func<T, object>> action,string title,int width)
        {
            return Bind(action).Title(title).Width(width);
        }
        public FlexigridColumnSettings Bind(Expression<Func<T, object>> action)
        {
            var expression = RemoveUnary(action.Body) as MemberExpression;
            if (expression == null)     throw new ArgumentException("Invalid column binding");
            return Bind(expression.Member.Name);
        }
        //--
        public FlexigridColumnSettings Bind(string bindField, string title, int width, bool sortable)
        {
            return Bind(bindField).Title(title).Width(width).Sortable();
        }
        public FlexigridColumnSettings Bind(string bindField, string title)
        {
            return Bind(bindField).Title(title);
        }
        public FlexigridColumnSettings Bind(string bindField, string title, int width)
        {
            return Bind(bindField).Title(title).Width(width);
        }
        public FlexigridColumnSettings Bind(string bindField)
        {
            var column = new FlexigridColumn<T>(bindField);
            this._columns.Add(column);
            return column.ColumnSettings;
        }
        #endregion

        #region Implementation of IEnumerable

        public IEnumerator<FlexigridColumn<T>> GetEnumerator()
        {
            return this._columns.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection<FlexiGridColumn<T>>

        public void Add(FlexigridColumn<T> item)
        {
            this._columns.Add(item);
        }

        public void Clear()
        {
            this._columns.Clear();
        }

        public bool Contains(FlexigridColumn<T> item)
        {
            return this._columns.Contains(item);
        }

        public void CopyTo(FlexigridColumn<T>[] array, int arrayIndex)
        {
            this._columns.CopyTo(array, arrayIndex);
        }

        public bool Remove(FlexigridColumn<T> item)
        {
            return this._columns.Remove(item);
        }

        public int Count
        {
            get { return this._columns.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region Private methods

        private static Expression RemoveUnary(Expression body)
        {
            var uniary = body as UnaryExpression;
            if (uniary != null)
            {
                return uniary.Operand;
            }

            return body;
        }

        #endregion
    }
}
