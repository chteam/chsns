namespace ChAlumna.Controllers
{
	using System;
	using System.Collections.Generic;
	using Castle.MonoRail.Framework;
	// 非注册用户可以访问
	[Filter(ExecuteEnum.BeforeAction, typeof(PublicFilter))]
	public class SearchController : BaseController
	{
		static string[] personal = { "lovelike","joinsociety","lovebook",
			"lovecomic","lovegame","lovemovie",
			"lovemusic","lovesports"};
		static string[] school ={ "uid", "xid", "qid", "grade" };
		public void index(){
			Dictionary<string, object> _dict = new Dictionary<string, object>();
			ViewData["tabs"] = QueryNum("tabs");
			#region 访问搜索页
			if (!string.IsNullOrEmpty(QueryString("action"))) {
				switch (QueryString("action")) {
					case "personal":
						foreach (string str in personal) {
							if (QueryString(str) != "")
								_dict.Add(str, QueryString(str));
						}
						break;
					case "show":
						foreach (string str in school) {
							if (QueryLong(str) != 0)
								_dict.Add(str, QueryLong(str));
						}
						break;
					default:
						break;
				}
				if (QueryString("university") != "")
					_dict.Add("university", QueryString("university"));
				if (QueryString("username") != "")
					_dict.Add("username", ChServer.UrlDecode(QueryString("username")));

				string querystring = QueryString("action");
				if (querystring == "name" && ChUser.Current.isLogined) {
					querystring = "show";
				}
				Chsword.Reader.Search ds = new Chsword.Reader.Search(_dict, querystring);
				ds.Nowpage = 1;
				ds.Everypage = 10;
				ds.Template = ChSession.UseridwithoutError == 0 ? "SearchUserListSample" : "UserList";
				Chsword.Reader.ServerResponse sr = ds.GetMember();

				ViewData["ResultItems"] = sr.ResponseText;
				ViewData["Count"] = sr.Count;
				ViewData["Tabs"] = 3;
			}
			ViewData["Count"] = 0;
			#endregion
				
			//if (QueryNum("tabs") == 2) {
			//    ChAlumna.Reader.SearchReader sr = new ChAlumna.Reader.SearchReader();
			//    ViewData["searchclass"] = sr.getSearchClass();
			//}
		
		}
	}
}
