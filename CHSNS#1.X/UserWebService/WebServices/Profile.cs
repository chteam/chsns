/*
 * Created by 邹健
 * Date: 2007-10-25
 * Time: 14:55
 * 
 * 
 */

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using ChAlumna.Reader;
using Chsword;

namespace ChAlumna {
	/// <summary>
	/// 用户的个性设置
	/// </summary>
	[WebService
	 (Name = "Profile",
		Description = "Profile",
		Namespace = "http://www.Profile.example"
	 )
	]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService()]
	public class Profile : Chsword.WebServices {

		#region 编辑当前正在做什么
		[WebMethod(EnableSession = true)]
		public string ShowText_Edit(string showtext) {
			showtext = Server.HtmlEncode(showtext);
			SqlParameter[] sqlParameter = new SqlParameter[2]{
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@showtext", SqlDbType.NVarChar, 20)
			};
			sqlParameter[0].Value = ChSession.Userid;
			sqlParameter[1].Value = showtext;
			DoDataBase db = new DoDataBase();
			db.ExecuteSql("Profile_Showtext_Update", sqlParameter);
			return showtext;
		}
		#endregion
		
		#region 编辑访问权限
		[WebMethod(EnableSession = true)]
		public DataRow ShowLevelList() {
			DataRowCollection drs = DataBaseExecutor.GetRows("ChangeShowLevelSelect",
				"@UserId", ChUser.Current.Userid);
			if (drs.Count == 0)
				return null;
			else
				return drs[0];
		}

		[WebMethod(EnableSession = true)]
		public void ShowLevel_Edit(string id,int value) {
			if(!ChSession.isLogined&&value%50!=0)
				return;
			DoDataBase ddb= new DoDataBase();
			switch(id.ToLower()){
				case "contactinfo":
				case "personalinfo":
				case "basicinfo": 
					ddb.Executer_SqlText(
						string.Format("update [profile] set {0}showlevel={1} where userid={2}"
						              ,id.Trim()
						              ,value%255
						              ,ChSession.Userid
						             )
					);
					break;
				default:
					break;
			}
		}
		#endregion
		
		#region 事件主移除事件
		[WebMethod(EnableSession = true)]
		public bool Event_Remove(long id) {
			DataBaseExecutor.Execute("Event_Remove",
				"@id", id,
			"@userid", ChUser.Current.Userid,
			"@viewerstatus", ChUser.Current.Status);

			return true;
		}
		#endregion
		#region 获取当前用户名


		/// <summary>
		/// 获取当前用户的用户姓名
		/// </summary>
		/// <returns></returns>
		[WebMethod(EnableSession = true)]
		public string GetUsername() {
			//	 User.Identity
			if (Session["username"] == null)
				return "未登录";
			return Session["username"].ToString();
		}
		#endregion

		#region 管理员工具
		[WebMethod(EnableSession = true)]
		public bool Admin_Isstar_Add(long userid) {
			return SetStarLevel(userid, true, true);
		}
		[WebMethod(EnableSession = true)]
		public bool Admin_Isstar_Remove(long userid) {
			return SetStarLevel(userid,false,true);
		}
		bool SetStarLevel(long userid,bool isstar,bool isupdate) {
			#region 解释
			//是否是真实用户  标志位
			//	0				0			默认初始
			//	1				0			第一次上传
			//	0				1			审核未通过
			//	1				1			审核通过
			//	0,0  1,1->1,0
			//	0,1  1,0->不变
			//''星级用户处理方法           0 0
			//'A当用户首次上传照片时 为    1 0 初始星用户，待审
			//'当用户二次上传时为          0 1  待审
			//'当用户一次上传后认为不合法时为 0 1 待审
			//'当用户审核成功后都进入 1 1 为纯星
			//'0 0->1 0
			//'0 1->上传后 为0 1
			//'1 1->上传后 为1 0
			//'1 0->上传后仍为1 0
			#endregion
			if (ChSession.Status == 0) {
				return false;
			}
			SqlParameter[] p = new SqlParameter[4] { 
				new SqlParameter("@Userid", System.Data.SqlDbType.BigInt),
				 new SqlParameter("@isstar", System.Data.SqlDbType.Bit),
				 new SqlParameter("@isupdate", System.Data.SqlDbType.Bit),
				 new SqlParameter("@Executerid", System.Data.SqlDbType.BigInt)
			};
			p[0].Value = userid;
			p[1].Value = isstar;
			p[2].Value = isupdate;
			p[3].Value = ChSession.Userid;
			DoDataBase dd = new DoDataBase();
			dd.ExecuteSql("SetStarLevel", p);
			return true;
		}
		#endregion

		#region friend
		[WebMethod(EnableSession = true)]
		public int FriendCount(long userid) {
			return Convert.ToInt32(DataBaseExecutor.ExecuteScalar("FriendCount",
				"@userid", userid));
		}
		[WebMethod(EnableSession = true)]
		public int FriendRequestCount(long userid) {
			return Convert.ToInt32(DataBaseExecutor.ExecuteScalar("FriendRequestCount",
				"@userid", userid));
		}
		#endregion
	}
}
