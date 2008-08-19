namespace ChAlumna
{
	using System.Data;
	public interface IDataBaseExecutor
	{
#region 存储过程部分
		void Execute(string name);
		void Execute(string name, Dictionary dict);
		void Execute(string name, params string[] args);

		object ExecuteScalar(string name);
		object ExecuteScalar(string name, Dictionary dict);
		object ExecuteScalar(string name, params object[] args);

		DataRowCollection GetRows(string name);
		DataRowCollection GetRows(string name, Dictionary dict);
		DataRowCollection GetRows(string name, params object[] args);

#endregion

		#region Sql语句部分
		void SqlExecute(string name);
		void SqlExecute(string name, Dictionary dict);
		void SqlExecute(string name, params string[] args);

		object SqlExecuteScalar(string name);
		object SqlExecuteScalar(string name, Dictionary dict);
		object SqlExecuteScalar(string name, params object[] args);

		DataRowCollection SqlGetRows(string name);
		DataRowCollection SqlGetRows(string name, Dictionary dict);
		DataRowCollection SqlGetRows(string name, params object[] args);

		#endregion
	}
}
