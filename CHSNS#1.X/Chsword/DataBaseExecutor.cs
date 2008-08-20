using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
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
			this.DataOpen = dataopen;
		}


		public void Execute(string name) {
			Execute(name, new Dictionary());
		}

		public void Execute(string name, Dictionary dict) {
			DataOpen.Open(name);
			foreach (string key in dict.Keys) {
				DataOpen.AddWithValue(key, dict[key]);
			}
			ConnectionState previousConnectionState = DataOpen.Command.Connection.State;

			if (previousConnectionState == ConnectionState.Closed)
				DataOpen.Command.Connection.Open();
			DataOpen.Command.ExecuteNonQuery(); ;
			DataOpen.Close();
		}

		public void Execute(string name, params object[] args) {
			Execute(name, Dictionary.CreateFromArgs(args));
		}

		public object ExecuteScalar(string name) {
			return ExecuteScalar(name, new Dictionary());
		}

		public object ExecuteScalar(string name, Dictionary dict) {
			DataOpen.Open(name);
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
			DataTable dt = new DataTable();
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


	}
}
