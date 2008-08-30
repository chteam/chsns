using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CHSNS
{
	public class SqlDataOpener : IDataOpener
	{
		private readonly SqlCommand _Command;
		private readonly SqlConnection _Connection;

		public SqlDataOpener(string ConnectionString)
		{
			_Connection = new SqlConnection(ConnectionString);
			CommandType = CommandType.Text;
			_Command = new SqlCommand();
		}

		#region 打开关闭数据库

		void IDataOpener.Open(string SQLtext)
		{
			if (SQLtext.Trim().Contains(" "))
				Open(CommandType, SQLtext);
			else
				Open(CommandType.StoredProcedure, SQLtext);
		}

		public void Close()
		{
			Command.Parameters.Clear();
		}

		public DbDataAdapter GetAdapter()
		{
			return new SqlDataAdapter(_Command);
		}


		public void AddWithValue(string key, object value)
		{
			_Command.Parameters.AddWithValue(key, value);
		}


		public void Dispose()
		{
			if (_Connection.State != ConnectionState.Closed)
				Command.Connection.Close();
			Command.Dispose();
			_Connection.Dispose();
		}

		private void Open(CommandType type, string text)
		{
			Command.Connection = _Connection;
			Command.CommandType = type;
			Command.CommandText = text.Trim();
			if (_Connection.State != ConnectionState.Open)
				Command.Connection.Open();
		}

		#endregion

		protected CommandType CommandType { get; set; }

		#region IDataOpener Members

		public DbCommand Command
		{
			get { return _Command; }
		}

		#endregion
	}
}