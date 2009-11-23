using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using CHSNS;
using Chsword;
using System.Data.SqlClient;
using CHSNS.Models;
namespace Chsword.Execute
{
	public class UserSettingExecuter{
		byte _olduserstatus;
		public UserSettingExecuter(){
			_olduserstatus=CHUser.Status;
		}
		/// <summary>
		/// 设置用户基础信息,暂时无效
		/// </summary>
		public string SetUserBaseInfo(Dictionary<string,object> dict) {
			if (Convert.ToDateTime(dict["birthday"]) > DateTime.Now)
				return "请输入正确生日";
			if (dict["province"].ToString() == "0" || dict["city"].ToString() == "0")
				return "请选择正确的省";
			SqlParameter[] sp = new SqlParameter[7]{
				new SqlParameter("@name", SqlDbType.NVarChar, 12)
					,new SqlParameter("@Sex", SqlDbType.Bit)
					,new SqlParameter("@userid", SqlDbType.BigInt)
					,new SqlParameter("@BirthDay", SqlDbType.SmallDateTime)
					,new SqlParameter("@Province", SqlDbType.SmallInt)
					,new SqlParameter("@City", SqlDbType.Int)
					,new SqlParameter("@showlevel", SqlDbType.TinyInt)
			};
			sp[0].Value = dict["name"];
			sp[1].Value = dict["sex"];
			sp[2].Value = CHUser.UserID;
			sp[3].Value = dict["birthday"];
			sp[4].Value = dict["province"];
			sp[5].Value = dict["city"];
			sp[6].Value = dict["showlevel"];
			DoDataBase db = new DoDataBase();
			int userstatus = int.Parse(db.DoParameterSql("MyBasicUpdate", sp));//返回当前的st
			if (userstatus < 0)
				return "您的账号未激活或已经冻结.";
			else {
				CHUser.Username = dict["name"].ToString().Trim();
				//ChSession.Status = Convert.ToByte(userstatus);
				//HttpContext.Current.Response.Cookies[ChSite.Currect.CookieName]["userstatus"]= userstatus.ToString();
				if (CHSNSUser.Current.Status < UserStatusType.Basic)
					CHSNSUser.Current.Status = UserStatusType.Basic;
				//ChCookies.Status = userstatus;
				if (_olduserstatus < 8) {
					CHUser.Status = byte.Parse(userstatus.ToString());
					return "turn";
				}
				return string.Empty;
			}
		}
		public string SetUserSchoolInfo(Dictionary<string,object> dict) {
			int grade=Convert.ToInt32(dict["grade"]);
			if (grade >= DateTime.Now.Year + 2 || grade <= 1967)
				return "入学时间不正确";
			SqlParameter[] sp = new SqlParameter[7]{
				new SqlParameter("@Xueyuan", SqlDbType.NVarChar, 50)
					,new SqlParameter("@Qinshi", SqlDbType.BigInt)
					,new SqlParameter("@userid", SqlDbType.BigInt)
					,new SqlParameter("@Highschool", SqlDbType.NVarChar, 50)
					,new SqlParameter("@Grade", SqlDbType.SmallInt)
					,new SqlParameter("@Juniorschool", SqlDbType.NVarChar, 50)
					,new SqlParameter("@showlevel", SqlDbType.TinyInt)
			};
			sp[0].Value = "";// Regular.StringNull(usm.Xueyuan);
			sp[1].Value = dict["qinshi"];
			sp[2].Value = CHUser.UserID;
			sp[3].Value = "";// Regular.StringNull(usm.Highschool);
			sp[4].Value = dict["grade"];
			sp[5].Value = "";//Regular.StringNull(usm.Juniorschool);
			sp[6].Value =dict["showlevel"];
			DoDataBase db = new DoDataBase();
			db.ExecuteSql("MySchoolUpdate", sp);
			if (CHSNSUser.Current.Status ==UserStatusType.Basic ) {
				CHSNSUser.Current.Status = UserStatusType.InfoOver;
				return "turn";
			}
			return string.Empty;
		}
		public string SetUserContactInfo(Dictionary<string,object> dict){
			SqlParameter[] sp = new SqlParameter[10]{
				new SqlParameter("@Telphone", SqlDbType.NVarChar, 50),
				new SqlParameter("@QQ", SqlDbType.NVarChar, 50),
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@Msn", SqlDbType.NVarChar, 50),
				new SqlParameter("@UC", SqlDbType.NVarChar, 50),
				new SqlParameter("@Mobiephone", SqlDbType.NVarChar, 50),
				new SqlParameter("@WebSite", SqlDbType.NVarChar, 100),
				new SqlParameter("@WangWang", SqlDbType.NVarChar, 50),
				new SqlParameter("@NeteasePop", SqlDbType.NVarChar, 50),
				new SqlParameter("@showlevel", SqlDbType.TinyInt)
			};
			sp[0].Value = dict["telphone"];
			sp[1].Value = dict["qq"];
			sp[2].Value = CHUser.UserID;
			sp[3].Value = dict["msn"];
			sp[4].Value = "";
			sp[5].Value = dict["mobiephone"];
			sp[6].Value =dict["website"];
			sp[7].Value = "";
			sp[8].Value = "";
			sp[9].Value=dict["showlevel"];
			DoDataBase db = new DoDataBase();
			db.ExecuteSql("MyContactUpdate", sp);
			if(_olduserstatus<8)
				return "turn";
			return string.Empty;
		}
		public string SetUserPersonalInfo(Dictionary<string,object> dict) {
			SqlParameter[] sp = new SqlParameter[10]{
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@LoveLike", SqlDbType.NVarChar, 4000),
				new SqlParameter("@LoveBook", SqlDbType.NVarChar, 4000),
				new SqlParameter("@LoveMusic", SqlDbType.NVarChar, 4000),
				new SqlParameter("@LoveMovie", SqlDbType.NVarChar, 4000),
				new SqlParameter("@LoveSports", SqlDbType.NVarChar, 4000),
				new SqlParameter("@LoveGame", SqlDbType.NVarChar, 4000),
				new SqlParameter("@LoveComic", SqlDbType.NVarChar, 4000),
				new SqlParameter("@JoinSociety", SqlDbType.NVarChar, 4000),
				new SqlParameter("@showlevel", SqlDbType.TinyInt)
			};
			sp[0].Value =  CHUser.UserID;
			sp[1].Value = Regular.FormatLove(dict["lovelike"]);
			sp[2].Value = Regular.FormatLove(dict["lovebook"]);
			sp[3].Value = Regular.FormatLove(dict["lovemusic"]);
			sp[4].Value = Regular.FormatLove(dict["lovemovie"]);
			sp[5].Value = Regular.FormatLove(dict["lovesports"]);
			sp[6].Value = Regular.FormatLove(dict["lovegame"]);
			sp[7].Value = Regular.FormatLove(dict["lovecomic"]);
			sp[8].Value = Regular.FormatLove(dict["joinsociety"]);
			sp[9].Value = dict["showlevel"];
			DoDataBase db = new DoDataBase();
			db.ExecuteSql("MyPersonalUpdate", sp);
			if(_olduserstatus<8)
				return "turn";
			return string.Empty;
		}
		public string SetUserMagicBoxInfo(Dictionary<string,object> dict) {
			SqlParameter[] sp = new SqlParameter[2]{
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@MagicBox", SqlDbType.NText)
			};
			sp[0].Value = CHUser.UserID;
			sp[1].Value = StyleSheet.filter(dict["magicbox"].ToString());
			DoDataBase db = new DoDataBase();
			db.ExecuteSql("MyMagicBoxUpDate", sp);
			if(_olduserstatus<8)
				return "turn";
			return string.Empty;
		}
		internal string SetUserMagicBoxUpBack() {
			SqlParameter[] sp = new SqlParameter[1]{
				new SqlParameter("@userid", SqlDbType.BigInt)
			};
			sp[0].Value =CHUser.UserID;
			DoDataBase db = new DoDataBase();
			db.ExecuteSql("MyMagicBoxUpBack", sp);
			return string.Empty;
		}
		internal void SetUserMagicBoxClear() {
			Dictionary<string,object> dict=new Dictionary<string,object>();
			dict.Add("magicbox","");
			SetUserMagicBoxInfo(dict);
		}
		internal string DeleteUserface() {
			string p;
			for (ImgSize i = ImgSize.tiny; i <= ImgSize.big; i++) {
				p = CHSNS.Path.GetFaceEmpty( CHUser.UserID.ToString(), i);
				if (!string.IsNullOrEmpty(p))
					System.IO.File.Delete(HttpContext.Current.Server.MapPath(p));
			}
			return "删除头像完成";
		}
	}
}
