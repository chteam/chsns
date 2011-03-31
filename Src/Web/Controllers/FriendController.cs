

namespace CHSNS.Controllers {
    using System;
    using System.Linq;
    using System.Transactions;
    using System.Web.Mvc;
    using CHSNS.ViewModel;

    public partial class FriendController : BaseController
    {
        #region Action
        public virtual ActionResult Random()
        {
            ViewData["source"] = DataManager.Friend.GetRandoms(10);
            return View();
        }
        [Authorize]
        public virtual ActionResult Index(int? p, long? userid)
        {
            if (!userid.HasValue || userid == 0) userid = CHUser.UserId;
            InitPage(ref p);
            var b = DataManager.Friend.UserFriendInfo(userid.Value);
            if (b == null) throw new ApplicationException("�û�������");
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
            var profile = DataManager.Friend.UserFriendInfo(CHUser.UserId);
            if (profile == null) throw new ApplicationException("�û�������");
            var items = DataManager.Friend.GetRequests(CHUser.UserId, p.Value, CHContext.Site);
            Title = profile.Name + "�ĺ�������";
            ViewBag.Items = items;
            ViewBag.Profile = profile;
            return View();

        }

        #endregion

        #region pager ctrl
        [Authorize]
        [HttpPost]
        public virtual ActionResult FriendList(int p, long userid)
        {
            var list = DataManager.Friend.GetFriends(userid, p, CHContext.Site);
            ViewData["PageCount"] = list.TotalPages;
            return View(list);
        }
        [Authorize]
        [HttpPost]
        public virtual ActionResult RequestList(int p, long userid)
        {
            return View(DataManager.Friend.GetRequests(userid, p, CHContext.Site));
        }
        [Authorize]
        [HttpPost]
        public virtual ActionResult RandomList()
        {
            return View(DataManager.Friend.GetRandoms(10));
        }
        #endregion

        #region ajax execute
        [Authorize]
        [HttpPost]
        public virtual ActionResult Add(long toid)
        {//��Ӻ���
            using (var ts = new TransactionScope())
            {
                var x = DataManager.Friend.Add(CHUser.UserId, toid);
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
                DataManager.Friend.Delete(CHUser.UserId, toid);
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
                var r = DataManager.Friend.Agree(CHUser.UserId, uid,CHUser);
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
                var r=DataManager.Friend.Ignore(uid, CHUser.UserId);
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
                DataManager.Friend.IgnoreAll(CHUser.UserId);
                ts.Complete();
                return Content("�Ѿ�������������");
            }
        }
        #endregion
    }
}
