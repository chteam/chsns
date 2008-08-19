namespace ChAlumna.Controllers {
	using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Castle.MonoRail.Framework;
using Chsword;
using ChAlumna;
	[Filter(ExecuteEnum.BeforeAction, typeof(PublicFilter))]
	public class servicesController : BaseController {
		public void index() { 
			Services  se =new Services();
			ViewData.Add("table", se.ServicesTable(1, 20, 0, "").Rows);
			ViewData.Add("count",se.ServicesCount());
		}
		public void admin(){
			if(!ChSession.isAdmin)
				Redirect("/");
		}
		public void reply(long serid,string serbody){
			if(!ChSession.isAdmin)
				Redirect("/");
			DoDataBase ddb=new DoDataBase();
			ddb.Executer_SqlText(
				string.Format("UPDATE [Services] set [Answer]='{0}',[Answertime] = getdate(),[status] =255 where id={1}",
				              serbody.Trim(),
				              serid
				 )
			);
			RedirectToAction("index", ""); 
		}
	}
}
