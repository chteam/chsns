using System;
using System.Collections.Generic;

using System.Text;
using System.Data.Common;
using System.Data;

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
