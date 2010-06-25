using System;
using System.Web.Mvc;
using CHSNS.ViewModel;
using CHSNS.Models;

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
        public virtual ActionResult Index(long? userid)
		{
			userid = userid ?? CHUser.UserId;
			var up = new UserIndexViewModel
						 {
							 OwnerId = userid.Value,
							 ViewerId = CHUser.UserId
						 };
			DataExt.View.Update(0, up.OwnerId,CHUser);

			var user = DataExt.UserInfo.UserInformation(up.OwnerId);
			if (user != null)
			{
				up.Profile = user.Profile;
				up.Basic = user.Basic;
				up.Relation = DataExt.UserInfo.Relation(up.OwnerId, up.ViewerId);
			}
			ViewData["event"] = DataExt.Event.GetEvent(up.OwnerId, 1, 10);
			ViewData["lastview"] = DataExt.View.ViewList(0, 3, up.OwnerId, 6);
			ViewData["lastfriend"] = DataExt.View.ViewList(2, 3, up.OwnerId, 6);
			ViewData["replylist"] = DataExt.Comment.GetReply(up.OwnerId, 1, 10);

			if (!up.Exists) return View(up);
			up.IsOnline = CHContext.Online.Items.ContainsKey(up.OwnerId);
			Title = up.Profile.Name + "的页面";
			return View(up);
		}

		#region Method
		[HttpPost]
        public virtual ActionResult EventDelete(long id)
        {
			DataExt.Event.Delete(id, CHUser.UserId);
			return View("Index/Event", DataExt.Event.GetEvent(CHUser.UserId,1, 10));
		}
		#endregion


		[LoginedFilter]
        public virtual ActionResult BaseInfo()
		{
		    Title = "基本信息修改";
            var bi = DataExt.UserInfo.GetBaseInfo(CHUser.UserId);
			ViewData["ProvinceId"] = new SelectList(Global.Provinces, "ID", "Name", bi.ProvinceId);
            ViewData["CityId"] = new SelectList(Global.GetCitys( bi.ProvinceId), "ID", "Name", bi.CityId);
			return View(bi);
		}
		[HttpPost]
		[LoginedFilter]
        public virtual ActionResult BaseInfo(BasicInformation b)
        {
			DataExt.UserInfo.SaveBaseInfo(b,CHContext);
            return RedirectToAction("BaseInfo");
		}
		[LoginedFilter]
        public virtual ActionResult School()
        {
			return View();
		}
		[LoginedFilter]
        public virtual ActionResult Contact()
        {
			return View();
		}
		[LoginedFilter]
        public virtual ActionResult Personal()
        {
			return View();
		}
		[LoginedFilter]
        public virtual ActionResult MagicBox()
        {
			ViewData["magicbox"] = DataExt.UserInfo.GetMagicBox(CHUser.UserId);
			return View();
		}
		[HttpPost]
		[LoginedFilter]
        public virtual ActionResult SaveMagicBox(string magicbox)
		{
			if (magicbox.ToLower() == "backup") {
				throw new NotImplementedException();
			}
			DataExt.UserInfo.SaveMagicBox(magicbox, CHUser.UserId);
			return Content("");
		}

        public virtual ActionResult Upload()
        {
			return View();
		}
		[LoginedFilter]
        public virtual ActionResult DeleteFace()
        {
		   
			DataExt.UserInfo.DeleteFace(CHUser.UserId, "");
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
