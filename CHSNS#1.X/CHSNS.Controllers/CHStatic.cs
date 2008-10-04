using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using CHSNS.Models;

namespace CHSNS {
	public class CHStatic {
		class NeastStore {
			public long FriendRequestCount {get;set;}
			public long UnReadMessageCount { get; set; }
		}
		public static void Clear() {
			HttpContext.Current.Session.Remove("CHStatic");
		}
		static NeastStore Storer {
			get {
				if (HttpContext.Current.Session["CHStatic"] == null) {
					var db = new Data.DBExt();
					var ret = db.UserInfo.GetUser<NeastStore>(CHUser.UserID, c => new NeastStore() {
						FriendRequestCount = c.FriendRequestCount,
						UnReadMessageCount = c.UnReadMessageCount
					});
					HttpContext.Current.Session["CHStatic"] = ret;
				}
				return HttpContext.Current.Session["CHStatic"] as NeastStore;
			}
		}
		public static long FriendRequestCount {
			get {
				return Storer.FriendRequestCount;
			}
		}
		public static long UnReadMessageCount {
			get {
				return Storer.UnReadMessageCount;
			}
		}
	}
}
