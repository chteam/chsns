namespace CHSNS.Controllers
{using System;
	using CHSNS.Reader;
	
	[LoginedFilter]
	public class SuperNoteController : BaseController
	{
		public void video() {
			SuperNoteList snl = new SuperNoteList();
			snl.Everypage = 10;
			snl.Nowpage = 1;
			snl.Template = "supernotepage";
			snl.Userid = this.QueryLong("userid") == 0
				? ChUser.Current.Userid : this.QueryLong("userid");
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
