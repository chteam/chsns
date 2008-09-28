using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS {
	public static class NullableExtension {
		public static object Get<T>(this Nullable<T> n) where T: struct {
			if (n.HasValue)
				return n.Value;
			else
				return DBNull.Value;
		}
	}
}
