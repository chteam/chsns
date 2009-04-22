using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;


namespace CHSNS
{
	public static class StringExtension {
		/// <summary>
		/// 去除末尾部分字符串
		/// "asdfg".TrimEnd("fg")
		/// </summary>
		/// <param name="str"></param>
		/// <param name="ends"></param>
		/// <returns></returns>
		public static string TrimEnd(this string str, string ends){
			if (str.EndsWith(ends))
				return str.Substring(0, str.Length - ends.Length);
			return str;
		}
		/// <summary>
		/// 返回部分字符串，而没有错误
		/// "1234567890".SubStr(5)
		/// </summary>
		/// <param name="str"></param>
		/// <param name="n"></param>
		/// <returns></returns>
		public static string SubStr(this string str, int n){
			if (str.Length > n) return str.Substring(0, n);
			return str;
		}

		/// <summary>
		/// 对字符串进行MD5加密
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string ToMd5(this string str) {
            var data=MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(str.Trim()));
            return BytesToHexString(data);
			//FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
		}
        private static string BytesToHexString(byte[] data) //加密转码
              {
            var codes = new StringBuilder();
            for (var i = 0; i < data.Length; ++i) {
                codes.Append(data[i].ToString("x2"));
            }
            return codes.ToString().ToUpper();
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
