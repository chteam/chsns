namespace ChAlumna
{
	using System;
	using System.Data;
	using System.Data.SqlClient;

	using Chsword;

	public class DataBaseExecutor
	{
		static public void Execute(string spstr, params object[] args) {
			Execute(spstr, Dictionary.CreateFromArgs(args));
			return;
		}
		static public void Execute(string spstr, Dictionary dict) {
			DoDataBase dd = new DoDataBase();
			dd.DoParameterSql(spstr, dict);
			return;
		}
		static public object ExecuteScalar(string spstr, params object[] args) {
			return ExecuteScalar(spstr, Dictionary.CreateFromArgs(args));
		}
		static public object ExecuteScalar(string spstr, Dictionary dict) {
			DoDataBase dd = new DoDataBase();
			return dd.ExecuteScalar(spstr, dict);
		}

		static public DataRowCollection GetRows(string spstr, Dictionary ps) {
			DoDataBase db = new DoDataBase();
			return db.GetRows(spstr, ps);
		}
		static public DataRowCollection GetRows(string spstr, params object[] args) {
			return GetRows(spstr, Dictionary.CreateFromArgs(args));
		}

		static public Int64 GetReturnValue(string spstr, Dictionary ps) {
			Int64 ret = 0;
			DoDataBase db = new DoDataBase();
			Int64.TryParse(db.DoParameterSql(spstr, ps), out ret);
			return ret;
		}

		static public DataTable GetDataTable_str1(string str, string strstr, string spstr) {
			SqlParameter[] sp = new SqlParameter[1]{
				new SqlParameter(strstr.Trim(), SqlDbType.NVarChar, 50)
			};
			sp[0].Value = str.Trim();
			DoDataBase db = new DoDataBase();
			return db.DoDataTable(spstr, sp);
		}
	}
}
