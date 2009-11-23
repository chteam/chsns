using System;
using System.Data;
using System.Web;
using System.Text;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using Chsword.Datamodel;
using Chsword.Execute;
using Chsword;
using CHSNS.Reader;
namespace CHSNS {
	/// <summary>
	/// Comment 的摘要说明
	/// </summary>
	[WebService(Namespace = "http://5field.com/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService()]
	public class Comment : Chsword.WebServices {

		[WebMethod(EnableSession = true)]
		public bool SeeReply(long id) {
			SqlParameter[] p = new SqlParameter[2] { 
				new SqlParameter("@id", SqlDbType.BigInt),
				new SqlParameter("@userid", SqlDbType.BigInt)
			};
			p[0].Value = id;
			p[1].Value = CHUser.UserID;
			DoDataBase dd = new DoDataBase();
			dd.ExecuteSql("Comment_Update", p);
			return true;
		}
		[WebMethod(EnableSession = true)]
		public bool SeeAll() {
			SqlParameter[] p = new SqlParameter[1] { 
				new SqlParameter("@userid", SqlDbType.BigInt)
			};
			p[0].Value = CHUser.UserID;
			DoDataBase dd = new DoDataBase();
			dd.ExecuteSql("Comment_Update2", p);
			return true;
		}
	}
}
