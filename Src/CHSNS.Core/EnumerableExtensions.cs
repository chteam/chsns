using System;
using System.Collections.Generic;

namespace CHSNS {
	public static class EnumerableExtensions {
		public static IEnumerable<T> ToNotNull<T>(this IEnumerable<T> ie)
		{
			return ie ?? new List<T>();
		}

	}
}
