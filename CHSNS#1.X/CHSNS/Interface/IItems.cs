using System;

namespace Chsword.Interface {
	/// <summary>
	/// 对于列表项成员的添加、删除、升级、降级工作
	/// </summary>
	public interface IItems {
		string Add();
		string Remove();
		string Update();
		string Update2();
	}
}
