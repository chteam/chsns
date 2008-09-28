using System.Collections.Generic;
using System.Transactions;
using System.Web.Mvc;
using CHSNS.Extension;
using CHSNS.Filter;
using CHSNS.Models;
using CHSNS.Tools;
using Newtonsoft.Json;
using System.Data.EntityClient;
using System;
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
		public ActionResult Index() {
			var up = new UserPas {
				OwnerID = this.QueryLong("userid"),
				ViewerID = CHSNSUser.Current.UserID
			};
			using (var ts = DBExt.ExeTransaction()) {
				DBExt.View.ViewCreate(0, 3, up.OwnerID);
				ts.Commit();
			}

			using (var ts = DBExt.ContextTransaction()) {
				var user = DBExt.UserInfo.UserInformation(up.OwnerID);
				if (user != null) {
					up.Profile = user.Profile;
					up.Basic = user.Basic;
					up.Relation = DBExt.UserInfo.Relation(up.OwnerID, up.ViewerID);
				}
				ViewData["event"] = DBExt.Event.GetEvent(up.OwnerID).Pager(1, 10);
				ViewData["lastview"] = DBExt.View.ViewList(0, 3, up.OwnerID, 6);
				ViewData["lastfriend"] = DBExt.View.ViewList(2, 3, up.OwnerID, 6);
				ViewData["replylist"] = DBExt.Comment.GetReply(up.OwnerID).Pager(1, 10);
				ts.Commit();
			}
			if (!up.Exists) return View(up);
			up.IsOnline = Online.OnlineList.ContainsKey(up.OwnerID);
			ViewData["Page_Title"] = up.Profile.Name + "的页面";
			return View(up);
		}

		#region Method
		[AcceptVerbs("post")]
		public ActionResult EventDelete(long id) {
			DBExt.Event.Delete(id, CHUser.UserID);
			return View("Index/Event", DBExt.Event.GetEvent(CHUser.UserID).Pager(1, 10));
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
			ViewData["Page_Title"] = "个人信息";
			return View();
		}
		#endregion
		#region 控件
		[LoginedFilter]
		public ActionResult BaseInfo() {
			var bi = DBExt.UserInfo.GetBaseInfo(CHUser.UserID);
			var li = ConfigSerializer.Load<List<ListItem>>("Sex");
			var sl=ConfigSerializer.Load<List<ListItem>>("ShowLevel");
			ViewData["Name"] = bi.Name;
			ViewData["Sex"] = new SelectList(li, "Value", "Text", bi.Sex);
			ViewData["ProvinceID"] = new SelectList(DBExt.Golbal.Provinces, "ID", "Name", bi.ProvinceID);
			ViewData["CityID"] = new SelectList(DBExt.Golbal.GetCitys(bi.ProvinceID), "ID", "Name", bi.CityID);
			ViewData["Birthday"] = bi.Birthday.Value.ToString("MM/dd/yyyy").Replace("-", "/");
			ViewData["ShowLevel"] = new SelectList(sl, "Value", "Text", bi.ShowLevel);
			return View();
		}
		[AcceptVerbs("Post")]
		[LoginedFilter]
		public ActionResult SaveBaseInfo() {
			var bi = new BasicInformation();
			UpdateModel(bi, Request.Form.AllKeys);
			bi.UserID = CHUser.UserID;
			DBExt.UserInfo.SaveBaseInfo(bi);
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
				throw new System.NotImplementedException();
			} else
			{
				DBExt.UserInfo.SaveMagicBox(magicbox, CHUser.UserID);
			}
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