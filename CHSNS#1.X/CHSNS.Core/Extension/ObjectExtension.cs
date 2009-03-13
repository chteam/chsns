using System.Collections.Generic;

namespace CHSNS {
	public static class ObjectExtension {
		public static IEnumerable<T> ToNotNull<T>(this object ie) {
			return (ie as IEnumerable<T>).ToNotNull();
		}
	}
}
