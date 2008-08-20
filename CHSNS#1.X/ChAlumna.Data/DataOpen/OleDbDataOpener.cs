using System;
using System.Collections.Generic;

using System.Text;
using System.Data.OleDb;
using System.Data.Common;
using System.Data;

namespace CHSNS {
	public class OleDbDataOpener : IDataOpener {
		OleDbConnection _Connection;
		OleDbCommand _Command;

		public DbCommand Command {
			get { return _Command; }
		}
		public OleDbDataOpener(string ConnectionString) {
			_Connection = new OleDbConnection(ConnectionString);
			_Command = new OleDbCommand();
		}
		#region 打开关闭数据库
		void Open(CommandType type, string text) {
			this.Command.Connection = _Connection;
			this.Command.CommandType = type;
			this.Command.CommandText = text;
			if (_Connection.State != ConnectionState.Open)
				this.Command.Connection.Open();
		}
		void  IDataOpener.Open(string SQLtext) {
			Open(CommandType.Text, SQLtext);
		}

		public void Close() {
			this.Command.Parameters.Clear();
			
		}
		public DbDataAdapter GetAdapter() {
			//throw new Exception(Command.CommandText);
			return new OleDbDataAdapter(_Command);
		}
		public void AddWithValue(string key, object value) {
			_Command.Parameters.AddWithValue(key, value);
		}
		public void Dispose() {
			if (_Connection.State != ConnectionState.Closed)
				Command.Connection.Close();
			Command.Dispose();
			_Connection.Dispose();
		}

		#endregion
	}
}
