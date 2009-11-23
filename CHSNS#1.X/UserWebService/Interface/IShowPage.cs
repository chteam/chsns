using System;

namespace Chsword.Interface {
	/// <summary>
	/// 获取页面中可变的 分页 部分
	/// </summary>
	interface IShowPage {
		String ShowPage(System.Data.DataTable dt);
	}
}
