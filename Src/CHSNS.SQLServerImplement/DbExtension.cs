using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.Objects;
using System.Data;
//using Microsoft.Data.Extensions;
using System.Data.SqlClient;
using CHSNS.Models;
namespace CHSNS.SQLServerImplement
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class DbExtension
    {
        public static void SubmitChanges(this DbEntities db)
        {
            db.SaveChanges();
        }

///// <summary>
//        /// a method that can execute a store procedure .
//        /// </summary>
//        /// <param name="context">the context of  the aef.</param>
//        /// <param name="procedureName">procedure name that you will execute</param>
//        /// <param name="parameters">parameter must the type of SqlParameter </param>
//        /// <returns>return the row count that execute.</returns>
//        public static int ExecuteFunctionNonQuery(this ObjectContext context, string procedureName, params object[] parameters)
//        {
//            var p = new List<SqlParameter>();
//            if(parameters.Count()%2==0)
//                for (int i = 0; i < parameters.Count(); i += 2)
//                {
//                    p.Add(new SqlParameter(parameters[i].ToString(), parameters[i + 1] == null ? DBNull.Value : parameters[i + 1]));
//                }
//            return ExecuteFunctionNonQuery(context,procedureName,p.ToArray());
//        }

//        public static int ExecuteFunctionNonQuery(this ObjectContext context, string procedureName, params  SqlParameter[] parameters)
//        {
//            using (var cmd = context.CreateStoreCommand(procedureName, CommandType.StoredProcedure, parameters))
//            using (cmd.Connection.CreateConnectionScope())
//                return cmd.ExecuteNonQuery();
//        }

//        /// <summary>
//        /// execute a store procedure ,and return a table with one row and one 
//        /// </summary>
//        /// <param name="context"></param>
//        /// <param name="procedureName"></param>
//        /// <param name="parameters"></param>
//        /// <returns></returns>
//        public static object ExecuteFunctionScalar(this ObjectContext context, string procedureName, params object[] parameters)
//        {
//            var p = new List<SqlParameter>();
//            if (parameters.Count() % 2 == 0)
//                for (int i = 0; i < parameters.Count(); i += 2)
//                {
//                    p.Add(new SqlParameter(parameters[i].ToString(), parameters[i + 1] == null ? DBNull.Value : parameters[i + 1]));
//                }
//            return ExecuteFunctionScalar(context, procedureName,p.ToArray());
//        }
//        public static object ExecuteFunctionScalar(this ObjectContext context, string procedureName, params SqlParameter[] parameters)
//        {
//            using (var cmd = context.CreateStoreCommand(procedureName, CommandType.StoredProcedure, parameters))
//            using (cmd.Connection.CreateConnectionScope())
//                return cmd.ExecuteScalar();
//        }

//        public static System.Data.Common.DbCommand CreateStoredProcedure(this ObjectContext context, string procedureName, params object[] parameters)
//        {
//            var p = new List<SqlParameter>();
//            if (parameters.Count() % 2 == 0)
//                for (int i = 0; i < parameters.Count(); i += 2)
//                {
//                    p.Add(new SqlParameter(parameters[i].ToString(), parameters[i + 1] == null ? DBNull.Value : parameters[i + 1]));
//                }
//            return context.CreateStoreCommand(procedureName, CommandType.StoredProcedure, p.ToArray());
//        }
        //public static IDisposable CreateConnectionScope(this ObjectContext db) {
        //    return db.Connection.CreateConnectionScope();
        //}
    }
}