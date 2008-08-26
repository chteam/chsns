using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.Data {
	/// <summary>
	/// 观察者
	/// </summary>
	public interface IMediator {
		DBExt DBExt { get; set; }
		DataBaseExecutor DataBaseExecutor { get; set; }
	}
}
