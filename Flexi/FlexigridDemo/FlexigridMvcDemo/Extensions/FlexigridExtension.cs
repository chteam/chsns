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
        public static FlexGridData<T> ToFlexigridObject<T>(this PagedList<T> list, Expression<Func<T, object>> key, Action<FlexiGridModelProperties<T>> properties) where T : class
        {
            var json = new FlexGridData<T>(
               list, list.CurrentPage,
               list.TotalCount,
               key, properties);
            return json;
        }
        public static FlexGridData<T> ToFlexigridObject<T>(this PagedList<T> list) where T : class
        {
            var json = new FlexGridData<T>(
               list, list.CurrentPage,
               list.TotalCount);
            return json;
        }
        //private static Expression RemoveUnary(Expression body)
        //{
        //    var uniary = body as UnaryExpression;
        //    if (uniary != null)
        //    {
        //        return uniary.Operand;
        //    }

        //    return body;
        //}
        public static FlexGridData<DataRow> ToFlexigridObject(this IEnumerable<DataRow> rows, int page, int total, Expression<Func<DataRow, object>> key, Action<FlexiGridModelProperties<DataRow>> properties)
        {
            var json = new FlexGridData<DataRow>(
                rows, page,
               total,
                key, properties);
            return json;
        }
    }
}