	using System;
	using System.Collections.Generic;
	namespace CHSNS.Controllers
{

	// 非注册用户可以访问
	//[Filter(ExecuteEnum.BeforeAction, typeof(PublicFilter))]
	public class SearchController : BaseController
	{
		static string[] personal = { "lovelike","joinsociety","lovebook",
			"lovecomic","lovegame","lovemovie",
			"lovemusic","lovesports"};
		static string[] school ={ "uid", "xid", "qid", "grade" };
		public void index(){
			Dictionary<string, object> _dict = new Dictionary<string, object>();
			ViewData["tabs"] = this.QueryNum("tabs");
			#region 访问搜索页
			if (!string.IsNullOrEmpty(this.QueryString("action"))) {
				switch (this.QueryString("action")) {
					case "personal":
						foreach (string str in personal) {
							if (this.QueryString(str) != "")
								_dict.Add(str, this.QueryString(str));
						}
						break;
					case "show":
						foreach (string str in school) {
							if (this.QueryLong(str) != 0)
								_dict.Add(str, this.QueryLong(str));
						}
						break;
					default:
						break;
				}
				if (this.QueryString("university") != "")
					_dict.Add("university", this.QueryString("university"));
				if (this.QueryString("username") != "")
					_dict.Add("username", ChServer.UrlDecode(this.QueryString("username")));

				string querystring = this.QueryString("action");
				if (querystring == "name" && CHSNSUser.Current.isLogined) {
					querystring = "show";
				}
				Chsword.Reader.Search ds = new Chsword.Reader.Search(_dict, querystring);
				ds.Nowpage = 1;
				ds.Everypage = 10;
				ds.Template = CHUser.UseridwithoutError == 0 ? "SearchUserListSample" : "UserList";
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
