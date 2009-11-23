using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace CHSNS
{
	///<summary>OleDB的DataOpener
	///</summary>
	public class OleDbDataOpener : IDataOpener
	{
		private readonly OleDbCommand _Command;
		private readonly OleDbConnection _Connection;

		///<summary>构造函数
		///</summary>
		///<param name="ConnectionString">连接字符串</param>
		public OleDbDataOpener(string ConnectionString)
		{
			_Connection = new OleDbConnection(ConnectionString);
			_Command = new OleDbCommand();
		}

		#region 打开关闭数据库

		void IDataOpener.Open(string SQLtext)
		{
			Open(CommandType.Text, SQLtext);
		}

		public void Close()
		{
			Command.Parameters.Clear();
		}

		public DbDataAdapter GetAdapter()
		{
			//throw new Exception(Command.CommandText);
			return new OleDbDataAdapter(_Command);
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
			Command.CommandText = text;
			if (_Connection.State != ConnectionState.Open)
				Command.Connection.Open();
		}



		public DbCommand Command
		{
			get { return _Command; }
		}



		public IDbConnection Connection {
			get { return _Connection; }
		}

		#endregion
	}
}