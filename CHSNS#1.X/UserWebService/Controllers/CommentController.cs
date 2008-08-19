namespace ChAlumna.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	
	using Chsword;
	using Castle.MonoRail.Framework;
	[Filter(ExecuteEnum.BeforeAction, typeof(LoginedFilter))]
	public class CommentController : BaseController
	{
		public void List(){
			if (QueryLong("userid") == 0)
				ViewData.Add("Ownerid", ChUser.Current.Userid);
			else
				ViewData.Add("Ownerid", QueryLong("userid"));
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("@OwnerId",ViewData["Ownerid"]);
			dict.Add("@ViewerId",ChUser.Current.Userid);

			DoDataBase base2 = new DoDataBase();
			DataTable dt = base2.GetDataTable("UserRelation", dict);

			ViewData.Add("Username", dt.Rows[0]["Name"]);
			ViewData.Add("Relation", dt.Rows[0]["Relation"]);
			ViewData.Add("AllShowLevel", dt.Rows[0]["AllShowLevel"]);
			
		}
	}
}
