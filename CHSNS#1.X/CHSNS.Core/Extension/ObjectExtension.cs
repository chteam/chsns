using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS {
	public static class ObjectExtension {
		public static IEnumerable<T> ToNotNull<T>(this object ie) {
			return (ie as IEnumerable<T>).ToNotNull();
		}
	}
}
