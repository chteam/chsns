using Microsoft.AspNetCore.Mvc;
using CHSNS.Model;
using System.Linq.Expressions;
using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CHSNS {
    public static class DropDownListRenderExt {
        public static void RenderShowLevel(this HtmlHelper Html,string name){
            Html.RenderPartial("ShowLevel", new ShowLevelOption(name, 0));
        }
        public static void RenderShowLevel(this HtmlHelper Html, string name,object selectedValue) {
            Html.RenderPartial("ShowLevel", new ShowLevelOption(name, selectedValue));
        }
        public static IHtmlContent RenderDropDownListFor<T>(this HtmlHelper<T> Html, Expression<Func<T, object>> func, string dataKey)
        {
           // var model = new DropDownListModel<T> { Func = func, DataKey = dataKey };
           // Html.RenderPartial("DropDownList", model);
 //           return IHtmlContent.Create( Html.LabelFor(func).ToString() +
 //Html.DropDownListFor(func, new SelectList(ConfigSerializer.Instance.Load<List<SelectListItem>>(dataKey), "Value", "Text"))
 //.ToString()
 //)
 //;
            throw new NotImplementedException();
        }
        public static SelectList GetSelectList(this HtmlHelper html, string key) {
            //return new SelectList(ConfigSerializer.Instance.Load<List<SelectListItem>>(key), "Value", "Text");
            throw new NotImplementedException();
        }
    }
    public class DropDownListModel<T> {
        public Expression<Func<T, object>> Func { get; set; }
        public string DataKey { get; set; }
    }
}
