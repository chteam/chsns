using System;

namespace CHSNS.Config {
	/// <summary>
	/// 应用程序元素
	/// </summary>
	public class ApplicationItem {
		/// <summary>
		/// 应用的英文标识,自定义时使用
		/// </summary>
		public string ID{ get; set; }
		/// <summary>
		/// 应用所在的Controller,限系统
		/// </summary>
		public string Controller { get; set; }
		/// <summary>
		/// 应用所在Action,限系统
		/// </summary>
		public string Action { get; set; }
		/// <summary>
		/// 全名
		/// </summary>
		public string FullName { get; set; }
		/// <summary>
		/// 短名,限四字
		/// </summary>
		public string ShortName { get; set; }
		/// <summary>
		/// 版本
		/// </summary>
		public string Version { get; set; }
		/// <summary>
		/// 图标
		/// </summary>
		public string Icon { get; set; }
		/// <summary>
		/// Css类，限系统
		/// </summary>
		public string CssName { get; set; }
		/// <summary>
		/// 作者ID
		/// </summary>
		public long AuthorID { get; set; }
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime AddTime { get; set; }
		/// <summary>
		/// 升级时间
		/// </summary>
		public DateTime UpdateTime { get; set; }
		/// <summary>
		/// 应用介绍
		/// </summary>
		public string Summary { get; set; }
		/// <summary>
		/// 应用介绍地址
		/// </summary>
		public string Url { get; set; }
		/// <summary>
		/// 是否为系统应用
		/// </summary>
		public bool IsSystem { get; set; }
		/// <summary>
		/// 审核通过与否
		/// </summary>
		public bool IsTrue { get; set; }
	/// <summary>
	/// 使用人数，系统不统计
	/// </summary>
		public long  UserCount { get; set; }
	}
}
