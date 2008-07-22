using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS {
	public interface IBaseApplication {
		string GUID { get;}
		string Name { get; }
		string Version { get; }
		string ControllerName { get;  }
		string Description { get; }
	}
}
