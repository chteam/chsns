using System;
using System.Web.Mvc;
using CHSNS.ViewModel;
using CHSNS.Models;
using CHSNS.Service;

namespace CHSNS.Controllers {
    /// <summary>
    /// the controller of /user/
    /// </summary>
    public partial class UserController : BaseController
    {
        #region Action
        /// <summary>
        /// 个人主页
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Index(long? userId)
        {

            if (!userId.HasValue && CHUser == null)
                throw new ArgumentNullException("userId", @"当前用户不存在");
            userId = userId ?? CHUser.UserId;
            var up = new UserIndexViewModel
                         {
                             OwnerId = userId.Value,
                             ViewerId = CHUser.UserId
                         };
            ServicesFactory.View.Update(VisitLogType.Profile, up.OwnerId, CHUser);

            var user = ServicesFactory.UserInfo.UserInformation(up.OwnerId);
            if (user != null)
            {
                up.Profile = user.Profile;
                up.Basic = user.Basic;
                up.Relation = ServicesFactory.UserInfo.Relation(up.OwnerId, up.ViewerId);
            }
            ViewData["event"] = ServicesFactory.Event.GetEvent(up.OwnerId, 1, 10);
            ViewData["lastview"] = ServicesFactory.View.ViewList(0, 3, up.OwnerId, 6);
            ViewData["lastfriend"] = ServicesFactory.View.ViewList(2, 3, up.OwnerId, 6);
            ViewData["replylist"] = ServicesFactory.Comment.GetReply(up.OwnerId, 1, 10);

            if (!up.Exists) return View(up);
            up.IsOnline = OnlineFactory.Instance.Items.ContainsKey(up.OwnerId);
            Title = up.Profile.Name + "的页面";
            return View(up);
        }

        #region Method
        [HttpPost]
        [Authorize]
        public virtual ActionResult EventDelete(long id)
        {
            ServicesFactory.Event.Delete(id, CHUser.UserId);
            return View("Index/Event", ServicesFactory.Event.GetEvent(CHUser.UserId,1, 10));
        }
        #endregion


        [Authorize]
        public virtual ActionResult BaseInfo()
        {
            Title = "基本信息修改";
            var bi = ServicesFactory.UserInfo.GetBaseInfo(CHUser.UserId);
            ViewData["ProvinceId"] = new SelectList(GolbalService.Provinces, "ID", "Name", bi.ProvinceId);
            ViewData["CityId"] = new SelectList(GolbalService.GetCitys(bi.ProvinceId), "ID", "Name", bi.CityId);
            return View(bi);
        }
        [HttpPost]
        [Authorize]
        public virtual ActionResult BaseInfo(BasicInformation b)
        {
            ServicesFactory.UserInfo.SaveBaseInfo(b,CHContext);
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
           
            ServicesFactory.UserInfo.DeleteFace(CHUser.UserId, "");
            var path = Path.FaceMapPath(CHUser.UserId);
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
