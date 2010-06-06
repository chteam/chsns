using System.Web.Mvc;
using System.Web.Mvc.Html;
using CHSNS.Model;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;

namespace CHSNS {
	public static class DropDownListRenderExt {
		public static void RenderShowLevel(this HtmlHelper Html,string name){
			Html.RenderPartial("ShowLevel", new ShowLevelOption(name, 0));
		}
		public static void RenderShowLevel(this HtmlHelper Html, string name,object selectedValue) {
			Html.RenderPartial("ShowLevel", new ShowLevelOption(name, selectedValue));
		}
        public static MvcHtmlString RenderDropDownListFor<T>(this HtmlHelper<T> Html, Expression<Func<T, object>> func, string dataKey)
        {
           // var model = new DropDownListModel<T> { Func = func, DataKey = dataKey };
           // Html.RenderPartial("DropDownList", model);
            return MvcHtmlString.Create( Html.LabelFor(func).ToString() +
 Html.DropDownListFor(func, new SelectList(CH.Context.ConfigSerializer.Load<List<SelectListItem>>(dataKey), "Value", "Text"))
 .ToString()
 )
 ;
        }
        public static SelectList GetSelectList(this HtmlHelper html, string key) {
            return new SelectList(CH.Context.ConfigSerializer.Load<List<ListItem>>(key), "Value", "Text");
        }
	}
    public class DropDownListModel<T> {
        public Expression<Func<T, object>> Func { get; set; }
        public string DataKey { get; set; }
    }
}
