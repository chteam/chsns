using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.Abstractions;

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
		    userid = userid ?? CHUser.UserID;
		    var up = new UserPas
		                 {
		                     OwnerID = userid.Value,
		                     ViewerID = CHUser.UserID
		                 };
		    DBExt.View.Update(0, up.OwnerID,CHUser);



		    var user = DBExt.UserInfo.UserInformation(up.OwnerID);
		    if (user != null)
		    {
		        up.Profile = user.Profile;
		        up.Basic = user.Basic;
		        up.Relation = DBExt.UserInfo.Relation(up.OwnerID, up.ViewerID);
		    }
		    ViewData["event"] = DBExt.Event.GetEvent(up.OwnerID, 1, 10);
		    ViewData["lastview"] = DBExt.View.ViewList(0, 3, up.OwnerID, 6);
		    ViewData["lastfriend"] = DBExt.View.ViewList(2, 3, up.OwnerID, 6);
		    ViewData["replylist"] = DBExt.Comment.GetReply(up.OwnerID, 1, 10);

		    if (!up.Exists) return View(up);
		    up.IsOnline = CHContext.Online.Items.ContainsKey(up.OwnerID);
		    Title = up.Profile.Name + "的页面";
		    return View(up);
		}

	    #region Method
		[AcceptVerbs("post")]
		public ActionResult EventDelete(long id) {
			DBExt.Event.Delete(id, CHUser.UserID);
			return View("Index/Event", DBExt.Event.GetEvent(CHUser.UserID,1, 10));
		}
		#endregion

		/// <summary>
		/// 设置个人信息
		/// </summary>
		/// <param name="mode"></param>
		/// <returns></returns>
		[LoginedFilter]
		public ActionResult Edit(string mode) {
			ViewData["mode"] = string.IsNullOrEmpty(mode) ? "baseinfo" : mode.ToLower();
			var ml = ConfigSerializer.Load<List<ListItem>>("UserEditMenu");
			ViewData["menulist"] = ml;
			Title = "个人信息";
			return View();
		}
		#endregion
		#region 控件
		[LoginedFilter]
		public ActionResult BaseInfo() {
			var bi = DBExt.UserInfo.GetBaseInfo(CHUser.UserID);
			var li = ConfigSerializer.Load<List<ListItem>>("Sex");
			var sl=ConfigSerializer.Load<List<ListItem>>("ShowLevel");
			ViewData["b"] = bi;
			ViewData["b.Sex"] = new SelectList(li, "Value", "Text", bi.Sex);
			ViewData["b.ProvinceID"] = new SelectList(DBExt.Golbal.Provinces(CHContext), "ID", "Name", bi.ProvinceID);
			ViewData["b.CityID"] = new SelectList(DBExt.Golbal.GetCitys(CHContext,bi.ProvinceID), "ID", "Name", bi.CityID);
			ViewData["b.Birthday"] = (bi.Birthday ?? DateTime.Now).ToString("MM/dd/yyyy").Replace("-", "/");
			ViewData["b.ShowLevel"] = new SelectList(sl, "Value", "Text", bi.ShowLevel);
			return View();
		}
		[AcceptVerbs("Post")]
		[LoginedFilter]
        public ActionResult SaveBaseInfo(BasicInformationImplement b) {
			DBExt.UserInfo.SaveBaseInfo(b,CHContext);
			return Content("");
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
			ViewData["magicbox"] = DBExt.UserInfo.GetMagicBox(CHUser.UserID);
			return View();
		}
		[AcceptVerbs("Post")]
		[LoginedFilter]
		public ActionResult SaveMagicBox(string magicbox)
		{
			if (magicbox.ToLower() == "backup") {
				throw new NotImplementedException();
			}
			DBExt.UserInfo.SaveMagicBox(magicbox, CHUser.UserID);
			return Content("");
		}
		
		public ActionResult Upload() {
			return View();
		}
		[LoginedFilter]
		public ActionResult DeleteFace()
		{
			DBExt.UserInfo.DeleteFace(CHUser.UserID);
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