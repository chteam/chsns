
namespace System
{
	using System.Web.Security;
	public static class StringMd5Extension
	{
		/// <summary>
		/// Md5加密
		/// </summary>
		/// <param name="str">要加密的字符串</param>
		/// <param name="code">生成MD5码的位数16/32</param>
		/// <returns>返回MD5码</returns>
		static public string MD5Encrypt(this string str, int code) {
			if (code == 16) {
				return FormsAuthentication.HashPasswordForStoringInConfigFile(str.Trim(), "MD5").ToLower().Substring(8, 16);
			}
			if (code == 32) {
				return FormsAuthentication.HashPasswordForStoringInConfigFile(str.Trim(), "MD5");
			}
			return "00000000000000000000000000000000";
		}
		static public string Md5_32(this string str) {
			return str.MD5Encrypt(32);
		}
		static public string Md5_16(this string str) {
			return str.MD5Encrypt(16);
		}
	}
}