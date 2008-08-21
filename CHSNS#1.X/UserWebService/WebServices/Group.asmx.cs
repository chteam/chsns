using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Chsword;
using System.Data.SqlClient;
using CHSNS.Reader;
using Chsword.Datamodel;
using Chsword.Execute;
namespace CHSNS {
	/// <summary>
	/// Group 的摘要说明
	/// </summary>
	[WebService(Namespace = "ChAlumna")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService()]
	public class Group :  WebServices {
		#region 群操作，新建
		/// <summary>
		/// 新建群
		/// </summary>
		/// <param name="groupname"></param>
		/// <returns></returns>
		[WebMethod(EnableSession = true)]
		public string CreateGroup(string groupname,long category) {
			GroupModel gm = new GroupModel();
			gm.Groupname = groupname;
			gm.CreateUserid = ChSession.Userid;
			gm.GroupClass = 0;//普通群
			gm.Category = category;
			GroupExecuter ge = new GroupExecuter(gm);
			return ge.Add();
		}
		#endregion

		#region 管理员用
		[WebMethod(EnableSession = true)]
		public bool Class_Request_Delete(long Groupid) {
			if (ChSession.Status < 200)
				return false;
			SqlParameter[] sqlParameter = new SqlParameter[1]{
					new SqlParameter("@groupid", SqlDbType.BigInt)
				};
			sqlParameter[0].Value = Groupid;
			DoDataBase base2 = new DoDataBase();
			base2.ExecuteSql("Admin_Class_Request_Remove", sqlParameter);
			return true;
		}
		[WebMethod(EnableSession = true)]
		public bool Class_Request_Allow(long Groupid,long userid) {
			if (ChSession.Status < 200)
				return false;
			SqlParameter[] sqlParameter = new SqlParameter[2]{
					new SqlParameter("@groupid", SqlDbType.BigInt),
				new SqlParameter("@userid", SqlDbType.BigInt)
				};
			sqlParameter[0].Value = Groupid;
			sqlParameter[1].Value = userid;
			DoDataBase base2 = new DoDataBase();
			if (base2.DoParameterSql("Admin_Class_Request_Allow", sqlParameter) == "1") {
				return true;
			}
			return false;
		}
		#endregion
		[WebMethod(EnableSession = true)]
		public bool Class_Cancle(long Groupid) {//取消加入或创建
			SqlParameter[] sqlParameter = new SqlParameter[2]{
					new SqlParameter("@groupid", SqlDbType.BigInt),
				new SqlParameter("@userid", SqlDbType.BigInt)
				};
			sqlParameter[0].Value = Groupid;
			sqlParameter[1].Value = ChSession.Userid;
			DoDataBase base2 = new DoDataBase();
			if (base2.DoParameterSql("Class_AddorJoin_Cancle", sqlParameter) == "1") {
				ChSession.Status = 5;
				return true;
			}
			return false;
		}
		
		#region 管理群页面的获取
		[WebMethod(EnableSession=true)]
		public DataRow GroupSetting(long groupid) { 
			DataRowCollection ic = DataBaseExecutor.GetRows("GroupSetting_Select",
				"@id",groupid,
				"@Userid",ChUser.Current.Userid
			);
			return ic.Count > 0 ? ic[0] : null;
		}
		[WebMethod(EnableSession = true)]
		public DataRowCollection GroupMember(long groupid,int type,int page ,int everypage) {
			return DataBaseExecutor.GetRows("GroupUser_Select",
				"@Groupid", groupid,
				"@type", type,
				"@page", page,
				"@everypage", everypage
			);
		}
		[WebMethod(EnableSession = true)]
		public DataRowCollection GroupMember(long groupid, int type) {
			return DataBaseExecutor.GetRows("GroupUser_Select",
				"@Groupid", groupid,
				"@type", type
			);
		}
		#endregion
	}
}
