using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Chsword;
using CHSNS;
using System.Web.Mvc;
namespace CHSNS.Controllers {


	public class ServicesController : BaseController {
		public ActionResult Index() { 
			Services  se =new Services();
			ViewData.Add("table", se.ServicesTable(1, 20, 0, "").Rows);
			ViewData.Add("count",se.ServicesCount());
			return View();
		}
		public ActionResult Admin() {
			if(!ChSession.isAdmin)
				Redirect("/");
			return View();
		}
		public ActionResult Reply(long serid, string serbody) {
			if(!ChSession.isAdmin)
				Redirect("/");
			DoDataBase ddb=new DoDataBase();
			ddb.Executer_SqlText(
				string.Format("UPDATE [Services] set [Answer]='{0}',[Answertime] = getdate(),[status] =255 where id={1}",
				              serbody.Trim(),
				              serid
				 )
			);
			return RedirectToAction("index", ""); 
		}
	}
}
