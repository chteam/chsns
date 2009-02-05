using System;
using System.Web.Mvc;
using CHSNS.Models;

namespace CHSNS.Controllers
{
	
	public class VideoController : BaseController
	{
		[LoginedFilter]
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Edit(){
			Title = "提交视频";
			return View();
		}
		[LoginedFilter]
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Edit(SuperNote v){
			v.AddTime = DateTime.Now;
			var m = new Media(v.Url);
			v.Title = v.Title ?? m.Title;
			v.Faceurl = m.Pic;
			v.UserID = CHUser.UserID;
			DBExt.DB.SuperNote.InsertOnSubmit(v);
			DBExt.DB.SubmitChanges();
			Message = "提交成功";
			return Edit();
		}

		public ActionResult List() {
			//SuperNoteList snl = new SuperNoteList();
			//snl.Everypage = 10;
			//snl.Nowpage = 1;
			//snl.Template = "supernotepage";
			//snl.Userid = this.QueryLong("userid") == 0
			//    ? CHSNSUser.Current.UserID : this.QueryLong("userid");
			//ViewData["page"] = snl.CreateUserSuperNote().ToString();
			return View();
		}
		public ActionResult Random() {
			//SuperNoteList snl = new SuperNoteList();
			//snl.Everypage = 10;
			//snl.Nowpage = 1;
			//snl.Template = "SuperNoteRandomPage";

			//snl.Type = 1;
			//snl.Userid = CHUser.UserID;

			//ViewData["page"] = snl.CreateUserSuperNote().ToString();
			return View();
		}
	}
}
