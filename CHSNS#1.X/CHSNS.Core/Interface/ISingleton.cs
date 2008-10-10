using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS {
	public interface ISingleton<T>  {
		string SingletonString { get; }
		T Value { get; set; }
	}
}
