using System;

using System.Web.Mvc;
using CHSNS.Extension;
using CHSNS.Filter;
using CHSNS.Models;
using CHSNS.Tools;
namespace CHSNS.Controllers
{
	[LoginedFilter]
	public class NoteController : BaseController
	{
		public ActionResult Index(long? userid, int? p)
		{
			if (!userid.HasValue) userid = CHUser.UserID;
			if (!p.HasValue || p == 0) p = 1;
			var user = DBExt.UserInfo.GetUser(
				userid.Value,
				c => new UserCountPas
				{
					ID = c.UserID,
					Name = c.Name,
					Count = c.NoteCount
				});
			ViewData["username"] = user.Name;
			ViewData["userid"] = user.ID;
			ViewData["PageCount"] = user.Count;
			ViewData["NowPage"] = p.Value;
			return NoteList(p.Value, 10, userid.Value);
		}
		[AcceptVerbs("Post")]
		public ActionResult NoteList(int p, int ep, long userid)
		{
			return View(DBExt.Note.GetNotes(userid).Pager(p, ep));
		}
		public ActionResult Details(long id)
		{
			//var user = new UserItemPas();
			var note = DBExt.Note.Details(id);
			ViewData["Page_Title"] = note.Note.Title;
			return View(note);
		}
		public ActionResult Edit(long? id)
		{
			if (id.HasValue)
			{
				//编辑
				var mod = DBExt.Note.Details(id.Value).Note;
				ViewData["Title"] = mod.Title;
				ViewData["Body"] = mod.Body;
				ViewData["ID"] = id.Value;
				ViewData["Page_Title"] = "修改日志";
			}
			else
			{
				ViewData["Page_Title"] = "发新日志";
			}
			return View();
		}
		[AcceptVerbs("post")]
		public ActionResult Save(long? id)
		{
			var n = new Note();
			UpdateModel(n, new[] { "Title", "Body" });
			if (n.Title.Length < 1 || n.Body.Length < 10)
			{
				throw new Exception("请输入正确的日志内容");
			}
			if (id.HasValue)
			{
				n.ID = id.Value;
				DBExt.Note.Edit(n, CHUser.UserID);
			}
			else
			{
				DBExt.Note.Add(n, CHUser.UserID);
			}
			return RedirectToAction("Index");
		}
		[AcceptVerbs("post")]
		public ActionResult Delete(long id)
		{
			DBExt.Note.Delete(id, CHUser.UserID);
			return Content("");
		}
		#region old

		//public ActionResult book() {
		//    long ownerid = this.QueryLong("userid");
		//    string ownername = "我";
		//    Boolean isMe = false;
		//    if (ownerid == 0) {//我的情况
		//        ownerid = CHSNSUser.Current.UserID;
		//        isMe = true;
		//    } else {
		//        //Identity identity = new Identity();
		//        //ownername = identity.GetUserName(this.QueryLong("userid"));
		//    }

		//    int tabs;
		//    switch (this.QueryString("mode")) {
		//        case "write"://这个无所谓,发表时
		//            tabs = 2;
		//            break;
		//        case "feedback":
		//            tabs = 1;
		//            break;
		//        case "history":
		//        default:
		//            tabs = 0;
		//            break;
		//    }
		//    ViewData.Add("ownerid", ownerid);
		//    ViewData.Add("tabs", tabs);
		//    ViewData.Add("isMe", isMe);
		//    ViewData.Add("ownername", ownername);
		//    return View();
		//}
		//public ActionResult index1() {
		//    Chsword.Reader.LogBook dl = new Chsword.Reader.LogBook("Note_Watch");
		//    dl.Logid = this.QueryLong("id");
		//    dl.Groupid = this.QueryLong("groupid");
		//    dl.Viewerid = CHSNSUser.Current.UserID;

		//    ViewData.Add("noteid", dl.Logid);
		//    ViewData.Add("groupid", dl.Groupid);
		//    ViewData.Add("isGroup", this.QueryLong("groupid") != 0);
		//    DataRowCollection il = dl.GetLogBookTable(1, 4).Rows;

		//    if (il.Count == 0) {
		//        TempData["msg"] = "您访问的日志不存在.";
		//        return View();
		//    }
		//    ViewData.Add("note", il[0]);
		//    ViewData.Add("rows", il);
		//    return View();
		//}
		#endregion
		public ActionResult New()
		{
			//	Chsword.Reader.LogBook rl = new Chsword.Reader.LogBook("LogBook", 0, Viewerid);
			//ChAlumna.Controllers.components.NoteList nl = new ChAlumna.Controllers.components.NoteList();

			//	_sbout = new StringBuilder(rl.ShowAll(rl.ShowPage(rl.GetLogBookTable(1, 0)), 1));
			//this.Context.CurrentUser.Identity.Name
			ViewData.Add("type", this.QueryNum("type"));//0 new[最新] 1 push[推荐] 
			return View();
		}
	}
}
