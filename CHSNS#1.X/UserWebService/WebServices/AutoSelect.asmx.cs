using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using ChAlumna;
namespace Chsword {
	/// <summary>
	/// AutoSelect 的摘要说明
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService()]
	public class AutoSelect : System.Web.Services.WebService {
		//ChAlumna.DataSetCache _DataSetCache = new ChAlumna.DataSetCache();
		[WebMethod]
		public DataTable ProvinceList() {
			return DataSetCache.ProvinceList();
		}
		[WebMethod]
		public DataTable UniversityList(string Province_str) {
			return DataSetCache.SchoolList(Province_str, 0);//0是大学
		}
		[WebMethod]
		public DataTable XueyuanList(string Uni_str) {
			return DataSetCache.XueYuanList(Uni_str);//0是大学
		}
	}
}
