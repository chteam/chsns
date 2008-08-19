namespace ChAlumna {
	using System;
	using System.Web;
	/// <summary>
	/// 封装系统的HttpServerUtility类
	/// </summary>
	public class ChServer {
		static public string MapPath(string p) {
			return HttpContext.Current.Server.MapPath(p);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		static public string UrlEncode(string s){
			return HttpUtility.UrlEncode(s);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		static public string UrlEncode(object s) {
			return HttpUtility.UrlEncode(s.ToString());
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		static public string UrlDecode(string s) {
			return HttpUtility.UrlDecode(s);
		}
		static public string HtmlEncode(string s) {
			return HttpUtility.HtmlEncode(s);
		}
		static public string HtmlDecode(string s) {
			return HttpUtility.HtmlDecode(s);
		}
	}
}
