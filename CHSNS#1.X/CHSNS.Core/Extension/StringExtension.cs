
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Web.Security;

namespace CHSNS
{
	public static class StringExtension {
		/// <summary>
		/// 对字符串进行MD5加密
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string ToMd5(this string str) {
			return FormsAuthentication.HashPasswordForStoringInConfigFile(str.Trim(), "MD5");
		}
		/// <summary>
		/// NoHtml
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		static public string NoHtml(this string str) {
			str = Regex.Replace(str,@"(<br\s*/?>)","[br]", RegexOptions.IgnoreCase);
			str = Regex.Replace(str,
				  @"(<[^>]+>)",
					"", RegexOptions.IgnoreCase);
			str = str.Replace("<", "");
			str = str.Replace(">", "");
			return str.Replace("[br]", "<br />");
		}
	}
}
