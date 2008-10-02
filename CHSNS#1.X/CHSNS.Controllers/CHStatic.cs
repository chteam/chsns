using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using CHSNS.Models;

namespace CHSNS {
	public class CHStatic {
		class neast {
			public long FriendRequestCount {get;set;}
			public long UnReadMessageCount { get; set; }
		}
		static void UploadCount() {
			if (HttpContext.Current.Session["FriendRequestCount"] == null ||
				HttpContext.Current.Session["UnReadMessageCount"] == null) {
				var db = new Data.DBExt();
				db.UserInfo.GetUser<neast>(CHUser.UserID, c=>new neast() {
					FriendRequestCount=c.FriendRequestCount,
					UnReadMessageCount=c.InboxCount
				});
			}
		}
		public static long FriendRequestCount {
			get {
				UploadCount();
				long x = 0;
				if (HttpContext.Current.Session["FriendRequestCount"] != null)
					long.TryParse(HttpContext.Current.Session["FriendRequestCount"].ToString(), out x);
				return x;
			}
		}
		public static long UnReadMessageCount {
			get {
				UploadCount();
				long x = 0;
				if (HttpContext.Current.Session["UnReadMessageCount"] != null)
					long.TryParse(HttpContext.Current.Session["UnReadMessageCount"].ToString(), out x);
				return x;
			}
		}
	}
}
