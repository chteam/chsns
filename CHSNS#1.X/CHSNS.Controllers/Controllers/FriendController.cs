using System.Data;
using System.Web.Mvc;
using CHSNS.Extension;
using CHSNS.Filter;
using CHSNS.Models;

namespace CHSNS.Controllers{
	public class FriendController:BaseController {
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
		public ActionResult Index() {
			var Ownerid = this.QueryLong("userid");
			if (Ownerid == 0) 
				Ownerid = CHSNSUser.Current.UserID;
			BasicInformation b = DBExt.UserInfo.GetUser(Ownerid);


			ViewData["user"] = b.Name;
			Profile p = new Profile();
			ViewData.Add("Count", p.FriendCount(Ownerid));

			int nowpage = this.QueryNum("p");
			if (nowpage == 0)
				nowpage = 1;

			ViewData["userSource"] = DBExt.UserListRows(Ownerid, nowpage, 0);
			ViewData["nowpage"] = nowpage;

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
