﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CHSNS.Models;
using System.Runtime.Serialization.Json;

namespace CHSNS.Controllers.SystemApplication {
	/// <summary>
	/// 系统应用之基本设置
	/// </summary>
	[LoginedFilter]
	public class BaseInfoController : Controller {
		public ActionResult Setting() {
			BaseInfo bi = DBExt.BaseInfo(CHUser.UserID);
			List<ListItem> li = ConfigSerializer.Load<List<ListItem>>("Sex");
			ViewData["Name"] = bi.Name;
			ViewData["Sex"] = new SelectList(li, "Value", "Text", bi.Sex);
			ViewData["ProvinceID"] = new SelectList(DBExt.Provinces, "ID", "Name", bi.ProvinceID);
			ViewData["CityID"] = new SelectList(DBExt.GetCitys(bi.ProvinceID.Value), "ID", "Name", bi.CityID);
			ViewData["Birthday"] = bi.Birthday.Value.ToString("MM/dd/yyyy").Replace("-", "/");
			return View();
		}
		[PostOnlyFilter]
		public ActionResult AjaxSave() {
			BaseInfo bi = new BaseInfo();
			BindingHelperExtensions.UpdateFrom(bi, Request.Form);
			bi.UserID = CHUser.UserID;
			DBExt.BaseInfo_Save(bi);
			return Content("");
		}
	}
}
