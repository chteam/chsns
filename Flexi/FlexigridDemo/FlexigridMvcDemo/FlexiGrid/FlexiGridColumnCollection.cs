using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvcHelper
{
    /// <summary>
    /// Class that represesnts a collection of columns.
    /// </summary>
    /// <typeparam name="T">Model type.</typeparam>
    public class FlexiGridColumnCollection<T> : ICollection<FlexiGridColumn<T>> where T : class
    {
        #region Private fields

        /// <summary>
        /// Columns collection.
        /// </summary>
        private readonly IList<FlexiGridColumn<T>> _columns = new List<FlexiGridColumn<T>>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Bounds a Model property to a field.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>Instance of <see cref="FlexiGridColumnSettings"/></returns>
        public FlexiGridColumnSettings Bind(Expression<Func<T, object>> action)
        {
            var expression = RemoveUnary(action.Body) as MemberExpression;

            if (expression == null)
            {
                throw new ArgumentException("Invalid column binding");
            }

            var column = new FlexiGridColumn<T>(expression.Member.Name);

            this._columns.Add(column);

            return column.ColumnSettings;
        }

        #endregion

        #region Implementation of IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<FlexiGridColumn<T>> GetEnumerator()
        {
            return this._columns.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection<FlexiGridColumn<T>>

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
        public void Add(FlexiGridColumn<T> item)
        {
            this._columns.Add(item);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
        public void Clear()
        {
            this._columns.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
        /// </summary>
        /// <returns>true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.</returns>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        public bool Contains(FlexiGridColumn<T> item)
        {
            return this._columns.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied 
        /// from <see cref="T:System.Collections.Generic.ICollection`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="array"/> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="array"/> is multidimensional.
        /// -or-
        /// <paramref name="arrayIndex"/> is equal to or greater than the length of <paramref name="array"/>.
        /// -or-
        /// The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1"/> is greater than the available space from 
        /// <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.
        /// -or-
        /// Type <paramref name="T"/> cannot be cast automatically to the type of the destination <paramref name="array"/>.</exception>
        public void CopyTo(FlexiGridColumn<T>[] array, int arrayIndex)
        {
            this._columns.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>true if <paramref name="item"/> 
        /// was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if <paramref name="item"/> 
        /// is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.</returns>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
        public bool Remove(FlexiGridColumn<T> item)
        {
            return this._columns.Remove(item);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</returns>
        public int Count
        {
            get { return this._columns.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
        /// </returns>
        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Removes the unary.
        /// </summary>
        /// <param name="body">The body of the expression.</param>
        /// <returns>Instnce of <see cref="Expression"/></returns>
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
