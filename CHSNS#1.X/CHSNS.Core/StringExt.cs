using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
