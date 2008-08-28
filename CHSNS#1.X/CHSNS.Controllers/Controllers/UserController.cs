using System.Collections.Generic;
using System.Web.Mvc;
using CHSNS.Models;
namespace CHSNS.Controllers {
	public class UserController : BaseController {
		#region Action
		/// <summary>
		/// 个人主页
		/// </summary>
		/// <returns></returns>
		public ActionResult Index() {
			var up = new UserPas
			         	{
			         		OwnerID = this.QueryLong("userid"),
			         		ViewerID = CHSNSUser.Current.UserID
			         	};
			var rows = DataBaseExecutor.GetRows("UserInformation", "@ownerid", up.OwnerID, "@viewerid", up.ViewerID);
			if (rows.Count > 0) up.User = rows[0];
			if (!up.Exists || !up.HasRight) {
				return View();
			}
			#region note
			//Chsword.Reader.LogBook ul = new Chsword.Reader.LogBook("FirstLogBook", up.OwnerID, up.ViewerID);
			//ViewData["log1source"] = ul.GetLogBookTable(1, 2).Rows;
			//ul = new Chsword.Reader.LogBook("SecondLogBook",
			//    long.Parse(dr["Userid"].ToString()));
			//ViewData["log2source"] = ul.GetLogBookTable(1, 3).Rows;
			#endregion
			up.IsOnline = Online.OnlineList.ContainsKey(up.OwnerID);
			ViewData["Title"] = up.OwnerName + "的页面";
			return View(up);
		}
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
		[PostOnlyFilter]
		[LoginedFilter]
		public ActionResult SaveBaseInfo() {
			var bi = new BasicInformation();
			BindingHelperExtensions.UpdateFrom(bi, Request.Form);
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
		[PostOnlyFilter]
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
		[LoginedFilter]
		public ActionResult Upload() {
			return View();
		}
		#endregion
	}
}