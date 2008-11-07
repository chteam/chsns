
using System.Web.Security;

namespace CHSNS
{
    public static  class StringExt
    {
        public static string  ToMd5(this string str){
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str.Trim(), "MD5");
        }
    }
}
