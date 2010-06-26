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
            if (b == null) throw new Exception("�û�������");
            ViewData["UserId"] = userid;
            ViewData["Name"] = b.Name;
            ViewData["NowPage"] = p;
            //	ViewData["PageCount"] = b.FriendCount;
            Title = b.Name + "�ĺ���";
            return FriendList(p.Value, userid.Value);
        }

        [Authorize]
        [ActionName("Request")]
        public virtual ActionResult RequestHack(int? p)
        {
            InitPage(ref p);
            var profile = DataExt.Friend.UserFriendInfo(CHUser.UserId);
            if (profile == null) throw new Exception("�û�������");
            var items = DataExt.Friend.GetRequests(CHUser.UserId, p.Value, CHContext.Site);
            Title = profile.Name + "�ĺ�������";
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
		{//��Ӻ���
			using (var ts = new TransactionScope())
			{
				var x = DataExt.Friend.Add(CHUser.UserId, toid);
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
		[Authorize]
		[HttpPost]
        public virtual ActionResult Delete(long toid)
        {
			using (var ts = new TransactionScope())
			{
				DataExt.Friend.Delete(CHUser.UserId, toid);
				ts.Complete();
				return Content("�����ϵ�ɹ�");
			}
		}
		[Authorize]
		[HttpPost]
        public virtual ActionResult Agree(long uid)
		{//��Ӻ���
			using (var ts = new TransactionScope())
			{
				var r = DataExt.Friend.Agree(CHUser.UserId, uid,CHUser);
				ts.Complete();
				if (r) return Content("�Ѿ��ӶԷ�Ϊ����");
				return Content("�����Ѿ��������");
			}
		}
		[Authorize]
		[HttpPost]
        public virtual ActionResult Ignore(long uid)
        {//��Ӻ���
			using (var ts = new TransactionScope())
			{
				var r=DataExt.Friend.Ignore(uid, CHUser.UserId);
				ts.Complete();
				if (r)	return Content("�Ѿ�����������");
				return Content("�����Ѿ��������");
			}
		}
		[Authorize]
		[HttpPost]
        public virtual ActionResult IgnoreAll()
        {//��Ӻ���
			using (var ts = new TransactionScope())
			{
				DataExt.Friend.IgnoreAll(CHUser.UserId);
				ts.Complete();
				return Content("�Ѿ�������������");
			}
		}
		#endregion
	}
}
