namespace CHSNS
{
    using System.Collections.Generic;

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ToNotNull<T>(this IEnumerable<T> items)
        {
            return items ?? new List<T>();
        }
    }
}