using System;
using System.Data;
using System.Web.Mvc;

using CHSNS.Data;
using CHSNS.Models;
namespace CHSNS.Controllers {
	public class UserController : BaseController {
		//[SkipFilter(typeof(LoginedFilter))]
		public ActionResult Index() {
			UserPas up = new UserPas() {
				OwnerID = this.QueryLong("userid"),
				ViewerID = CHSNSUser.Current.UserID
			};
			DataRowCollection rows = DataBaseExecutor.GetRows("UserInformation"
				, "@ownerid", up.OwnerID, "@viewerid", up.ViewerID);
			if (rows.Count > 0) up.User = rows[0];
			if (!up.Exists || !up.HasRight) {
				return View();
			}
			#region note
			//Chsword.Reader.LogBook ul = new Chsword.Reader.LogBook("FirstLogBook", up.OwnerID, up.ViewerID);
			//ViewData["log1source"] = ul.GetLogBookTable(1, 2).Rows;
			//ul = new Chsword.Reader.LogBook("SecondLogBook",
			//    long.Parse(dr["Userid"].ToString()));
			//ViewData["log2source"] = ul.GetLogBookTable(1, 3).Rows;
			#endregion
			up.IsOnline = Online.OnlineList.ContainsKey(up.OwnerID);
			ViewData["Title"] = up.OwnerName + "的页面";
			return View(up);
		}
		//[SkipFilter(typeof(LoginedFilter))]
		public ActionResult random() {
			long Ownerid = this.QueryLong("userid");
			if (Ownerid == 0)
				Ownerid = CHSNSUser.Current.UserID;
			//IDataBase idb = new DBExt(Session);
			ViewData["userSource"] = DBExt.UserListRows(Ownerid, 1, 2);
			return View();
		}
		[LoginedFilter]
		public ActionResult friend() {
			long Ownerid = this.QueryLong("userid");
			if (Ownerid == 0)
				Ownerid = CHSNSUser.Current.UserID;
			DataRowCollection rows = DataBaseExecutor.GetRows("UserRelation",
				"@OwnerId", Ownerid,
				"@ViewerId", CHUser.UserID
			);
			if (rows.Count > 0)
				ViewData["user"] = rows[0];
			Profile p = new Profile();
			ViewData.Add("Count", p.FriendCount(Ownerid));

			int nowpage = this.QueryNum("p");
			if (nowpage == 0)
				nowpage = 1;
			//	IDataBase idb = new DBExt(Session);

			ViewData["userSource"] = DBExt.UserListRows(Ownerid, nowpage, 0);
			ViewData["nowpage"] = nowpage;

			////		ViewData["nowpage"] = nowpage;
			//        ViewData["ownerid"] = Ownerid;
			//        ViewData["type"] = 0;

			//ViewData["items"] = Show(Ownerid, 0, "Friend");
			return View();
		}
		[LoginedFilter]
		public ActionResult FriendRequest() {
			long Ownerid = this.QueryLong("userid");
			if (Ownerid == 0)
				Ownerid = CHSNSUser.Current.UserID;
			DataRowCollection rows = DataBaseExecutor.GetRows("UserRelation",
			"@OwnerId", Ownerid,
			"@ViewerId", CHUser.UserID
		);
			if (rows.Count > 0 && CHSNSUser.Current.UserID == Ownerid)
				ViewData["user"] = rows[0];
			Profile p = new Profile();
			ViewData.Add("Count", p.FriendRequestCount(Ownerid));

			int nowpage = this.QueryNum("p");
			if (nowpage == 0)
				nowpage = 1;
			ViewData["nowpage"] = nowpage;
			//	IDataBase idb = new DBExt(Session);
			ViewData["userSource"] = DBExt.UserListRows(Ownerid, nowpage, 1);

			return View();
			//	ViewData["items"] = Show(Ownerid, 1, "FriendRequest");
		}

	}
}