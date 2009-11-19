using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Collections;
using System.Globalization;
using System.Web;
using System.Web.Routing;
namespace CHSNS {
    public static class DropDownListExt {
        [Obsolete("Beta中的使用方法")]
        static public string DropDownList(this HtmlHelper Html, string optional, string name, IEnumerable<SelectListItem> ie, object htmlAttr) {
            return Html.DropDownList(name, ie, optional, htmlAttr).ToHtmlString();
        }
        [Obsolete("Beta中的使用方法")]
        static public string DropDownList(this HtmlHelper Html, string optional, string name, IEnumerable<SelectListItem> ie) {
            return Html.DropDownList(name, ie, optional).ToHtmlString();
        }
        [Obsolete("Beta中的使用方法")]
        static public string DropDownList(this HtmlHelper Html, string optional, string name, object htmlAttr) {
            IEnumerable<SelectListItem> selectList = Html.GetSelectData(name);
            return Html.SelectInternal(
                optional /* optionLabel */, 
                name, selectList,
                true /* usedViewData */,
                false /* allowMultiple */,
                new RouteValueDictionary(htmlAttr) /* htmlAttributes */);
        }
        //   <%=Html.DropDownList("请选择", "area0", new { onchange = "getseldata(this,'#area1','EntryArea')", style = "width: 100px; height:20px;" })%>
        #region system.web.mvc
        private static IEnumerable<SelectListItem> GetSelectData(this HtmlHelper htmlHelper, string name) {
            object o = null;
            if (htmlHelper.ViewData != null) {
                o = htmlHelper.ViewData.Eval(name);
            }
            if (o == null) {
                throw new InvalidOperationException(
                    String.Format(
                        CultureInfo.CurrentUICulture,
                        "There is no ViewData item with the key '{0}' of type '{1}'.",
                        name,
                        "IEnumerable<SelectListItem>"));
            }
            IEnumerable<SelectListItem> selectList = o as IEnumerable<SelectListItem>;
            if (selectList == null) {
                throw new InvalidOperationException(
                    String.Format(
                        CultureInfo.CurrentUICulture,
                       "The ViewData item with the key '{0}' is of type '{1}' but needs to be of type '{2}'.",
                        name,
                        o.GetType().FullName,
                        "IEnumerable<SelectListItem>"));
            }
            return selectList;
        }
        private static string ListItemToOption(SelectListItem item) {
            TagBuilder builder = new TagBuilder("option") {
                InnerHtml = HttpUtility.HtmlEncode(item.Text)
            };
            if (item.Value != null) {
                builder.Attributes["value"] = item.Value;
            }
            if (item.Selected) {
                builder.Attributes["selected"] = "selected";
            }
            return builder.ToString(TagRenderMode.Normal);
        }
        private static object GetModelStateValue(this HtmlHelper htmlHelper, string key, Type destinationType) {
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(key, out modelState)) {
                return modelState.Value.ConvertTo(destinationType, null /* culture */);
            }
            return null;
        }
          private static string SelectInternal(this HtmlHelper htmlHelper, string optionLabel, string name, IEnumerable<SelectListItem> selectList, bool usedViewData, bool allowMultiple, IDictionary<string, object> htmlAttributes) {
            if (String.IsNullOrEmpty(name)) {
                throw new ArgumentException("Value cannot be null or empty.", "name");
            }
            if (selectList == null) {
                throw new ArgumentNullException("selectList");
            }

            object defaultValue = (allowMultiple) ? htmlHelper.GetModelStateValue(name, typeof(string[])) : htmlHelper.GetModelStateValue(name, typeof(string));

            // If we haven't already used ViewData to get the entire list of items then we need to
            // use the ViewData-supplied value before using the parameter-supplied value.
            if (!usedViewData) {
                if (defaultValue == null) {
                    defaultValue = htmlHelper.ViewData.Eval(name);
                }
            }

            if (defaultValue != null) {
                IEnumerable defaultValues = (allowMultiple) ? defaultValue as IEnumerable : new[] { defaultValue };
                IEnumerable<string> values = from object value in defaultValues select Convert.ToString(value, CultureInfo.CurrentCulture);
                HashSet<string> selectedValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);
                List<SelectListItem> newSelectList = new List<SelectListItem>();

                foreach (SelectListItem item in selectList) {
                    item.Selected = (item.Value != null) ? selectedValues.Contains(item.Value) : selectedValues.Contains(item.Text);
                    newSelectList.Add(item);
                }
                selectList = newSelectList;
            }

            // Convert each ListItem to an <option> tag
            StringBuilder listItemBuilder = new StringBuilder();

            // Make optionLabel the first item that gets rendered.
            if (optionLabel != null) {
                listItemBuilder.AppendLine(ListItemToOption(new SelectListItem { Text = optionLabel, Value = String.Empty, Selected = false }));
            }

            foreach (SelectListItem item in selectList) {
                listItemBuilder.AppendLine(ListItemToOption(item));
            }

            TagBuilder tagBuilder = new TagBuilder("select") {
                InnerHtml = listItemBuilder.ToString()
            };
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("name", name);
            tagBuilder.GenerateId(name);
            if (allowMultiple) {
                tagBuilder.MergeAttribute("multiple", "multiple");
            }

            // If there are any errors for a named field, we add the css attribute.
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(name, out modelState)) {
                if (modelState.Errors.Count > 0) {
                    tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
                }
            }

            return tagBuilder.ToString(TagRenderMode.Normal);
        }
    
        #endregion
    }
}