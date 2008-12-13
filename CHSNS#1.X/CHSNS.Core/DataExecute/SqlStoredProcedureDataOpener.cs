using System.Data;

namespace CHSNS
{
	///<summary>
	/// 只使用存储过程
	///</summary>
	public class SqlStoredProcedureDataOpener : SqlDataOpener
	{
		///<summary>
		/// 构造函数
		///</summary>
		///<param name="ConnectionString"></param>
		public SqlStoredProcedureDataOpener(string ConnectionString)
			: base(ConnectionString)
		{
			CommandType = CommandType.StoredProcedure;
		}
	}
}