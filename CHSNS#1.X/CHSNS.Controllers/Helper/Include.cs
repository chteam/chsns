using System;
using CHSNS.Config;
using System.Web.Mvc;

namespace CHSNS.Helper
{
	static public class Include {
		static public string Script(this HtmlHelper h, String fn) {
			if (!fn.StartsWith("/"))
				fn = string.Format("{0}Javascript/{1}.js", SiteConfig.Current.Path, fn.TrimEnd(".js".ToCharArray()));

			return
				string.Format("<script type=\"text/javascript\" src=\"{0}\"></script>"
				              , fn);
		}
		static public string CSSLink(this HtmlHelper h, String fn) {
			return string.Format(
				"<link href=\"{0}Style/{1}/{2}.css\" rel=\"stylesheet\" type=\"text/css\" />"
				, SiteConfig.Current.Path
				, SiteConfig.Current.Style
				, fn.TrimEnd(".css".ToCharArray())
				);
		}
	}
}