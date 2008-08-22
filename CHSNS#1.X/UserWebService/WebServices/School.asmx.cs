	using System;
	using System.Linq;
	using System.Data;
	using System.Web;
	using System.Collections;
	using System.Web.Services;
	using System.Web.Services.Protocols;
	using System.ComponentModel;
	using CHSNS.Models;
	using System.Collections.Generic;
	using System.Text;
	using CHSNS.Config;namespace CHSNS
{

    /// <summary>
    /// School 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class DoField : System.Web.Services.WebService
    {
        /// <summary>
        /// 为大学添加一个学院
		/// 0是学院
        /// </summary>
        /// <param name="schoolid"></param>
        /// <param name="names"></param>
		[WebMethod(EnableSession = true)]
		public string AddMiniField(Int64 fieldid, IList names, int type) {
			StringBuilder output = new StringBuilder();
			if (CHUser.IsAdmin) {
										using (ChAlumnaDBDataContext Db = new ChAlumnaDBDataContext
						(SiteConfig.SiteConnectionString)) {
				foreach (String name in names) {
					if (string.IsNullOrEmpty(name.Trim())) continue;
					try {


						MiniField x = new MiniField();

						x.pid = fieldid;
						x.@class = type;
						x.name = name.Trim();
						Db.MiniField.InsertOnSubmit(x);
						Db.SubmitChanges();
					} catch {
						output.AppendFormat("{0} is exists <br />", name);
					}
				}
										}
			}
			return output.ToString();
		}

		/// <summary>
		/// 为大学添加寝室
		/// </summary>
		/// <param name="schoolid"></param>
		/// <param name="names"></param>
		[WebMethod(EnableSession = true)]
		public string AddQinshi(Int64 schoolid, IList names) {
			StringBuilder output = new StringBuilder();
			if (CHUser.IsAdmin) {
				foreach (String name in names) {
					if (string.IsNullOrEmpty(name.Trim())) continue;
					try {
						//Qinshi q = new Qinshi();
						//q.School = schoolid;
						//q.QinShi = name.Trim();
						//q.SchoolClass = 0;
						//q.Create();
					} catch(Exception e) {
						output.AppendFormat("{0} is exists <br />", name);//name
					}
				}
			}
			return output.ToString();
		}
    }
}
