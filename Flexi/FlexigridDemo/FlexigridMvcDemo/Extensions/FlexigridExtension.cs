using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcHelper;
using System.Collections;

namespace FlexigridMvcDemo
{
    public static class FlexigridExtension
    {
        public static Hashtable ToFlexigridObject(this PagedList<object[]> list)
        {
            var rowList = new List<Hashtable>();
            var json = new Hashtable
                                 {
                                     {"page", list.CurrentPage},
                                     {"total", list.TotalCount},
                                     {"rows", rowList}
                                 };

            list.ToList().ForEach(c => rowList.Add(new Hashtable
                                                       {
                                                           {"id", c[0]},
                                                           {"cell", c}
                                                       }));
            return json;
        }
    }
}