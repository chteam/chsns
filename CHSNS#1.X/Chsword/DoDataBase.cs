namespace Chsword {
	using System;
	using System.Configuration;
	using System.Data;
	using System.Data.SqlClient;
	using System.Collections.Generic;
	/// <summary>
	/// 成幻互联ADO.net数据操作类。
	/// 2006年2月
	/// AU:邹健
	/// </summary>
	public class DoDataBase {
		private SqlConnection _SqlConnection;
		private SqlCommand _SqlCommand;
		/// <summary>
		/// 构造函数，对DoDataBase对象进行初始化。
		/// </summary>
		public DoDataBase() {
			_SqlConnection = new SqlConnection();
			_SqlCommand = new SqlCommand();
		}
		#region 打开关闭数据库
		void Open(CommandType type,string text){
			_SqlConnection.ConnectionString = ChAlumna.Config.SiteConfig.SiteConnectionString;
			_SqlCommand.Connection = _SqlConnection;
			_SqlCommand.CommandType = type;
			_SqlCommand.CommandText = text.Trim ();
			_SqlConnection.Open();
		}
		void Open_StoredProcedure(String StoredProcedureName) {
			Open(CommandType.StoredProcedure,StoredProcedureName);
		}
		void Open_Text(String SQLtext){
			Open(CommandType.Text,SQLtext);
		}
		void CloseSql() {
			_SqlCommand.Parameters.Clear();
			_SqlConnection.Close();
		}
		#endregion
		public String DoParameterSql(String StoredProcedureName, IDictionary<string,object> dict) {
			String Result = "";
			SqlDataReader reader;
			Open_StoredProcedure(StoredProcedureName);
			
			foreach(string key in dict.Keys){
				_SqlCommand.Parameters.AddWithValue(key,dict[key]);
			}
			_SqlCommand.Parameters.Add("@RETURN_VALUE", SqlDbType.BigInt);
			_SqlCommand.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
			ConnectionState previousConnectionState = _SqlConnection.State;

			if (_SqlConnection.State == ConnectionState.Closed) 
				_SqlConnection.Open();
			reader = _SqlCommand.ExecuteReader();
			Result = _SqlCommand.Parameters["@RETURN_VALUE"].Value.ToString();
			CloseSql();
			
			return Result;
		}
		
		/// <summary>
		/// 进行查询或数据操作。
		/// </summary>
		/// <param name="StoredProcedureName">设置要对数据源执行的存储过程。</param>
		/// <param name="SqlParameter">存储过程参数。</param>
		/// <returns>包含查询结果的</returns>
		public String DoParameterSql(String StoredProcedureName, SqlParameter[] SqlParameter) {
			String Result = "";
			SqlDataReader reader;
			Open_StoredProcedure(StoredProcedureName);
			for (int i = SqlParameter.GetLowerBound(0); i <= SqlParameter.GetUpperBound(0); i++) {
				_SqlCommand.Parameters.Add(SqlParameter[i]);
			}
			_SqlCommand.Parameters.Add("@RETURN_VALUE", SqlDbType.BigInt);
			_SqlCommand.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
			ConnectionState previousConnectionState = _SqlConnection.State;

			if (_SqlConnection.State == ConnectionState.Closed) _SqlConnection.Open();
			reader = _SqlCommand.ExecuteReader();
			Result = _SqlCommand.Parameters["@RETURN_VALUE"].Value.ToString();
			CloseSql();
			
			return Result;
		}
		/// <summary>
		/// 进行查询或数据操作。
		/// </summary>
		/// <param name="StoredProcedureName">设置要对数据源执行的存储过程。</param>
		/// <param name="SqlParameter">存储过程参数。</param>
		/// <param name="ReturnValue">可以进行输出的参数。</param>
		/// <returns></returns>
		public Object DoParameterSql(String StoredProcedureName, SqlParameter[] SqlParameter, SqlParameter ReturnValue) {
			Open_StoredProcedure(StoredProcedureName);
			for (int i = SqlParameter.GetLowerBound(0); i <= SqlParameter.GetUpperBound(0); i++) {
				_SqlCommand.Parameters.Add(SqlParameter[i]);
			}
			_SqlCommand.Parameters.Add(ReturnValue);
			ReturnValue.Direction = ParameterDirection.Output;
			_SqlCommand.ExecuteNonQuery();
			CloseSql();
			return ReturnValue.SqlValue.ToString();
		}
		/// <summary>
		/// 执行无返回操作
		/// </summary>
		/// <param name="StoredProcedureName">存储过程名</param>
		/// <param name="SqlParameter">参数</param>
		public void ExecuteSql(String StoredProcedureName, SqlParameter[] SqlParameter) {
			Open_StoredProcedure(StoredProcedureName);
			foreach(SqlParameter x in SqlParameter) {
				_SqlCommand.Parameters.Add(x);
			}
			_SqlCommand.ExecuteNonQuery();
			CloseSql();
		}
		public object ExecuteScalar(String StoredProcedureName,Dictionary<string,object> sps){
			Open_StoredProcedure(StoredProcedureName);
			foreach(string key in sps.Keys) {
				_SqlCommand.Parameters.AddWithValue(key,sps[key]);
			}
			object ret = _SqlCommand.ExecuteScalar();
			CloseSql();
			return ret;
		}
		
		/// <summary>
		/// 进行查询或数据操作。
		/// </summary>
		/// <param name="StoredProcedureName">设置要对数据源执行的存储过程。</param>
		/// <param name="SqlParameter">存储过程参数。</param>
		/// <returns>返回查询得到的数据集。</returns>
		public DataSet DoDataSet(String StoredProcedureName, SqlParameter[] SqlParameter) {
			Open_StoredProcedure(StoredProcedureName);
			for (int i = SqlParameter.GetLowerBound(0); i <= SqlParameter.GetUpperBound(0); i++) {
				_SqlCommand.Parameters.Add(SqlParameter[i]);
			}
			DataSet ds = new DataSet();
			SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(_SqlCommand);
			MySqlDataAdapter.Fill(ds, "table_1");
			CloseSql();
			return ds;
		}
		
		public DataSet DoDataSet(String StoredProcedureName) {
			Open_StoredProcedure(StoredProcedureName);
			DataSet ds = new DataSet();
			SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(_SqlCommand);
			MySqlDataAdapter.Fill(ds, "table_1");
			CloseSql();
			return ds;
		}
		public DataTable DoDataTable(string StoredProcedureName){
			Open_StoredProcedure(StoredProcedureName);
			DataTable dt = new DataTable();
			SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(_SqlCommand);
			MySqlDataAdapter.Fill(dt);
			CloseSql();
			return dt;
		}
		public DataTable DoDataTable(String StoredProcedureName, SqlParameter[] SqlParameter) {
			Open_StoredProcedure(StoredProcedureName);
			for (int i = SqlParameter.GetLowerBound(0); i <= SqlParameter.GetUpperBound(0); i++) {
				_SqlCommand.Parameters.Add(SqlParameter[i]);
			}
			DataTable dt = new DataTable();
			SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(_SqlCommand);
			MySqlDataAdapter.Fill(dt);
			CloseSql();
			return dt;
		}
		//使用Idictionary传递参数
		public DataTable GetDataTable(String StoredProcedureName,  IDictionary<string,object> dict) {
			Open_StoredProcedure(StoredProcedureName);
			foreach(string name in dict.Keys){
				_SqlCommand.Parameters.AddWithValue(name,dict[name]);
			}
			DataTable dt=new DataTable();
			SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(_SqlCommand);
			MySqlDataAdapter.Fill(dt);
			CloseSql();
			return dt;
		}
		public DataRowCollection GetRows(String StoredProcedureName, IDictionary<string,object> dict) {
			return GetDataTable(StoredProcedureName,dict).Rows;
		}
		
		
		
		//以下为使用SQL语句
		public DataTable getDataTable_SqlText(string sqltext) {
			Open_Text(sqltext);
			DataTable dt = new DataTable();
			SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(_SqlCommand);
			MySqlDataAdapter.Fill(dt);
			CloseSql();
			return dt;
		}
		public string getTableValue_SqlText(string sqltext) {
			Open_Text(sqltext);
			string ret=_SqlCommand.ExecuteScalar().ToString();
			CloseSql();
			return ret;
		}
		public int Executer_SqlText(string sqltext) {
			Open_Text(sqltext);
			int ret=_SqlCommand.ExecuteNonQuery();
			CloseSql();
			return ret;
		}


	}

}
