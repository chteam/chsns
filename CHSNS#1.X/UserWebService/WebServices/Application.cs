/*
 * Created by 邹健
 * Date: 2007-10-11
 * Time: 14:39
 * 
 * 
 */
namespace ChAlumna
{

	using System;
	using System.Data;
	using System.Data.SqlClient;
	using System.Web;
	using System.Web.Services;
	using System.Web.Services.Protocols;
	using System.ComponentModel;
	using System.Collections.Generic;
	using Chsword;

	/// <summary>
	/// Description of Application
	/// </summary>
	[WebService
	 (	Name = "Application",
	  Description = "Application",
	  Namespace = "http://www.eice.com.cn"
	 )
	]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService()]
	public class Application : WebServices
	{
		[WebMethod(EnableSession=true)]
		public void MyApp_Sava(string applist)
		{
			SqlParameter[] sp = new SqlParameter[2] { 
				new SqlParameter("@UserId", SqlDbType.BigInt),
				new SqlParameter("@appstr", SqlDbType.VarChar,4000)
			};
			sp[0].Value = ChUser.Current.Userid;
			sp[1].Value = applist;
			DoDataBase db = new DoDataBase();
			db.DoParameterSql("MyApplication_Save", sp);
			
			Session.Remove("applications");
			return;
		}
		public DataRowCollection MyApplicationRows() {
			return DataBaseExecutor.GetRows(
				"MyApplicationlist",
				"@userid",
				ChUser.Current.Userid);
		}
	}
}
