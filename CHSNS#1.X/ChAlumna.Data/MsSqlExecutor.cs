
namespace ChAlumna
{
	using System.Data.SqlClient;
	using System.Data;
	using ChAlumna.Config;
	public class MsSqlExecutor : IDataBaseExecutor
	{
		SqlConnection _Connection;
		SqlCommand _Command;
		public MsSqlExecutor() {
			_Connection = new SqlConnection();
			_Command = new SqlCommand();
		}
		#region 打开关闭数据库
		void Open(CommandType type, string text) {
			_Connection.ConnectionString = SiteConfig.SiteConnectionString;
			//_SqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			_Command.Connection = _Connection;
			_Command.CommandType = type;
			_Command.CommandText = text.Trim();
			_Connection.Open();
		}
		void Open_StoredProcedure(string StoredProcedureName) {
			Open(CommandType.StoredProcedure, StoredProcedureName);
		}
		void Open_Text(string SQLtext) {
			Open(CommandType.Text, SQLtext);
		}
		void CloseSql() {
			_Command.Parameters.Clear();
			_Connection.Close();
		}
		#endregion
		#region IDataBaseExecutor 成员

		public void Execute(string name) {
			Execute(name, new Dictionary());
		}

		public void Execute(string name, Dictionary dict) {
			Open_StoredProcedure(name);
			foreach (string key in dict.Keys) {
				_Command.Parameters.AddWithValue(key, dict[key]);
			}
			ConnectionState previousConnectionState = _Connection.State;

			if (_Connection.State == ConnectionState.Closed)
				_Connection.Open();
			_Command.ExecuteNonQuery(); ;
			CloseSql();
		}

		public void Execute(string name, params string[] args) {
			Execute(name, Dictionary.CreateFromArgs(args));
		}

		public object ExecuteScalar(string name) {
			return ExecuteScalar(name, new Dictionary());
		}

		public object ExecuteScalar(string name, Dictionary dict) {
			Open_StoredProcedure(name);
			foreach (string key in dict.Keys) {
				_Command.Parameters.AddWithValue(key, dict[key]);
			}
			object ret = _Command.ExecuteScalar();
			CloseSql();
			return ret;
		}

		public object ExecuteScalar(string name, params object[] args) {
			return ExecuteScalar(name,Dictionary.CreateFromArgs(args));
		}


		public DataRowCollection GetRows(string name) {
			return GetRows(name, new Dictionary());
		}

		public DataRowCollection GetRows(string name, Dictionary dict) {
			Open_StoredProcedure(name);
			foreach (string key in dict.Keys) {
				_Command.Parameters.AddWithValue(key, dict[key]);
			}
			DataTable dt = new DataTable();
			SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(_Command);
			MySqlDataAdapter.Fill(dt);
			CloseSql();
			return dt.Rows;
		}

		public DataRowCollection GetRows(string name, params object[] args) {
			return GetRows(name, Dictionary.CreateFromArgs(args));
		}


		public void SqlExecute(string name) {
			SqlExecute(name, new Dictionary());
		}

		public void SqlExecute(string name, Dictionary dict) {
			Open_Text(name);
			foreach (string key in dict.Keys) {
				_Command.Parameters.AddWithValue(key, dict[key]);
			}
			ConnectionState previousConnectionState = _Connection.State;

			if (_Connection.State == ConnectionState.Closed)
				_Connection.Open();
			_Command.ExecuteNonQuery(); ;
			CloseSql();
		}

		public void SqlExecute(string name, params string[] args) {
			SqlExecute(name, Dictionary.CreateFromArgs(args));
		}

		public object SqlExecuteScalar(string name) {
			return SqlExecuteScalar(name, new Dictionary());

		}

		public object SqlExecuteScalar(string name, Dictionary dict) {
			Open_Text(name);
			foreach (string key in dict.Keys) {
				_Command.Parameters.AddWithValue(key, dict[key]);
			}
			object ret = _Command.ExecuteScalar();
			CloseSql();
			return ret;
		}

		public object SqlExecuteScalar(string name, params object[] args) {
			return SqlExecuteScalar(name, Dictionary.CreateFromArgs(args));
		}

		public DataRowCollection SqlGetRows(string name) {
			return SqlGetRows(name, new Dictionary());
		}

		public DataRowCollection SqlGetRows(string name, Dictionary dict) {
			Open_Text(name);
			foreach (string key in dict.Keys) {
				_Command.Parameters.AddWithValue(key, dict[key]);
			}
			DataTable dt = new DataTable();
			SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(_Command);
			MySqlDataAdapter.Fill(dt);
			CloseSql();
			return dt.Rows;
		}

		public DataRowCollection SqlGetRows(string name, params object[] args) {
			return SqlGetRows(name, Dictionary.CreateFromArgs(args));
		}

		#endregion
	}
}
