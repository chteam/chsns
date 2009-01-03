using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
namespace CHSNS.Helper {
	public static class HtmlRenderExt {
		public static void MessageBox(this HtmlHelper Html){
			Html.RenderPartial("Message_Box");
		}
	}
}
