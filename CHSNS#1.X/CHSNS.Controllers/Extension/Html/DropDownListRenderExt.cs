using System.Web.Mvc;
using System.Web.Mvc.Html;
using CHSNS.Model;

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
