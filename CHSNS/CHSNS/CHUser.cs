using System;
using System.Web;

namespace CHSNS {
	public class CHUser {
		static public string NickName {
			get {
				if (String.IsNullOrEmpty(HttpContext.Current.Response.Cookies["CHSNS"]["nn"]))
					return HttpContext.Current.Response.Cookies["CHSNS"]["nn"];
				return String.Empty;
			}
		}
		static public long UserID {
			get {
				Int64 userid = 0;
				if (String.IsNullOrEmpty(HttpContext.Current.Response.Cookies["CHSNS"]["id"])) {
					Int64.TryParse(HttpContext.Current.Response.Cookies["CHSNS"]["id"], out userid);
				}
				return userid;
			}
		}

		static public Boolean IsLogin {
			get {
				return CHUser.UserID != 0;
			}
		}
	}
}
