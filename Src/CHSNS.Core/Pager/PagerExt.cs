using System;
using System.Collections.Generic;
using System.Linq;

namespace CHSNS {
    public static class PagerExt {
        public static PagedList<T> Pager<T>(this  IQueryable<T> source, int currentPage, int pageSize)
        {
            if (currentPage < 1)
                throw new ArgumentOutOfRangeException("currentPage",
                                                      "The page number should be greater than or equal to 1.");
            return new PagedList<T>(source, currentPage, pageSize);
        }

        public static PagedList<T> Pager<T>(this  IQueryable<T> source, int currentPage) {
            return source.Pager(currentPage, 20);
        }
        public static PagedList<T> Pager<T>(this  IEnumerable<T> source, int currentPage, int pageSize) {
            if (currentPage < 1)
                throw new ArgumentOutOfRangeException("currentPage",
                                                      "The page number should be greater than or equal to 1.");
            return new PagedList<T>(source, currentPage, pageSize);
        }
        public static PagedList<T> Pager<T>(this  IEnumerable<T> source, int currentPage) {
                   return source.Pager(currentPage, 20);
        }
    }
}
