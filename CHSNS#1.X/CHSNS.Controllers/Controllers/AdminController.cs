using System.Collections.Generic;
using CHSNS.Config;
using CHSNS.Filter;
using System.Web.Mvc;

namespace CHSNS.Controllers {
	[AdminFilter]
	public class AdminController : BaseController {
		public ActionResult Index() {
			Title = "CHSNS#管理平台首页";
			return View();
		}

		public ActionResult ApplicationManagement(int? p)
		{
			InitPage(ref p);
			Title = "应用程序管理";
			var ais = new SystemApplicationConfig();
			var items = new List<ApplicationItem>();
			for (int i = 0; i < 2; i++)
				items.Add(new ApplicationItem
				          	{
				          		ID = i.ToString(),
				          		FullName = i.ToString(),
				          	});
			ais.Items = items;
			var li = new PagedList<ApplicationItem>(ais.Items, p.Value, 10);
			ConfigSerializer.Serializer(ais, "SystemApplication");
			return View(li);
		}

		public ActionResult About() {
			return View();
		}
	}
}
