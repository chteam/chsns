/*
 * Created by 邹健
 * Date: 2007-12-13
 * Time: 9:51
 * 
 * 
 */
namespace CHSNS
{
	
using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

using Chsword;

	/// <summary>
	/// Description of StyleSheet.
	/// </summary>
	public class StyleSheet
	{
		static public string filter(string s){
			s = ChServer.HtmlEncode(ReplaceXiaoNei(Regular.FormatRichEdit(s)));
			if(s.Length>10000)
				s=s.Substring(0,10000);
			 return s;
		}
		static public string ReplaceXiaoNei(string s) {
			string f = "Format";
			CHCache cache = new CHCache();
			XmlDocument dom = new XmlDocument();
			if (CHCache.IsNullorEmpty(f))
				if (!CHCache.SetCache(f))
					return "过滤配置文件无法加载";
			dom.LoadXml(HttpContext.Current.Cache[f].ToString());
			XmlNodeList nl = dom.SelectNodes("/root/item");
			foreach (XmlNode xn in nl) {
				string[] r = xn.InnerText.Split('|');
				s = Regex.Replace(s,
					r[0],
					r[1], RegexOptions.IgnoreCase);
			}
			return s;
		}
	}
}
