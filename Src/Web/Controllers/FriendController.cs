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
            if (!userid.HasValue || userid == 0) userid = CHUser.UserId;
            InitPage(ref p);
            var b = DbExt.Friend.UserFriendInfo(userid.Value);
            if (b == null) throw new Exception("�û�������");
            ViewData["UserId"] = userid;
            ViewData["Name"] = b.Name;
            ViewData["NowPage"] = p;
            //	ViewData["PageCount"] = b.FriendCount;
            Title = b.Name + "�ĺ���";
            return FriendList(p.Value, userid.Value);
        }

        [LoginedFilter]
        [ActionName("Request")]
        public ActionResult RequestHack(int? p)
        {
            InitPage(ref p);
            var profile = DbExt.Friend.UserFriendInfo(CHUser.UserId);
            if (profile == null) throw new Exception("�û�������");
            var items = DbExt.Friend.GetRequests(CHUser.UserId, p.Value, CHContext.Site);
            Title = profile.Name + "�ĺ�������";
            return View(new FriendRequest { Items = items, Profile = profile });

        }

	    #endregion
		#region pager ctrl
        [LoginedFilter]
        [HttpPost]
        public ActionResult FriendList(int p, long userid)
        {
            var list = DbExt.Friend.GetFriends(userid, p, CHContext.Site);
            ViewData["PageCount"] = list.TotalPages;
            return View(list);
        }
		[LoginedFilter]
		[HttpPost]
		public ActionResult RequestList(int p, long userid) {
            return View(DbExt.Friend.GetRequests(userid, p, CHContext.Site));
		}
		[LoginedFilter]
		[HttpPost]
		public ActionResult RandomList() {
			return View(DbExt.Friend.GetRandoms(10));
		}
		#endregion

		#region ajax execute
		[LoginedFilter]
		[HttpPost]
		public ActionResult Add(long toid)
		{//��Ӻ���
			using (var ts = new TransactionScope())
			{
				var x = DbExt.Friend.Add(CHUser.UserId, toid);
				ts.Complete();
				if (x) return Content("�Ѿ���Է���������");
				return Content("�Է��Ѿ�����ĺ���");
			}
		}
		/// <summary>
		/// ɾ��
		/// </summary>
		/// <param name="toid"></param>
		/// <returns></returns>
		[LoginedFilter]
		[HttpPost]
		public ActionResult Delete(long toid) {
			using (var ts = new TransactionScope())
			{
				DbExt.Friend.Delete(CHUser.UserId, toid);
				ts.Complete();
				return Content("�����ϵ�ɹ�");
			}
		}
		[LoginedFilter]
		[HttpPost]
		public ActionResult Agree(long uid)
		{//��Ӻ���
			using (var ts = new TransactionScope())
			{
				var r = DbExt.Friend.Agree(CHUser.UserId, uid,CHUser);
				ts.Complete();
				if (r) return Content("�Ѿ��ӶԷ�Ϊ����");
				return Content("�����Ѿ��������");
			}
		}
		[LoginedFilter]
		[HttpPost]
		public ActionResult Ignore(long uid) {//��Ӻ���
			using (var ts = new TransactionScope())
			{
				var r=DbExt.Friend.Ignore(uid, CHUser.UserId);
				ts.Complete();
				if (r)	return Content("�Ѿ�����������");
				return Content("�����Ѿ��������");
			}
		}
		[LoginedFilter]
		[HttpPost]
		public ActionResult IgnoreAll() {//��Ӻ���
			using (var ts = new TransactionScope())
			{
				DbExt.Friend.IgnoreAll(CHUser.UserId);
				ts.Complete();
				return Content("�Ѿ�������������");
			}
		}
		#endregion
	}
}
