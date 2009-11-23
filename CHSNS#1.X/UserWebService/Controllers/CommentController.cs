
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using Chsword;
namespace CHSNS.Controllers {
	[LoginedFilter]
	public class CommentController : BaseController
	{
		public ActionResult List(){
			if (this.QueryLong("userid") == 0)
				ViewData.Add("Ownerid", ChUser.Current.Userid);
			else
				ViewData.Add("Ownerid", this.QueryLong("userid"));
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("@OwnerId",ViewData["Ownerid"]);
			dict.Add("@ViewerId",ChUser.Current.Userid);

			DoDataBase base2 = new DoDataBase();
			DataTable dt = base2.GetDataTable("UserRelation", dict);

			ViewData.Add("Username", dt.Rows[0]["Name"]);
			ViewData.Add("Relation", dt.Rows[0]["Relation"]);
			ViewData.Add("AllShowLevel", dt.Rows[0]["AllShowLevel"]);
			return View();
		}
	}
}
