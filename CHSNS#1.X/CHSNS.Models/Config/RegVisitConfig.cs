namespace CHSNS.Config
{
	using System;
	[Serializable]
	public class RegVisitConfig
	{
		bool _IsAllowReg = true;
		bool _IsEmailValidate = true;
		/// <summary>
		/// ����ʵ��
		/// </summary>
		public bool IsEmailValidate {
			get { return _IsEmailValidate; }
			set { _IsEmailValidate = value; }
		}

		/// <summary>
		/// ����ע��
		/// </summary>
		public bool IsAllowReg {
			get { return _IsAllowReg; }
			set { _IsAllowReg = value; }
		}


	}
}
