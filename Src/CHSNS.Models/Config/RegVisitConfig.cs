namespace CHSNS.Config
{
	using System;
	public class RegVisitConfig
	{
	    /// <summary>
		/// 必须实名
		/// </summary>
		public bool IsEmailValidate { get; set; } = true;

	    /// <summary>
		/// 允许注册
		/// </summary>
		public bool IsAllowReg { get; set; } = true;
	}
}
