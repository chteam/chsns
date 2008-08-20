using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CHSNS {

	public class SqlStoredProcedureDataOpener : SqlDataOpener {
		public SqlStoredProcedureDataOpener(string ConnectionString)
			: base(ConnectionString) {
			this.CommandType = CommandType.StoredProcedure;
		}
	}
}
