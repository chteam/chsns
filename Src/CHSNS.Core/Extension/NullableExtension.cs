using System;

namespace CHSNS {
	public static class NullableExtension {
		public static object Get<T>(this T? n) where T: struct
		{
			if (n.HasValue)
				return n.Value;
			return DBNull.Value;
		}
	}
}
