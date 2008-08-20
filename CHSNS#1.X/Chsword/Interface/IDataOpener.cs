
using System.Data.Common;

namespace CHSNS {
	public interface IDataOpener {
		DbCommand Command { get; }
		void Open(string SQLtext);
		void Close();
		DbDataAdapter GetAdapter();
		void AddWithValue(string key,object value);
		void Dispose();
	}
}
