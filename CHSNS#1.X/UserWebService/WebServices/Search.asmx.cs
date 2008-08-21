
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using CHSNS.Reader;
using Chsword;
using System.Collections.Generic;
namespace CHSNS {
	/// <summary>
	/// Search 的摘要说明
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService()]
	public class Search : Chsword.WebServices {

		//[WebMethod(EnableSession=true)]
		//public string SearchClassPage() {
		//        SearchReader sr=new SearchReader();
		//        return sr.getSearchClass();
		//}
		[WebMethod(EnableSession = true)]
		public DataTable SearchClassItems(Dictionary<string,object> d) {
			SqlParameter[] p = new SqlParameter[3] {
				new SqlParameter("@University", SqlDbType.BigInt),
				new SqlParameter("@XueYuan", SqlDbType.BigInt),
				new SqlParameter("@Grade", SqlDbType.Int)
			};
			p[0].Value = Formatstr(d["uid"]);
			p[1].Value = Formatstr(d["xid"]);
			p[2].Value = Formatstr(d["grade"]);
			DoDataBase dd = new DoDataBase();
			return dd.DoDataSet("Search_Class", p).Tables[0];
		}
		object Formatstr(object str) {
			if (string.IsNullOrEmpty(str.ToString()))
				return System.DBNull.Value;
			return str;
		}

	}
}
