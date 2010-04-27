using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcHelper;
using System.Collections;
using System.Data;

namespace FlexigridMvcDemo
{
    public static class FlexigridExtension
    {
        public static Hashtable ToFlexigridObject<T>(this PagedList<T> list, Func<T, object[]> func)
        {
            var rowList = new List<Hashtable>();
            var json = new Hashtable{ 
             {"page", list.CurrentPage},
             {"total", list.TotalCount},
             {"rows", rowList}
            };
            //var array = list.Select(func);
            list.Select(func).ToList().ForEach(c => rowList.Add(new Hashtable
                                                       {
                                                           {"id", c[0]},
                                                           {"cell", c}
                                                       }));
            return json;
        }
        public static Hashtable ToFlexigridObject(this IEnumerable<DataRow> rows, int page, int total, string primayKey)
        {
            var rowList = new List<Hashtable>();
            var json = new Hashtable
                                 {
                                     {"page", page},
                                     {"total", total},
                                     {"rows", rowList}
                                 };
            rows.ToList().ForEach(c => rowList.Add(new Hashtable
                                                       {
                                                           {"id", c[primayKey].ToString()},
                                                           {"cell", c.ItemArray}
                                                       }));
            return json;
        }
    }
}