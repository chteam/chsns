using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CHSNS.Model;

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
		                     OwnerId = userid.Value,
		                     ViewerId = CHUser.UserID
		                 };
		    DbExt.View.Update(0, up.OwnerId,CHUser);

		    var user = DbExt.UserInfo.UserInformation(up.OwnerId);
		    if (user != null)
		    {
		        up.Profile = user.Profile;
		        up.Basic = user.Basic;
		        up.Relation = DbExt.UserInfo.Relation(up.OwnerId, up.ViewerId);
		    }
		    ViewData["event"] = DbExt.Event.GetEvent(up.OwnerId, 1, 10);
		    ViewData["lastview"] = DbExt.View.ViewList(0, 3, up.OwnerId, 6);
		    ViewData["lastfriend"] = DbExt.View.ViewList(2, 3, up.OwnerId, 6);
		    ViewData["replylist"] = DbExt.Comment.GetReply(up.OwnerId, 1, 10);

		    if (!up.Exists) return View(up);
		    up.IsOnline = CHContext.Online.Items.ContainsKey(up.OwnerId);
		    Title = up.Profile.Name + "的页面";
		    return View(up);
		}

	    #region Method
		[AcceptVerbs("post")]
		public ActionResult EventDelete(long id) {
			DbExt.Event.Delete(id, CHUser.UserID);
			return View("Index/Event", DbExt.Event.GetEvent(CHUser.UserID,1, 10));
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
			var bi = DbExt.UserInfo.GetBaseInfo(CHUser.UserID);
			var li = ConfigSerializer.Load<List<ListItem>>("Sex");
			var sl=ConfigSerializer.Load<List<ListItem>>("ShowLevel");
			ViewData["b"] = bi;
			ViewData["b.Sex"] = new SelectList(li, "Value", "Text", bi.Sex);
			ViewData["b.ProvinceID"] = new SelectList(DbExt.Golbal.Provinces(CHContext), "ID", "Name", bi.ProvinceId);
			ViewData["b.CityID"] = new SelectList(DbExt.Golbal.GetCitys(CHContext,bi.ProvinceId), "ID", "Name", bi.CityId);
			ViewData["b.Birthday"] = (bi.Birthday ?? DateTime.Now).ToString("MM/dd/yyyy").Replace("-", "/");
			ViewData["b.ShowLevel"] = new SelectList(sl, "Value", "Text", bi.ShowLevel);
			return View();
		}
		[AcceptVerbs("Post")]
		[LoginedFilter]
        public ActionResult SaveBaseInfo(BasicInformationImplement b) {
			DbExt.UserInfo.SaveBaseInfo(b,CHContext);
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
			ViewData["magicbox"] = DbExt.UserInfo.GetMagicBox(CHUser.UserID);
			return View();
		}
		[AcceptVerbs("Post")]
		[LoginedFilter]
		public ActionResult SaveMagicBox(string magicbox)
		{
			if (magicbox.ToLower() == "backup") {
				throw new NotImplementedException();
			}
			DbExt.UserInfo.SaveMagicBox(magicbox, CHUser.UserID);
			return Content("");
		}
		
		public ActionResult Upload() {
			return View();
		}
        [LoginedFilter]
        public ActionResult DeleteFace(){
           
            DbExt.UserInfo.DeleteFace(CHUser.UserID, "");
            var path = Path.FaceMapPath(CHUser.UserID);
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