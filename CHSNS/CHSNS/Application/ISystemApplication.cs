using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS {
	public interface ISystemApplication : IBaseApplication {
		Dictionary<string, string> PositionView { get; }
		/// <summary>
		/// 
		/// </summary>
		int Position { get; }
	}
}
