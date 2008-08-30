using System.Web;

namespace CHSNS
{
	/// <summary>
	/// 封装系统的HttpServerUtility类
	/// </summary>
	public class CHServer
	{
		public static string MapPath(string p)
		{
			return HttpContext.Current.Server.MapPath(p);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string UrlEncode(string s)
		{
			return HttpUtility.UrlEncode(s);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string UrlEncode(object s)
		{
			return HttpUtility.UrlEncode(s.ToString());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string UrlDecode(string s)
		{
			return HttpUtility.UrlDecode(s);
		}

		public static string HtmlEncode(string s)
		{
			return HttpUtility.HtmlEncode(s);
		}

		public static string HtmlDecode(string s)
		{
			return HttpUtility.HtmlDecode(s);
		}
	}
}