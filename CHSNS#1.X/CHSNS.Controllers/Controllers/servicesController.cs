
using System.Web.Mvc;
using Chsword;
namespace CHSNS.Controllers {


	public class ServicesController : BaseController {
		public ActionResult Index() { 
			Services  se =new Services();
			ViewData.Add("table", se.ServicesTable(1, 20, 0, "").Rows);
			ViewData.Add("count",se.ServicesCount());
			return View();
		}
		public ActionResult Admin() {
			if(!CHUser.IsAdmin)
				Redirect("/");
			return View();
		}
		public ActionResult Reply(long serid, string serbody) {
			if(!CHUser.IsAdmin)
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
