namespace ChAlumna.Controllers
{
    using System;
	using System.Collections;
	using System.Data;
	using Castle.MonoRail.Framework;
	//using NVelocity.Runtime.Directive;
	[Filter(ExecuteEnum.BeforeAction, typeof(LoginedFilter))]
    public class NoteController : BaseController
    {
		public void book() {
			long ownerid = QueryLong("userid");
			string ownername = "我";
			Boolean isMe = false;
			if (ownerid == 0) {//我的情况
				ownerid = ChUser.Current.Userid;
				isMe = true;
			} else {
				Identity identity = new Identity();
				ownername = identity.GetUserName(QueryLong("userid"));
			}
			int tabs;
			switch (QueryString("mode")) {
				case "write"://这个无所谓,发表时
					tabs = 2;
					break;
				case "feedback":
					tabs = 1;
					break;
				case "history":
				default:
					tabs = 0;
					break;
			}
			ViewData.Add("ownerid", ownerid);
			ViewData.Add("tabs", tabs);
			ViewData.Add("isMe", isMe);
			ViewData.Add("ownername", ownername);
		}
		public void index() {
			Chsword.Reader.LogBook dl = new Chsword.Reader.LogBook("Note_Watch");
			dl.Logid = QueryLong("id");
			dl.Groupid = QueryLong("groupid");
			dl.Viewerid = ChUser.Current.Userid;

			ViewData.Add("noteid", dl.Logid);
			ViewData.Add("groupid", dl.Groupid);
			ViewData.Add("isGroup", QueryLong("groupid") != 0);
			DataRowCollection il = dl.GetLogBookTable(1, 4).Rows;

			if (il.Count == 0) {
				Flash["msg"] = "您访问的日志不存在.";
				return;
			}
			ViewData.Add("note", il[0]);
			ViewData.Add("rows", il);
		}

		public void New() {
		//	Chsword.Reader.LogBook rl = new Chsword.Reader.LogBook("LogBook", 0, Viewerid);
			//ChAlumna.Controllers.components.NoteList nl = new ChAlumna.Controllers.components.NoteList();
		
		//	_sbout = new StringBuilder(rl.ShowAll(rl.ShowPage(rl.GetLogBookTable(1, 0)), 1));
			//this.Context.CurrentUser.Identity.Name
			ViewData.Add("type", QueryNum("type"));//0 new[最新] 1 push[推荐] 
		}
    }
}
