﻿using System.Collections.Generic;
using System.Linq;

namespace CHSNS.Tools {
	public static class PagerExt {
		public static IEnumerable<T> Pager<T>(this  IQueryable<T> i, int nowpage, int everypage) {
			return i.Skip(everypage * (nowpage - 1)).Take(everypage);
		}
	}
}
