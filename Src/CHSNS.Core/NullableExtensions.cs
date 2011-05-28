using System;

namespace CHSNS {
	public static class NullableExtensions {
        public static TResult GetProperty<T, TResult>(this T obj, Func<T, TResult> func) where T : class
        {
            if (obj != null) return func(obj);
            return default(TResult);
        }

	}
}
