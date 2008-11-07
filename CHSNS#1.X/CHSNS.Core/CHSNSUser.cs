namespace CHSNS {
	using System;
	using System.Web;

	public class CHSNSUser {
		public UserStatusType status
		{
			get { return _status; }
		}

		public string Email { get; set; }

		public long UserID { get; set; }

		/// <summary>
		/// 获取当前用户姓名
		/// </summary>
		string _username;
		public string Username {
			get {
				if (!string.IsNullOrEmpty(_username)) {
					return _username;
				}
				return "undefine";
			}
			set {
				_username= value;
			}
		}
		/// <summary>
		/// 获取当前用户状态
		/// </summary>
		UserStatusType _status;
		public UserStatusType Status {
			get {
				return (UserStatusType)CHUser.Status;
			}
			set {
				_status = value;
				throw new  Exception("应做写数据库实现");
			}
		}
		public bool isAdmin {
			get {
				return CHUser.IsAdmin;
			}
		}
		public bool isLogined {
			get {
				return UserID != 0;
			}
		}
		public static CHSNSUser Current {
			get {
				if (CHUser.IsLogin) {
					if (HttpContext.Current.Session["account"] == null) {
						var cu = new CHSNSUser {UserID = CHUser.UserID, Username = CHUser.Username};
						HttpContext.Current.Session["account"] = cu;
					}
					return HttpContext.Current.Session["account"] as CHSNSUser;
				}
				return new CHSNSUser();
			}
		}
	}
}
