using System.Collections.Generic;
using System.Data.Entity;

namespace CHSNS
{
    public static class DbSetExtensions
    {
        public static void BulkRemove<T>(this IDbSet<T> set, IEnumerable<T> items) where T : class
        {
            foreach (T item in items.ToNotNull())
            {
                set.Remove(item);
            }
        }
    }
}