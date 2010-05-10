using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcHelper;
using System.Collections;
using System.Data;
using System.Linq.Expressions;
//using FlexigridMvcDemo.Extensions;

namespace FlexigridMvcDemo
{
    public static class FlexigridExtension
    {
        public static Hashtable ToFlexigridObject<T>(this PagedList<T> list, Func<T, object[]> func) where  T:class
        {
            var dataCollection = new FlexiGridModelProperties<T>();
            var x = dataCollection.ProperyItem;
            //var text = t.Select(c => c.Name);
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
        private static Expression RemoveUnary(Expression body)
        {
            var uniary = body as UnaryExpression;
            if (uniary != null)
            {
                return uniary.Operand;
            }

            return body;
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