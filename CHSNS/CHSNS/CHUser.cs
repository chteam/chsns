using System;
using System.Web;

namespace CHSNS {
	public class CHUser {
		static public string NickName {
			get {
				if (String.IsNullOrEmpty(HttpContext.Current.Response.Cookies["CHSNS"]["nn"]))
					return HttpContext.Current.Request.Cookies["CHSNS"]["nn"];
				return String.Empty;
			}
		}
		static public long UserID {
			get {
				Int64 userid = 0;
				if (!String.IsNullOrEmpty(HttpContext.Current.Request.Cookies["CHSNS"]["id"])) {
					Int64.TryParse(HttpContext.Current.Request.Cookies["CHSNS"]["id"], out userid);
				}

				return userid;
			}
		}

		static public Boolean IsLogin {
			get {
				return HttpContext.Current.Session["roles"] != null;
			}
		}
	}
}
