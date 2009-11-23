using System;

namespace CHSNS.Config
{
	[Serializable]
	public class BaseConfig
	{
		/// <summary>
		/// 是否允许查看原始大小的头像
		/// </summary>
		public bool IsSoureFace { get; set; }

		public string StyleList { get; set; }
		public string Style { get; set; }
		public string Path { get; set; }


		public String CookieName { get; set; }

		public bool IsMustField { get; set; }

		public String Domain { get; set; }

		public int SmtpPort { get; set; }
		public string SmtpPassword { get; set; }
		/// <summary>
		/// SMTP用户名
		/// </summary>
		public string SmtpUser { get; set; }
		/// <summary>
		/// SMTP服务器
		/// </summary>
		public string SmtpServer { get; set; }
		/// <summary>
		/// 发件人名称
		/// </summary>
		public string SenderName { get; set; }
		/// <summary>
		/// 发件人信箱
		/// </summary>
		public string SenderEmail { get; set; }
		/// <summary>
		/// 站长信箱
		/// </summary>
		public string MasterEmail { get; set; }

		#region base
		/// <summary>
		/// 版权
		/// </summary>
		public string Copyright { get; set; }
		/// <summary>
		/// 备案
		/// </summary>
		public string Number { get; set; }
		public string Url { get; set; }
		public string Title { get; set; }
		#endregion
	}
}
