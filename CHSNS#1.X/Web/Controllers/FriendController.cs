using System.Transactions;
using CHSNS.ViewModel;

namespace CHSNS.Controllers {
	using System;
	using System.Linq;
	using System.Web.Mvc;

	public class FriendController : BaseController {
		#region Action
		public ActionResult Random() {
			ViewData["source"] = DbExt.Friend.GetRandoms(10);
			return View();
		}
        [LoginedFilter]
        public ActionResult Index(int? p, long? userid)
        {
            if (!userid.HasValue || userid == 0) userid = CHUser.UserID;
            InitPage(ref p);
            var b = DbExt.Friend.UserFriendInfo(userid.Value);
            if (b == null) throw new Exception("用户不存在");
            ViewData["UserId"] = userid;
            ViewData["Name"] = b.Name;
            ViewData["NowPage"] = p;
            //	ViewData["PageCount"] = b.FriendCount;
            Title = b.Name + "的好友";
            return FriendList(p.Value, userid.Value);
        }

        [LoginedFilter]
        [ActionName("Request")]
        public ActionResult RequestHack(int? p)
        {
            InitPage(ref p);
            var profile = DbExt.Friend.UserFriendInfo(CHUser.UserID);
            if (profile == null) throw new Exception("用户不存在");
            var items = DbExt.Friend.GetRequests(CHUser.UserID, p.Value, CHContext.Site);
            Title = profile.Name + "的好友请求";
            return View(new FriendRequest { Items = items, Profile = profile });

        }

	    #endregion
		#region pager ctrl
        [LoginedFilter]
        [AcceptVerbs("Post")]
        public ActionResult FriendList(int p, long userid)
        {
            var list = DbExt.Friend.GetFriends(userid, p, CHContext.Site);
            ViewData["PageCount"] = list.TotalPages;
            return View(list);
        }
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult RequestList(int p, long userid) {
            return View(DbExt.Friend.GetRequests(userid, p, CHContext.Site));
		}
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult RandomList() {
			return View(DbExt.Friend.GetRandoms(10));
		}
		#endregion

		#region ajax execute
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult Add(long toid)
		{//添加好友
			using (var ts = new TransactionScope())
			{
				var x = DbExt.Friend.Add(CHUser.UserID, toid);
				ts.Complete();
				if (x) return Content("已经向对方发出请求");
				return Content("对方已经是你的好友");
			}
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="toid"></param>
		/// <returns></returns>
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult Delete(long toid) {
			using (var ts = new TransactionScope())
			{
				DbExt.Friend.Delete(CHUser.UserID, toid);
				ts.Complete();
				return Content("解除关系成功");
			}
		}
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult Agree(long uid)
		{//添加好友
			using (var ts = new TransactionScope())
			{
				var r = DbExt.Friend.Agree(CHUser.UserID, uid,CHUser);
				ts.Complete();
				if (r) return Content("已经加对方为好友");
				return Content("请求已经处理过了");
			}
		}
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult Ignore(long uid) {//添加好友
			using (var ts = new TransactionScope())
			{
				var r=DbExt.Friend.Ignore(uid, CHUser.UserID);
				ts.Complete();
				if (r)	return Content("已经忽略了请求");
				return Content("请求已经处理过了");
			}
		}
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult IgnoreAll() {//添加好友
			using (var ts = new TransactionScope())
			{
				DbExt.Friend.IgnoreAll(CHUser.UserID);
				ts.Complete();
				return Content("已经忽略所有请求");
			}
		}
		#endregion
	}
}
