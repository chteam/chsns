using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data.SqlClient;
using Chsword;
namespace CHSNS {
	/// <summary>
	/// BaseTable 的摘要说明
	/// </summary>
	[WebService(Namespace = "ChAlumna")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService()]
	public class Admin : System.Web.Services.WebService {
        /// <summary>
        /// 批量添加学校
        /// </summary>
        /// <param name="Province"></param>
        /// <param name="Schoollist"></param>
        /// <param name="SchoolClass"></param>
		[WebMethod(EnableSession=true)]
		public void AddSchoolBat(string Province,List<string> Schoollist,int SchoolClass) {
			if(!CHUser.IsAdmin) return;
			foreach (string school in Schoollist) {
				SqlParameter[] sp = new SqlParameter[3] {
					new SqlParameter("@schoolname", SqlDbType.NVarChar,50),
					new SqlParameter("@province",  SqlDbType.NVarChar,50),
					new SqlParameter("@SchoolClass", SqlDbType.Int)
				};
				sp[0].Value = school;
				sp[1].Value = Province;
				sp[2].Value = SchoolClass;
				DoDataBase db = new DoDataBase();
				db.ExecuteSql("Admin_School_Add", sp);
			}
		}

		[WebMethod(EnableSession=true)]
		public bool setStar(string userid,bool isstar){
            if (CHUser.IsAdmin) {
                DoDataBase db = new DoDataBase();
                db.Executer_SqlText(
                    string.Format("update [profile] set isstar={0},isupdate=1 where userid={1}",
                                   isstar ? 1 : 0,
                                   userid)
                );
                return true;
            }
            return false;
		}
	}
}
