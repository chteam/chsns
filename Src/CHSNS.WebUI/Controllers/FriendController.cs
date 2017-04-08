

namespace CHSNS.Controllers {
    using System;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Transactions;
    using System.Web.Mvc;
    using CHSNS.Service;
    using CHSNS.ViewModel;

    public partial class FriendController : BaseController
    {
        [Import]
        public FriendService Friend { get; set; }
        #region Action
        public virtual ActionResult Random()
        {
            ViewData["source"] = Friend.GetRandoms(10);
            return View();
        }
        [Authorize]
        public virtual ActionResult Index(int? p, long? userid)
        {
            if (!userid.HasValue || userid == 0) userid = WebUser.UserId;
            InitPage(ref p);
            var b = Friend.UserFriendInfo(userid.Value);
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
            var profile = Friend.UserFriendInfo(WebUser.UserId);
            if (profile == null) throw new ApplicationException("�û�������");
            var items = Friend.GetRequests(WebUser.UserId, p.Value, WebContext.Site);
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
            var list = Friend.GetFriends(userid, p, WebContext.Site);
            ViewData["PageCount"] = list.TotalPages;
            return View(list);
        }
        [Authorize]
        [HttpPost]
        public virtual ActionResult RequestList(int p, long userid)
        {
            return View(Friend.GetRequests(userid, p, WebContext.Site));
        }
        [Authorize]
        [HttpPost]
        public virtual ActionResult RandomList()
        {
            return View(Friend.GetRandoms(10));
        }
        #endregion

        #region ajax execute
        [Authorize]
        [HttpPost]
        public virtual ActionResult Add(long toid)
        {//��Ӻ���
            using (var ts = new TransactionScope())
            {
                var x = Friend.Add(WebUser.UserId, toid);
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
                Friend.Delete(WebUser.UserId, toid);
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
                var r = Friend.Agree(WebUser.UserId, uid,WebUser);
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
                var r=Friend.Ignore(uid, WebUser.UserId);
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
                Friend.IgnoreAll(WebUser.UserId);
                ts.Complete();
                return Content("�Ѿ�������������");
            }
        }
        #endregion
    }
}
