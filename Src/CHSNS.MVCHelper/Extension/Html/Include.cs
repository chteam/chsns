using System;
using System.Web.Mvc;
 
namespace CHSNS.Helper
{
	static public class Include {
        //static public string Script(this HtmlHelper h, String fn) {
        //    var chsite = CH.Context.Site;
        //    if (!fn.StartsWith("/"))
        //        fn = string.Format("{0}Javascript/{1}.js",
        //            chsite.BaseConfig.Path,
        //            fn.TrimEnd(".js"));
        //    return
        //        string.Format("<script type=\"text/javascript\" src=\"{0}\"></script>"
        //                      , fn);
        //}
		static public string CSSLink(this HtmlHelper h, String fn) {
            var chsite = CH.Context.Site;
			return string.Format(
				"<link href=\"{0}Style/{1}/{2}.css\" rel=\"stylesheet\" type=\"text/css\" />"
                , chsite.BaseConfig.Path
                , chsite.BaseConfig.Style
				, fn.TrimEnd(".css")
				);
		}
	}
}