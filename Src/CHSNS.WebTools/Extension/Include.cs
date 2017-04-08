using System;
using Microsoft.AspNetCore.Mvc;

namespace CHSNS.Helper
{
    using System.Web;
    using CHSNS.Core;

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
		static public IHtmlString CSSLink(this HtmlHelper html, String fn)
		{

		    var chsite = new WebContext(html.ViewContext.HttpContext).Site;
			var link= string.Format(
				"<link href=\"{0}Content/{1}/{2}.css\" rel=\"stylesheet\" type=\"text/css\" />"
                , chsite.BaseConfig.Path
                , chsite.BaseConfig.Style
				, fn.TrimEnd(".css")
				);
            return new IHtmlContent(link);
		}
	}
}