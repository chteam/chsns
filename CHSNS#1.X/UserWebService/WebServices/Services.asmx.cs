using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using ChAlumna;
using ChAlumna.Models;
using ChAlumna.Config;

namespace Chsword {
	/// <summary>
	/// Services 的摘要说明
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService()]
	public class Services : System.Web.Services.WebService {
		#region 一般用户方法
		[WebMethod(Description = "获得客户服务问题列表")]//不用开Session
		public DataTable ServicesTable(int nowpage, int everypage, long userid, string Email) {


			SqlParameter[] sp = new SqlParameter[4] { 
				new SqlParameter("@page", SqlDbType.BigInt),
				new SqlParameter("@everypage", SqlDbType.BigInt),
				new SqlParameter("@UserId", SqlDbType.BigInt),
				new SqlParameter("@email", SqlDbType.NVarChar,50)
			};
			sp[0].Value = nowpage;
			sp[1].Value = everypage;
			sp[2].Value = userid;
			sp[3].Value = Email;
			DoDataBase db = new DoDataBase();
			return db.DoDataSet("Services_Select", sp).Tables[0];
		}
		[WebMethod(Description = "获得客户服务问题列表")]//不用开Session
		public string ServicesCount() {
			DoDataBase db = new DoDataBase();
			return db.getTableValue_SqlText("select count(1) from services");
		}
		
		[WebMethod(Description = "提交问题",EnableSession=true)]
		public string SendServices(long? userid, string body, string email) {
			//各种不正常现象的发生以及预防
			if (body.Length > 4000) throw new Exception(Debug.TraceBack("[客户服务问题]最多只能提交4000字"));
			if (body.Length < 1) throw new Exception(Debug.TraceBack("请填写[客户服务问题]的内容"));
			if (string.IsNullOrEmpty(email))
				if (Session["userid"] == null)
					throw new Exception(Debug.TraceBack("提交[客户服务问题]需要您登录或填写Email"));
				else if (userid.ToString() != Session["userid"].ToString())
					throw new Exception(Debug.TraceBack("提交[客户服务问题]需要您登录或填写Email"));

			ChAlumna.DataBaseExecutor.Execute(
				"Services_Add",
				"@userid", userid == null ? 0 : userid.Value,
				"@body", body,
				"@email", email);
			Email.SystemSend(SiteConfig.Currect.BaseConfig.Title + "客服有新的问题", body, SiteConfig.Currect.BaseConfig.MasterEmail, "管理员");
			//SqlParameter[] p = new SqlParameter[3];
			//p[0] = new SqlParameter("@userid", SqlDbType.BigInt);
			//p[0].Value =;
			//p[1] = new SqlParameter("@body", SqlDbType.NVarChar, 4000);
			//p[1].Value = body;
			//p[2] = new SqlParameter("@email", SqlDbType.NVarChar, 50);
			//p[2].Value = email;
			//DoDataBase dd = new DoDataBase();
			//dd.DoParameterSql("Services_Add", p);

			return "提交成功";
		}
		#endregion
		#region 管理员方法
		//[WebMethod(Description = "获取单一问题",EnableSession=true)]//不用开Session
		//public DataTable ServicesTable(int nowpage, int everypage, long userid, string Email) {
		//    //long Viewerid = 0;
		//    //long.TryParse(Session["userid"].ToString(), out Viewerid);
		//    SqlParameter[] sp = new SqlParameter[4] { 
		//        new SqlParameter("@page", SqlDbType.BigInt),
		//        new SqlParameter("@everypage", SqlDbType.BigInt),
		//        new SqlParameter("@UserId", SqlDbType.BigInt),
		//        new SqlParameter("@email", SqlDbType.NVarChar,50)
		//    };
		//    sp[0].Value = nowpage;
		//    sp[1].Value = everypage;
		//    sp[2].Value = userid;
		//    sp[3].Value = Email;
		//    DoDataBase db = new DoDataBase();
		//    return db.DoDataSet("Services_Select", sp).Tables[0];
		//}
		#endregion
	}
}
