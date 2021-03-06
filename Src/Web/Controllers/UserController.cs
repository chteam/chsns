using System;
using System.Web.Mvc;
using CHSNS.ViewModel;
using CHSNS.Models;
using CHSNS.Service;

namespace CHSNS.Controllers {
    using System.ComponentModel.Composition;

    /// <summary>
    /// the controller of /user/
    /// </summary>
    public partial class UserController : BaseController
    {
        [Import]
        public ViewLogService ViewLogLog { get; set; }
        [Import]
        public UserService UserInfo { get; set; }

        [Import]
        public EventLogService EventLog { get; set; }
        [Import]
        public CommentService Comment { get; set; }
        #region Action
        /// <summary>
        /// 个人主页
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Index(long? userId)
        {

            if (!userId.HasValue && WebUser == null)
                throw new ArgumentNullException("userId", @"当前用户不存在");
            userId = userId ?? WebUser.UserId;
            var up = new UserIndexViewModel
                         {
                             OwnerId = userId.Value,
                             ViewerId = WebUser.UserId
                         };
            ViewLogLog.Update(VisitLogType.Profile, up.OwnerId, WebUser);

            var user = UserInfo.UserInformation(up.OwnerId);
            if (user != null)
            {
                up.Profile = user.Profile;
                up.Basic = user.Basic;
                up.Relation = UserInfo.Relation(up.OwnerId, up.ViewerId);
            }
            ViewData["event"] = EventLog.GetEvent(up.OwnerId, 1, 10);
            ViewData["lastview"] = ViewLogLog.ViewList(0, 3, up.OwnerId, 6);
            ViewData["lastfriend"] = ViewLogLog.ViewList(2, 3, up.OwnerId, 6);
            ViewData["replylist"] = Comment.GetReply(up.OwnerId, 1, 10);

            if (!up.Exists) return View(up);
            up.IsOnline = OnlineProvider.Instance.Items.ContainsKey(up.OwnerId);
            Title = up.Profile.Name + "的页面";
            return View(up);
        }

        #region Method
        [HttpPost]
        [Authorize]
        public virtual ActionResult EventDelete(long id)
        {
            EventLog.Delete(id, WebUser.UserId);
            return View("Index/Event", EventLog.GetEvent(WebUser.UserId,1, 10));
        }
        #endregion


        [Authorize]
        public virtual ActionResult BaseInfo()
        {
            Title = "基本信息修改";
            var bi = UserInfo.GetBaseInfo(WebUser.UserId);
            ViewData["ProvinceId"] = new SelectList(GolbalService.Provinces, "ID", "Name", bi.ProvinceId);
            ViewData["CityId"] = new SelectList(GolbalService.GetCitys(bi.ProvinceId), "ID", "Name", bi.CityId);
            return View(bi);
        }
        [HttpPost]
        [Authorize]
        public virtual ActionResult BaseInfo(BasicInformation b)
        {
            UserInfo.SaveBaseInfo(b,WebContext);
            return RedirectToAction("BaseInfo");
        }
        [Authorize]
        public virtual ActionResult School()
        {
            return View();
        }
        [Authorize]
        public virtual ActionResult Contact()
        {
            return View();
        }
        [Authorize]
        public virtual ActionResult Personal()
        {
            return View();
        }
        //[Authorize]
        //public virtual ActionResult MagicBox()
        //{
        //    ViewData["magicbox"] = DataExt.UserInfo.GetMagicBox(CHUser.UserId);
        //    return View();
        //}
        //[HttpPost]
        //[Authorize]
        //public virtual ActionResult SaveMagicBox(string magicbox)
        //{
        //    if (magicbox.ToLower() == "backup") {
        //        throw new NotImplementedException();
        //    }
        //    DataExt.UserInfo.SaveMagicBox(magicbox, CHUser.UserId);
        //    return Content("");
        //}
        [Authorize]
        public virtual ActionResult Upload()
        {
            return View();
        }

        [Authorize]
        public virtual ActionResult DeleteFace()
        {
           
            UserInfo.DeleteFace(WebUser.UserId, "");
            var path = Path.FaceMapPath(WebUser.UserId);
            IOFactory.Folder.Delete(path, true);
            return Content("");
        }

        #endregion

        #region Management
        [AdminFilter]
        public virtual ActionResult ManageUser()
        {
            return View("Admin/ManageUser");
        }

        #endregion
    }
}
