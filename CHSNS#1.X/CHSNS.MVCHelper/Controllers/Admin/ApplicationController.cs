﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CHSNS.Config;

namespace CHSNS.Controllers.Admin {
	public class ApplicationController :BaseController{
		public ActionResult Manage(int? p) {
			InitPage(ref p);
			Title = "应用程序管理";
			var ais = ConfigSerializer.Load<SystemApplicationConfig>("SystemApplication");
			var li = new PagedList<ApplicationItem>(ais.Items, p.Value, 10);
			return View(li);
		}
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Edit()
		{
			return View();
		}
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Edit(ApplicationItem app) {
			Title = app.FullName;
			app.AddTime = DateTime.Now;
			app.UpdateTime = DateTime.Now;
			app.UserCount = 0;
			app.IsTrue=true;
			var ais = ConfigSerializer.Load<SystemApplicationConfig>("SystemApplication", false);
			ais.Items.Add(app);
			ConfigSerializer.Serializer(ais, "SystemApplication");
			return RedirectToAction("Manage");
		}
		public ActionResult Delete(string id)
		{
			HttpContext.Application.Lock();
			var ais = ConfigSerializer.Load<SystemApplicationConfig>("SystemApplication", false);
			var item = ais.Items.Where(c => c.ID == id.Trim()).FirstOrDefault();
			ais.Items.Remove(item);
			ConfigSerializer.Serializer(ais, "SystemApplication");
			HttpContext.Application.UnLock();
			return this.RedirectToReferrer();
		}
	}
}