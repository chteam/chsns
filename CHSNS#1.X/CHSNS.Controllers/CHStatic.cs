using System.Web;
using System.Web.SessionState;

namespace CHSNS {
	public class CHStatic {
		static HttpSessionState Session {
			get {
				return HttpContext.Current.Session;
			}
		}
		class NeastStore {
			public long FriendRequestCount {get;set;}
			public long UnReadMessageCount { get; set; }
		}
		public static void Clear() {
			Session.Remove("CHStatic");
		}
		static NeastStore Storer {
			get {
				if (Session["CHStatic"] == null) {
					//var db = new Data.DBExt();
                    //var ret = db.UserInfo.GetUser(CHUser.UserID, c => new NeastStore
                    //                                                    {
                    ////	FriendRequestCount = c.FriendRequestCount,
                    ////	UnReadMessageCount = c.UnReadMessageCount
                    //});
					//Session["CHStatic"] = ret;
				}
				return Session["CHStatic"] as NeastStore;
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
