using System.Transactions;

namespace CHSNS.Controllers {
	using System;
	using System.Linq;
	using System.Web.Mvc;
	using Extension;
	using Filter;
	using Tools;
	public class FriendController : BaseController {
		#region Action
		public ActionResult Random() {
			ViewData["source"] = DBExt.Friend.GetRandoms();
			return View();
		}
		[LoginedFilter]
		public ActionResult Index(int? p, long? userid){
			using (new TransactionScope()){
				if (!userid.HasValue || userid == 0) userid = CHUser.UserID;
				if (!p.HasValue || p == 0) p = 1;
				var b = DBExt.Friend.UserFriendInfo(userid.Value);
				if (b == null) throw new Exception("用户不存在");
				ViewData["UserID"] = userid;
				ViewData["Name"] = b.Name;
				ViewData["NowPage"] = p;
				ViewData["PageCount"] = b.FriendCount;
				return FriendList(p.Value, userid.Value);
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
		#endregion
		#region pager ctrl
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult FriendList(int p, long userid) {
			using (new TransactionScope()) {
				return View(DBExt.Friend.GetFriends(userid).Pager(p, 10));
			}
		}
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult RequestList(int p, long userid) {
			return View(DBExt.Friend.GetRequests(userid).Pager(p, 10));
		}
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult RandomList() {
			return View(DBExt.Friend.GetRandoms());
		}
		#endregion

		#region ajax execute
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult Add(long toid) {//添加好友
			if (DBExt.Friend.Add(CHUser.UserID, toid))
				return Content("已经向对方发出请求");
			return Content("对方已经是你的好友");
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="toid"></param>
		/// <returns></returns>
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult Delete(long toid) {
			DBExt.Friend.Delete(CHUser.UserID, toid);
			return Content("解除关系成功");
		}
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult Agree(long uid) {//添加好友
			if (DBExt.Friend.Agree(CHUser.UserID, uid))
				return Content("已经加对方为好友");
			return Content("请求已经处理过了");
		}
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult Ignore(long uid) {//添加好友
			if (DBExt.Friend.Ignore(uid, CHUser.UserID))
				return Content("已经忽略了请求");
			return Content("请求已经处理过了");
		}
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult IgnoreAll() {//添加好友
			DBExt.Friend.IgnoreAll(CHUser.UserID);
			return Content("已经忽略所有请求");
		}
		#endregion
	}
}
