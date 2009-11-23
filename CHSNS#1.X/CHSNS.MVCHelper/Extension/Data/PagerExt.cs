using System.Collections.Generic;
using System.Linq;

namespace CHSNS {
	public static class PagerExt {
        public static PagedList<T> Pager<T>
			(this  IQueryable<T> source, int currentPage, int pageSize) {
			return new PagedList<T>(source, currentPage, pageSize);				
		}
	}
}
