namespace CHSNS {
	using System;
	using System.Data;
	using System.Web;

	public partial class CHSNSUser {
		/// <summary>
		/// 只有注册时才用的属性
		/// </summary>
		string _email;
		public string Email {
			get {
				return _email;
			}
			set {
				_email = value;
			}
		}
		/// <summary>
		/// 获取当前用户ID,如用户未登录则抛出异常.
		/// </summary>
		long _userid;
		public long UserID {
			get {
				return _userid;
			}
			set {
				_userid = value;
			}
		}
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
				//if (isLogined) {
				//    //_status = UserStatusType.Guest;
				//    _status = (UserStatusType)HttpContext.Current.Session["status"];
				//} else {
				//    _status = UserStatusType.Guest;
				//}
				return (UserStatusType)CHUser.Status;
				//return _status;
			}
			set {
				_status = value;
			//	HttpContext.Current.Session["status"] = value;
				if (_status.GetHashCode()!=0) {
					System.Data.SqlClient.SqlParameter[] sp = new System.Data.SqlClient.SqlParameter[2] { 
							new System.Data.SqlClient.SqlParameter("@Userid", SqlDbType.BigInt),
							new System.Data.SqlClient.SqlParameter("@status", SqlDbType.TinyInt),
					};
					sp[0].Value = CHUser.UserID;
					sp[1].Value = _status;

					Chsword.DoDataBase db = new Chsword.DoDataBase();
					db.ExecuteSql("Status_Update", sp);
				}
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
						CHSNSUser cu = new CHSNSUser();
						cu.UserID = CHUser.UserID;
						cu.Username = CHUser.Username;
						HttpContext.Current.Session["account"] = cu;
					}
					return HttpContext.Current.Session["account"] as CHSNSUser;
				}
				return new CHSNSUser();
			}
		}
	}
}
