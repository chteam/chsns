using System.Transactions;

namespace CHSNS.Controllers {
	using System;
	using System.Linq;
	using System.Web.Mvc;
	using Extension;
	using Filter;
	using Tools;
	public class FriendController : BaseController {
		public ActionResult Random() {
			ViewData["source"] = DBExt.Friend.GetRandoms();
			return View();
		}
		[LoginedFilter]
		public ActionResult RandomList() {
			return View(DBExt.Friend.GetRandoms());
		}
		[LoginedFilter]
		public ActionResult Index(){
			using (new TransactionScope()) {
				var Ownerid = this.QueryLong("userid");
				if (Ownerid == 0) Ownerid = CHSNSUser.Current.UserID;				
				var b = DBExt.Friend.UserFriendInfo(Ownerid);
				if (b == null) throw new Exception("用户不存在");
				ViewData["Name"] = b.Name;
				int nowpage = this.QueryNum("p") == 0 ? 1 : this.QueryNum("p");
				ViewData["NowPage"] = nowpage ;
				ViewData["PageCount"] = b.FriendCount;
				ViewData["source"] = DBExt.Friend.GetFriends(Ownerid).Pager(nowpage, 10);
				return View(b);
			}
		}

		[LoginedFilter]
		public ActionResult FriendList(int p, long userid){
			using (new TransactionScope()){
				return View(DBExt.Friend.GetFriends(userid).Pager(p, 10));
			}
		}

		[LoginedFilter]
		[ActionName("Request")]
		public ActionResult FriendRequest(){
			using (new TransactionScope()){
				var Ownerid = CHSNSUser.Current.UserID;
				var b = DBExt.Friend.UserFriendInfo(Ownerid);
				if (b == null) throw new Exception("用户不存在");
				ViewData["Name"] = b.Name;
				int nowpage = this.QueryNum("p") == 0 ? 1 : this.QueryNum("p");
				ViewData["NowPage"] = nowpage;
				ViewData["PageCount"] = DBExt.Friend.GetRequests(Ownerid).Count();
				ViewData["source"] = DBExt.Friend.GetRequests(Ownerid).Pager(nowpage, 10);
				return View(b);
			}
		}

		[LoginedFilter]
		public ActionResult RequestList(int p, long userid) {
			return View(DBExt.Friend.GetRequests(userid).Pager(p, 10));
		}
	}
}
