using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.Config
{
	[Serializable]
	public class BaseConfig
	{
		string _title;
		string _url;
		string _number;
		string _copyright;

		string _MasterEmail;
		string _senderEmail;
		string _senderName;
		string _smtpserver;
		string _smtpUser;
		string _smtpPassword;
		int _smtpPort = 25;


		String _Domain;
		bool _IsMustField = false;
		String _CookieName = "userInfo";
		string _path = "";
		string _style = "default";
		string _stylelist = "default|";
		//	string _publish;
		bool _isSoureFace = false;

		/// <summary>
		/// 是否允许查看原始大小的头像
		/// </summary>
		public bool IsSoureFace {
			get { return _isSoureFace; }
			set { _isSoureFace = value; }
		}

		public string StyleList {
			get { return _stylelist; }
			set { _stylelist = value; }
		}
		public string Style {
			get { return _style; }
			set { _style = value; }
		}
		public string Path {
			get { return _path; }
			set { _path = value; }
		}


		public String CookieName {
			get { return _CookieName; }
			set { _CookieName = value; }
		}

		public bool IsMustField {
			get { return _IsMustField; }
			set { _IsMustField = value; }
		}
		public String Domain {
			get { return _Domain; }
			set { _Domain = value; }
		}
		public int SmtpPort {
			get { return _smtpPort; }
			set { _smtpPort = value; }
		}

		public string SmtpPassword {
			get { return _smtpPassword; }
			set { _smtpPassword = value; }
		}
		/// <summary>
		/// SMTP用户名
		/// </summary>
		public string SmtpUser {
			get { return _smtpUser; }
			set { _smtpUser = value; }
		}
		/// <summary>
		/// SMTP服务器
		/// </summary>
		public string SmtpServer {
			get { return _smtpserver; }
			set { _smtpserver = value; }
		}
		/// <summary>
		/// 发件人名称
		/// </summary>
		public string SenderName {
			get { return _senderName; }
			set { _senderName = value; }
		}
		/// <summary>
		/// 发件人信箱
		/// </summary>
		public string SenderEmail {
			get { return _senderEmail; }
			set { _senderEmail = value; }
		}
		/// <summary>
		/// 站长信箱
		/// </summary>
		public string MasterEmail {
			get { return _MasterEmail; }
			set { _MasterEmail = value; }
		}
		public string Copyright {
			get { return _copyright; }
			set { _copyright = value; }
		}
		/// <summary>
		/// 备案
		/// </summary>
		public string Number {
			get { return _number; }
			set { _number = value; }
		}
		public string Url {
			get { return _url; }
			set { _url = value; }
		}
		public string Title {
			get { return _title; }
			set { _title = value; }
		}
	}
}
