using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using CHSNS.ModelPas;
using CHSNS.Models;

namespace CHSNS {
	public static class DropDownListRenderExt {
		public static void RenderShowLevel(this HtmlHelper Html,string name){
			Html.RenderPartial("ShowLevel", new ShowLevelOption(name, 0));
		}
		public static void RenderShowLevel(this HtmlHelper Html, string name,object selectedValue) {
			Html.RenderPartial("ShowLevel", new ShowLevelOption(name, selectedValue));
		}
	}
}
