using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace CHSNS {
	/// <summary>
	/// 数据库执行者
	/// the Executor of DataBase
	/// </summary>
	public class DataBaseExecutor : IDisposable {
		IDataOpener DataOpen { get; set; }
		/// <summary>
		/// init
		/// </summary>
		/// <param name="dataopen">IDataOpener</param>
		public DataBaseExecutor(IDataOpener dataopen) {
			DataOpen = dataopen;
		}


		///<summary>
		/// 直接执行Sql语句
		///</summary>
		///<param name="sqltext"></param>
		public void Execute(string sqltext) {
			Execute(sqltext, new Dictionary());
		}

		///<summary>
		///  直接执行Sql语句
		///</summary>
		///<param name="sqltext"></param>
		///<param name="dict">参数</param>
		public void Execute(string sqltext, Dictionary dict) {
			DataOpen.Open(sqltext);
			foreach (string key in dict.Keys) {
				DataOpen.AddWithValue(key, dict[key]);
			}
			ConnectionState previousConnectionState = DataOpen.Command.Connection.State;

			if (previousConnectionState == ConnectionState.Closed)
				DataOpen.Command.Connection.Open();
			DataOpen.Command.ExecuteNonQuery(); ;
			DataOpen.Close();
		}

		public void Execute(string sqltext, params object[] args) {
			Execute(sqltext, Dictionary.CreateFromArgs(args));
		}

		public object ExecuteScalar(string sqltext) {
			return ExecuteScalar(sqltext, new Dictionary());
		}

		public object ExecuteScalar(string sqltext, Dictionary dict) {
			DataOpen.Open(sqltext);
			foreach (string key in dict.Keys) {
				DataOpen.AddWithValue(key, dict[key]);
			}
			object ret = DataOpen.Command.ExecuteScalar();
			DataOpen.Close();
			return ret;
		}

		public object ExecuteScalar(string name, params object[] args) {
			return ExecuteScalar(name, Dictionary.CreateFromArgs(args));
		}


		public DataTable GetTable(string name) {
			return GetTable(name, new Dictionary());
		}
		public DataRowCollection GetRows(string text) {
			return GetTable(text).Rows;
		}
		public DataTable GetTable(string name, Dictionary dict) {
			DataOpen.Open(name);
			foreach (string key in dict.Keys) {
				DataOpen.AddWithValue(key, dict[key]);
			}
			var dt = new DataTable();
			DbDataAdapter adp = DataOpen.GetAdapter();
			adp.Fill(dt);
			DataOpen.Close();
			return dt;
		}
		public DataRowCollection GetRows(string text, Dictionary dict) {
			return GetTable(text, dict).Rows;
		}
		public DataTable GetTable(string name, params object[] args) {
			return GetTable(name, Dictionary.CreateFromArgs(args));
		}
		public DataRowCollection GetRows(string text, params object[] args) {
			return GetTable(text, args).Rows;
		}
		public void Dispose() {
			DataOpen.Dispose();
		}

		#region GetValue
		public String GetValue(String text, IDictionary<string, object> dict) {
			DataOpen.Open(text);
			DbDataReader reader;
			foreach (string key in dict.Keys) {
				DataOpen.AddWithValue(key, dict[key]);
			}
			DataOpen.Command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
			reader = DataOpen.Command.ExecuteReader();
			string result = DataOpen.Command.Parameters["@RETURN_VALUE"].Value.ToString();
			DataOpen.Close();
			return result;
		}
		public String GetValue(String text, params object[] args) {
			return GetValue(text, Dictionary.CreateFromArgs(args));
		}
		public String GetValue(String text) {
			return GetValue(text,new Dictionary());
		}
		#endregion
	}
}
