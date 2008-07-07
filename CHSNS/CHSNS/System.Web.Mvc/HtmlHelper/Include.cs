using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHSNS;

namespace System.Web.Mvc {
	static public class Include {
		static public string Script(this HtmlHelper h,String fn){
			return
				string.Format("<script type=\"text/javascript\" src=\"{0}Js/{1}.js\"></script>"
				, SiteConfig.Current.Path, fn.TrimEnd(".js".ToCharArray()));
		}
		static public string CSSLink(this HtmlHelper h, String fn) {
			return	string.Format(
				"<link href=\"{0}Style/{1}/{2}.css\" rel=\"stylesheet\" type=\"text/css\" />"
				, SiteConfig.Current.Path
				,SiteConfig.Current.Style
				, fn.TrimEnd(".css".ToCharArray())
				);
		}
	}
}
