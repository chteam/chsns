namespace CHSNS.Config
{
	using System;
	[Serializable]
	public class RegVisitConfig
	{
		bool _IsAllowReg = true;
		bool _IsEmailValidate = true;
		/// <summary>
		/// 必须实名
		/// </summary>
		public bool IsEmailValidate {
			get { return _IsEmailValidate; }
			set { _IsEmailValidate = value; }
		}

		/// <summary>
		/// 允许注册
		/// </summary>
		public bool IsAllowReg {
			get { return _IsAllowReg; }
			set { _IsAllowReg = value; }
		}


	}
}
