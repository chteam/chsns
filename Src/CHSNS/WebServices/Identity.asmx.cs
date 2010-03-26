﻿	using System;
	using System.ComponentModel;
	using System.Data;
	using System.Data.SqlClient;
	using System.Web.Services;
	using Chsword;
namespace CHSNS
{

	/// <summary>
	/// 进行登录注销注册等用户行为
	/// </summary>
	[System.Web.Script.Services.ScriptService()]
	[WebService(Namespace = "ChAlumna")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	public class Identity : WebServices
	{


		#region 注册Field -- 大学生
		[WebMethod(EnableSession = true)]
		public bool UpdateUniversityField(string uni, string xueyuan) {
			if (CHUser.Status != 1)
				return false;
			SqlParameter[] sqlParameter = new SqlParameter[4]{
					new SqlParameter("@University", SqlDbType.NVarChar, 50),
					new SqlParameter("@Xueyuan", SqlDbType.NVarChar, 50),
					new SqlParameter("@userid", SqlDbType.BigInt),
					new SqlParameter("@field", SqlDbType.TinyInt)
				};
			sqlParameter[0].Value = uni.Trim();
			sqlParameter[1].Value = xueyuan.Trim();
			sqlParameter[2].Value = CHUser.UserID;
			sqlParameter[3].Value = 1;
			DoDataBase base2 = new DoDataBase();
			long ret = long.Parse(base2.DoParameterSql("Field_Add", sqlParameter));
			if (ret == 1) {
				Session["status"] = 2;
			}
			return (ret == 1);

		}
		#endregion
		#region Cache

		[WebMethod]
		public string GetTemplate(string name) {
			return CHCache.GetTemplateCache(name);
		}
		//[WebMethod]
		//public string GetConfig(string name) {
		//    return CHCache.GetConfig(name);
		//}
		//[WebMethod]
		//public string GetConfig(string fn, string name) {
		//    return CHCache.GetConfig(fn, name);
		//}
		#endregion

		#region 找回密码
		string setCode(string email) {
			Random rand = new Random();
			long code = rand.Next(999999);

			SqlParameter[] p = new SqlParameter[2] { 
			new SqlParameter("@email", SqlDbType.NVarChar,50),
			new SqlParameter("@code", SqlDbType.BigInt)
			};
			p[0].Value = email.Trim();
			p[1].Value = code;
			DoDataBase dd = new DoDataBase();
			if (dd.DoParameterSql("SetCode", p) == "1")
				return code.ToString();
			else
				return "";
		}
		[WebMethod(EnableSession = true)]
		public bool GetCode(string email) {//找回密码
			if (email.Length > 4) {
				string code = setCode(email);
				if (code != "") {
					Email.SystemSend(
					"您的验证码",
					string.Format("您的验证码为：{0}，请到http://www.cnjmsu.com/help/setpassword.aspx修改密码", code),
					email.Trim(),
					email
					);
					return true;
				}
			}
			return false;
		}
		[WebMethod(EnableSession = true)]
		public bool SetPassword(string email, string password, long code) {//找回密码
			if (email.Length > 4) {
				Encrypt en = new Encrypt();
				SqlParameter[] p = new SqlParameter[3] { 
				new SqlParameter("@useremail", SqlDbType.NVarChar,50),
				new SqlParameter("@password", SqlDbType.NChar,32),
				new SqlParameter("@code", SqlDbType.BigInt)
				};
				p[0].Value = email.Trim();
				p[1].Value = en.MD5Encrypt(password.Trim(), 32);
				p[2].Value = code;
				DoDataBase dd = new DoDataBase();
				if (dd.DoParameterSql("SetPassword", p) == "1") {
					setCode(email);
					return true;
				}
			}
			return false;
		}
		#endregion
		/// <summary>
		/// 得到用户状态/等级
		/// </summary>
		/// <param name="Userid"></param>
		/// <returns></returns>
		public int GetUserStatus(object Userid) {
			Dictionary dict = new Dictionary();
			dict.Add("@Userid", Userid);
			int i = 0;
			int.TryParse(
				DataBaseExecutor.ExecuteScalar("GetUserStatus", dict).ToString(),
				out i);
			return i;
		}
		/// <summary>
		/// 由用户ID返回用户名
		/// </summary>
		/// <param name="Userid"></param>
		/// <returns></returns>
		public string GetUserName(object Userid) {//临时个文件
			Dictionary dict = new Dictionary();
			dict.Add("@Userid", Userid);
			return DataBaseExecutor.ExecuteScalar("UserNameByUserId", dict).ToString();
		}
	}
}