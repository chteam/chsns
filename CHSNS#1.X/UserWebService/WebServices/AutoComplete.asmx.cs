using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using CHSNS;
namespace Chsword {
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService()]
	public class AutoComplete : System.Web.Services.WebService {
	//	CHSNS.DataSetCache _DataSetCache = new CHSNS.DataSetCache();

		#region 邮箱提示

		[WebMethod()]
		public string[] GetCompletionList(string prefixText, int count) {
			String CacheName = "AutoComplete.EmailList";
			if ((count == 0)) count = 5;
			List<string> items = new List<string>(count);

			List<string> root;
			if (ChCache.IsNullorEmpty(CacheName)) {
				root = new List<string>();
				root.Add("@126.com");
				root.Add("@163.com");
				root.Add("@qq.com");
				root.Add("@sina.com.cn");
				root.Add("@sohu.com");
				root.Add("@tom.com");
				root.Add("@msn.com");
				root.Add("@yahoo.com");
				root.Add("@21cn.com");
				root.Add("@sogou.com");
				root.Add("@263.net");
				root.Add("@chinaren.com");
				root.Add("@etang.com");
				root.Add("@hotmail.com");
				ChCache.SetCache(CacheName, root);
			} else {
				root = (List<string>)ChCache.GetCache(CacheName);
			}
			string[] user = prefixText.Split('@');
			Int16 i;
			for (i = 0; i <= root.Count - 1; i++) {
				if (root[i].StartsWith(string.Format("@{0}", user[user.GetUpperBound(0)]))) {
					items.Add(string.Format("{0}{1}", user[user.GetLowerBound(0)], root[i]));
				} else {
					if (!prefixText.Contains("@")) {
						items.Add(string.Format("{0}{1}", prefixText, root[i]));
					}
				}
				if (items.Count > 5) break; 
			}

			//items.Add(HttpContext.Current.Response.Cookies.Count.ToString())
			return items.ToArray();

		}
		#endregion
		#region 学校相关

		/// <summary>
		/// 显示学院的列表
		/// </summary>
		/// <param name="prefixText"></param>
		/// <param name="count"></param>
		/// <param name="contextKey"></param>
		/// <returns></returns>
		//[WebMethod()]
		//public string[] GetUniversity(string prefixText, int count,string contextKey) {
		//    return this.GetList(_DataSetCache.g.Tables[0], "Xueyuan", prefixText, count, contextKey);
		//}
		#endregion
		#region 学院提示

		/// <summary>
		/// 显示学院的列表
		/// </summary>
		/// <param name="prefixText"></param>
		/// <param name="count"></param>
		/// <param name="contextKey"></param>
		/// <returns></returns>
		[WebMethod()]
		static public string[] GetXueyuan(string prefixText, int count, string contextKey) {
			return GetList(DataSetCache.XueYuanList(contextKey), "Xueyuan", prefixText, count, contextKey);
		}
		#endregion
		#region 寝室提示
		[WebMethod()]
		static public string[] GetQinshi(string prefixText, int count, string contextKey) {
			return GetList(DataSetCache.QinshiList(contextKey), "Qinshi", prefixText, count, contextKey);
		}
		#endregion
		static string[] GetList(DataTable dt, string Field, string prefixText, int count, string contextKey) {
			if (count == 0) count = 5;
			List<string> items = new List<string>(count);
				
			foreach (DataRow dr in dt.Select(string.Format("{1} like '%{0}%'", Regular.HuaNumtoNumber(Regular.ClearWildcard(prefixText)), Field))) {
				if (items.Count >= count) break;
				if (dr[Field].ToString() != contextKey && !items.Contains(dr[Field].ToString()))
					items.Add(dr[Field].ToString());
			}
			foreach (DataRow dr in dt.Select(string.Format("{1} like '%{0}%'", Regular.ClearWildcard(prefixText), Field))) {
				if (items.Count >= count) break;
				if (dr[Field].ToString() != contextKey && !items.Contains(dr[Field].ToString()))
					items.Add(dr[Field].ToString());
			}

			return items.ToArray();
		}
		
	}
}
