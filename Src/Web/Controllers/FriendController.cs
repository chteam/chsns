using System.Transactions;
using CHSNS.ViewModel;

namespace CHSNS.Controllers {
	using System;
	using System.Linq;
	using System.Web.Mvc;

    public partial class FriendController : BaseController
    {
		#region Action
        public virtual ActionResult Random()
        {
			ViewData["source"] = DataExt.Friend.GetRandoms(10);
			return View();
		}
        [Authorize]
        public virtual ActionResult Index(int? p, long? userid)
        {
            if (!userid.HasValue || userid == 0) userid = CHUser.UserId;
            InitPage(ref p);
            var b = DataExt.Friend.UserFriendInfo(userid.Value);
            if (b == null) throw new Exception("用户不存在");
            ViewData["UserId"] = userid;
            ViewData["Name"] = b.Name;
            ViewData["NowPage"] = p;
            //	ViewData["PageCount"] = b.FriendCount;
            Title = b.Name + "的好友";
            return FriendList(p.Value, userid.Value);
        }

        [Authorize]
        [ActionName("Request")]
        public virtual ActionResult RequestHack(int? p)
        {
            InitPage(ref p);
            var profile = DataExt.Friend.UserFriendInfo(CHUser.UserId);
            if (profile == null) throw new Exception("用户不存在");
            var items = DataExt.Friend.GetRequests(CHUser.UserId, p.Value, CHContext.Site);
            Title = profile.Name + "的好友请求";
            return View(new FriendRequest { Items = items, Profile = profile });

        }

	    #endregion
		#region pager ctrl
        [Authorize]
        [HttpPost]
        public virtual ActionResult FriendList(int p, long userid)
        {
            var list = DataExt.Friend.GetFriends(userid, p, CHContext.Site);
            ViewData["PageCount"] = list.TotalPages;
            return View(list);
        }
		[Authorize]
		[HttpPost]
        public virtual ActionResult RequestList(int p, long userid)
        {
            return View(DataExt.Friend.GetRequests(userid, p, CHContext.Site));
		}
		[Authorize]
		[HttpPost]
        public virtual ActionResult RandomList()
        {
			return View(DataExt.Friend.GetRandoms(10));
		}
		#endregion

		#region ajax execute
		[Authorize]
		[HttpPost]
        public virtual ActionResult Add(long toid)
		{//添加好友
			using (var ts = new TransactionScope())
			{
				var x = DataExt.Friend.Add(CHUser.UserId, toid);
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
		[Authorize]
		[HttpPost]
        public virtual ActionResult Delete(long toid)
        {
			using (var ts = new TransactionScope())
			{
				DataExt.Friend.Delete(CHUser.UserId, toid);
				ts.Complete();
				return Content("解除关系成功");
			}
		}
		[Authorize]
		[HttpPost]
        public virtual ActionResult Agree(long uid)
		{//添加好友
			using (var ts = new TransactionScope())
			{
				var r = DataExt.Friend.Agree(CHUser.UserId, uid,CHUser);
				ts.Complete();
				if (r) return Content("已经加对方为好友");
				return Content("请求已经处理过了");
			}
		}
		[Authorize]
		[HttpPost]
        public virtual ActionResult Ignore(long uid)
        {//添加好友
			using (var ts = new TransactionScope())
			{
				var r=DataExt.Friend.Ignore(uid, CHUser.UserId);
				ts.Complete();
				if (r)	return Content("已经忽略了请求");
				return Content("请求已经处理过了");
			}
		}
		[Authorize]
		[HttpPost]
        public virtual ActionResult IgnoreAll()
        {//添加好友
			using (var ts = new TransactionScope())
			{
				DataExt.Friend.IgnoreAll(CHUser.UserId);
				ts.Complete();
				return Content("已经忽略所有请求");
			}
		}
		#endregion
	}
}
