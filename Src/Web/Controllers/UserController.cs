using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.ViewModel;
using CHSNS.Models;

namespace CHSNS.Controllers {
	/// <summary>
	/// the controller of /user/
	/// </summary>
	public class UserController : BaseController {
		#region Action
		/// <summary>
		/// 个人主页
		/// </summary>
		/// <returns></returns>
		public ActionResult Index(long? userid)
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
		public ActionResult EventDelete(long id) {
			DataExt.Event.Delete(id, CHUser.UserId);
			return View("Index/Event", DataExt.Event.GetEvent(CHUser.UserId,1, 10));
		}
		#endregion


		[LoginedFilter]
		public ActionResult BaseInfo()
		{
			var bi = DataExt.UserInfo.GetBaseInfo(CHUser.UserId);
			//var li = ConfigSerializer.Load<List<ListItem>>("Sex");
			//var sl = ConfigSerializer.Load<List<ListItem>>("ShowLevel");
			//ViewData["b"] = bi;
			//ViewData["b.Sex"] = new SelectList(li, "Value", "Text", bi.Sex);
			ViewData["ProvinceId"] = new SelectList(DataExt.Golbal.Provinces(CHContext), "ID", "Name",null);
            ViewData["CityId"] = new SelectList(DataExt.Golbal.GetCitys(CHContext, bi.ProvinceId), "ID", "Name",null);
			//ViewData["b.Birthday"] = (bi.Birthday ?? DateTime.Now).ToString("MM/dd/yyyy").Replace("-", "/");
			//ViewData["b.ShowLevel"] = new SelectList(sl, "Value", "Text", bi.ShowLevel);
			return View(bi);
		}
		[HttpPost]
		[LoginedFilter]
        public ActionResult BaseInfo(BasicInformation b)
        {
			DataExt.UserInfo.SaveBaseInfo(b,CHContext);
            return RedirectToAction("BaseInfo");
		}
		[LoginedFilter]
		public ActionResult School() {
			return View();
		}
		[LoginedFilter]
		public ActionResult Contact() {
			return View();
		}
		[LoginedFilter]
		public ActionResult Personal() {
			return View();
		}
		[LoginedFilter]
		public ActionResult MagicBox() {
			ViewData["magicbox"] = DataExt.UserInfo.GetMagicBox(CHUser.UserId);
			return View();
		}
		[HttpPost]
		[LoginedFilter]
		public ActionResult SaveMagicBox(string magicbox)
		{
			if (magicbox.ToLower() == "backup") {
				throw new NotImplementedException();
			}
			DataExt.UserInfo.SaveMagicBox(magicbox, CHUser.UserId);
			return Content("");
		}
		
		public ActionResult Upload() {
			return View();
		}
		[LoginedFilter]
		public ActionResult DeleteFace(){
		   
			DataExt.UserInfo.DeleteFace(CHUser.UserId, "");
			var path = Path.FaceMapPath(CHUser.UserId);
			IOFactory.Folder.Delete(path, true);
			return Content("");
		}

		#endregion

		#region Management
		[AdminFilter]
		public ActionResult ManageUser()
		{
			return View("Admin/ManageUser");
		}

		#endregion
	}
}