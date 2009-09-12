using System;
using System.Collections.Generic;
using IBatisNet.Common.Exceptions;
using IBatisNet.Common.Pagination;

using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;

namespace CHSNS.SQLServerImplement
{
    public class BaseSqlMapDao
    {
        protected const int PageSize = 4;

        /// <summary>
        /// Looks up the parent DaoManager, gets the local transaction
        /// (which should be a SqlMapDaoTransaction) and returns the
        /// SqlMap associated with this DAO.
        /// </summary>
        /// <returns>The SqlMap instance for this DAO.</returns>
        protected ISqlMapper GetLocalSqlMap()
        {
            var daoManager = new DomSqlMapBuilder().Configure("SQLMap.config");
            // DaoManager.GetInstance(this);
            //  var sqlMapDaoSession = (SqlMapDaoSession)daoManager.LocalDaoSession;

            return daoManager;
        }

  
        protected IList<T> QueryToList<T>(string statementName, object parameterObject)
        {
            var sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForList<T>(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("�����б�'" + statementName + "'��ѯʱ����Cause: " + e.Message, e);
            }
        }

        protected IList<T> QueryToList<T>(string statementName, object parameterObject, int skipResults, int maxResults)
        {
            var sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForList<T>(statementName, parameterObject, skipResults, maxResults);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("�����б�'" + statementName + "'��ѯʱ����Cause: " + e.Message, e);
            }
        }
        [Obsolete("�������")]
        protected IPaginatedList QueryToPaginatedList(string statementName, object parameterObject, int pageSize)
        {
            var sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForPaginatedList(statementName, parameterObject, pageSize);
            }
            catch (Exception e)
            {
                throw new IBatisNetException(
                    "Error executing query '" + statementName + "' for paginated list.  Cause: " + e.Message, e);
            }
        }





        protected T Query<T>(string statementName, object parameterObject)
        {
            var sqlMap = GetLocalSqlMap();

            try
            {
                return sqlMap.QueryForObject<T>(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("��ѯ����������'" + statementName + "' �� Cause: " + e.Message, e);
            }
        }


        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        protected int Update(string statementName, object parameterObject)
        {
            var sqlMap = GetLocalSqlMap();

            try
            {
                return sqlMap.Update(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("���¶���ʱ�������� '" + statementName + "'��Cause: " + e.Message, e);
            }
        }

        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        protected object Insert(string statementName, object parameterObject)
        {
            var sqlMap = GetLocalSqlMap();

            try
            {
                return sqlMap.Insert(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("�������ʱ��������'" + statementName + "'��Cause: " + e.Message, e);
            }
        }
        /// <summary>
        /// ִ��ɾ������
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns>��Ӱ�������</returns>
        protected int Delete(string statementName,object parameterObject)
        {
            var sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.Delete(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("ɾ������ʱ��������'" + statementName + "'��Cause: " + e.Message, e);
            }
        }
    }
}