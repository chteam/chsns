using System.Security.Cryptography;
using System.Text;

namespace CHSNS
{
    using CHSNS.Encrypt;

    public static class Md5Extension
    {
        /// <summary>
        /// 对字符串进行MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMd5(this string str) {
            using (var md5 = MD5.Create())
            {
                var data = md5.ComputeHash(Encoding.UTF8.GetBytes(str.Trim()));
                return data.ToHexUpperString();
            }
            //FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        }
    }
}