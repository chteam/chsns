namespace ChAlumna.Controllers
{using System;
	using ChAlumna.Reader;
	using Castle.MonoRail.Framework;
	[Filter(ExecuteEnum.BeforeAction, typeof(LoginedFilter))]
	public class SuperNoteController : BaseController
	{
		public void video() {
			SuperNoteList snl = new SuperNoteList();
			snl.Everypage = 10;
			snl.Nowpage = 1;
			snl.Template = "supernotepage";
			snl.Userid = QueryLong("userid") == 0
				? ChUser.Current.Userid : QueryLong("userid");
			ViewData["page"] = snl.CreateUserSuperNote().ToString();
		}
		public void randomvideo() {
			SuperNoteList snl = new SuperNoteList();
			snl.Everypage = 10;
			snl.Nowpage = 1;
			snl.Template = "SuperNoteRandomPage";

			snl.Type = 1;
			snl.Userid = ChSession.Userid;

			ViewData["page"] = snl.CreateUserSuperNote().ToString();
		}
	}
}
