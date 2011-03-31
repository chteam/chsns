using System;

namespace CHSNS {
	public static class NullableExtensions {
        public static TResult Get<T, TResult>(this T n, Func<T, TResult> func) where T : class
        {
            if (n == null)
                return default(TResult);
            return func(n);
        }
	}
}
