
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using Chsword;
using CHSNS.Models;
using System;
namespace CHSNS.Controllers {
	[LoginedFilter]
	public class CommentController : BaseController
	{
		public ActionResult List(){
			if (this.QueryLong("userid") == 0)
				ViewData.Add("Ownerid", CHSNSUser.Current.UserID);
			else
				ViewData.Add("Ownerid", this.QueryLong("userid"));
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("@OwnerId",ViewData["Ownerid"]);
			dict.Add("@ViewerId",CHSNSUser.Current.UserID);

			DoDataBase base2 = new DoDataBase();
			DataTable dt = base2.GetDataTable("UserRelation", dict);

			ViewData.Add("Username", dt.Rows[0]["Name"]);
			ViewData.Add("Relation", dt.Rows[0]["Relation"]);
			ViewData.Add("AllShowLevel", dt.Rows[0]["AllShowLevel"]);
			return View();
		}
		public ActionResult ShowList(byte type,int NPage,int EPage,long NoteID,long OwnerID,string CountElem) {
			CommentListPas cl = new CommentListPas() { 
			ShowType=type,
			OwnerID=OwnerID,
			Nowpage=NPage,
			EveryPage=EPage,
			NoteID=NoteID,
			CountElement=CountElem
			};
			cl.Count = Convert.ToInt64(DataBaseExecutor.ExecuteScalar("CommentCount", "@id", OwnerID, "@type", type));
			cl.Rows = DataBaseExecutor.GetRows("CommentSelect"
				, "@ownerid", OwnerID
				, "@page", NPage
				, "@everyPage", EPage
				, "@type", type
				, "@logid", NoteID
			);
			return View(cl);
		}
	}
}
