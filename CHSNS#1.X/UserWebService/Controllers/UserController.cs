	using System;
	using System.Data;
	using System.Text;
	using Chsword;
	
	using CHSNS.Data;
	using CHSNS;
	using CHSNS;
	using System.Web.Mvc;
namespace CHSNS.Controllers {
	//	[Helper(typeof(PersonalHelper))]
	//[LoginedFilter]
	public class UserController : BaseController {
		//[SkipFilter(typeof(LoginedFilter))]
		public ActionResult Index() {
			long Ownerid = this.QueryLong("userid");
			if (0 == Ownerid) {
				Ownerid = ChUser.Current.Userid;
			}
			ViewData["Ownerid"] = Ownerid;
			Dictionary dict = new Dictionary();
			dict.Add("@ownerid", Ownerid);
			dict.Add("@viewerid", ChUser.Current.Userid);
			DataRowCollection rows = DataBaseExecutor.GetRows(
				"UserInformation", dict);
			DataRow dr = null;
			if (rows.Count > 0)
				dr = rows[0];
			if (Ownerid < 10000 || dr == null) {
				ViewData["noExists"] = true;
				return View();
			}
			ViewData["user"] = dr;
			if (!(dr != null
				&& (Convert.ToByte(dr["Relation"]) >= Convert.ToByte(dr["AllShowLevel"])
				|| ChSession.isAdmin))) {

				ViewData["noRight"] = true;

				return View();
			}

			Chsword.Reader.LogBook ul = new Chsword.Reader.LogBook("FirstLogBook",
	long.Parse(dr["Userid"].ToString()),
	ChUser.Current.Userid);
			ViewData["log1source"] = ul.GetLogBookTable(1, 2).Rows;
			ul = new Chsword.Reader.LogBook("SecondLogBook",
				long.Parse(dr["Userid"].ToString()));
			ViewData["log2source"] = ul.GetLogBookTable(1, 3).Rows;

			ViewData["isonline"] = Online.OnlineList.ContainsKey(Ownerid);
			return View();
		}
		//[SkipFilter(typeof(LoginedFilter))]
		public ActionResult random() {
			long Ownerid = this.QueryLong("userid");
			if (Ownerid == 0)
				Ownerid = ChUser.Current.Userid;
			//IDataBase idb = new DBExt(Session);
			ViewData["userSource"] = DBExt.UserListRows(Ownerid, 1, 2);
			return View();
		}
		[LoginedFilter]
		public ActionResult friend() {
			long Ownerid = this.QueryLong("userid");
			if (Ownerid == 0)
				Ownerid = ChUser.Current.Userid;
			DataRowCollection rows = DataBaseExecutor.GetRows("UserRelation",
				"@OwnerId", Ownerid,
				"@ViewerId", ChSession.Userid
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
				Ownerid = ChUser.Current.Userid;
			DataRowCollection rows = DataBaseExecutor.GetRows("UserRelation",
			"@OwnerId", Ownerid,
			"@ViewerId", ChSession.Userid
		);
			if (rows.Count > 0 && ChUser.Current.Userid == Ownerid)
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