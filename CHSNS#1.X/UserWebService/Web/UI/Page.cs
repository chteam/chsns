using System;
using System.Collections.Generic;
using System.Web;

using System.Web.UI.HtmlControls;
using System.Xml;
using Chsword.Web.UI;
using CHSNS;
namespace Chsword.Web.UI {
	/// <summary>
	/// 作者 邹健
	/// 日期 20070202
	/// 重载的Page类。
	/// </summary>
	public class Page : System.Web.UI.Page {
		/// <summary>
		/// 重载的Render函数。
		/// </summary>
		/// <param name="writer">HtmlTextWriter。</param>
		protected override void Render(System.Web.UI.HtmlTextWriter writer) {
			if (writer is System.Web.UI.Html32TextWriter) {
				writer = new FormFixerHtml32TextWriter(writer.InnerWriter);
			} else {
				writer = new FormFixerHtmlTextWriter(writer.InnerWriter);
			}
			Title = string.Format("{0} - {1}",Title,ChCache.GetConfig("WebName"));
			base.Render(writer);
		}
		/// <summary>
		/// 设置Html标签内，的Link标签，如Css
		/// </summary>
		/// <param name="cssfile">Css文件。</param>
		protected void SetHtmlLink(string cssfile) {
			HtmlLink myHtmlLink = new HtmlLink();
			myHtmlLink.Href = cssfile;
			myHtmlLink.Attributes.Add("rel", "stylesheet");
			myHtmlLink.Attributes.Add("type", "text/css");
			Page.Header.Controls.Add(myHtmlLink);
		}
		/// <summary>
		/// 设置script现在只能是type=text/javsscript的
		/// </summary>
		/// <param name="src">脚本地址</param>
		protected void SetHtmlScript(string src) {
			HtmlScript myHtmlScript = new HtmlScript();
			myHtmlScript.Src = src;
			Page.Header.Controls.Add(myHtmlScript);
		}
		string isAdmin() {
			if (CHUser.IsAdmin)
				return " or @name=\"adminuser\"";
			else
				return "";
		}
		protected void SetCssJs(string Config_fileName){
			string Right = ChCache.GetConfig("Page",Config_fileName);
			if (!string.IsNullOrEmpty(Right.Trim())){
				if(!Right.Contains(string.Format("|{0}|",CHUser.Status.ToString())))
				{
					Response.Redirect(string.Format("/NoRight.aspx?type={0}",CHUser.Status));
				}
			}
			List<string> list = new List<string>();
			list.Add("StyleSheet");
			list.Add("Script");
			string xpath = "/root/page[@name=\"{0}\"{1}]/{2}";
			System.Xml.XmlDocument dom = new System.Xml.XmlDocument();
			foreach (string f in list) {
				if (ChCache.IsNullorEmpty(f))
					if (!ChCache.SetCache(f))
					return;
				dom.LoadXml(HttpContext.Current.Cache[f].ToString());
				if (f == "StyleSheet") {
					XmlNodeList nlcss = dom.SelectNodes(string.Format(xpath, Config_fileName, isAdmin(), "link"));
					foreach (XmlNode xn in nlcss) {
						SetHtmlLink(xn.Attributes["href"].Value);
					}
				}
				if (f == "Script") {
					XmlNodeList nljs = dom.SelectNodes(string.Format(xpath, Config_fileName, isAdmin(),"script"));
					foreach (XmlNode xn in nljs) {
						this.SetHtmlScript(xn.Attributes["src"].Value);
					}
					XmlNodeList nlbody = dom.SelectNodes(string.Format(xpath, Config_fileName, isAdmin(),"bodyscript"));
					System.Web.UI.ClientScriptManager cs = Page.ClientScript;
					foreach (XmlNode xn in nlbody) {
						if (!cs.IsClientScriptIncludeRegistered(xn.Attributes["src"].Value)) {
							cs.RegisterClientScriptInclude(xn.Attributes["src"].Value, xn.Attributes["src"].Value);
						}
					}
				}
			}
		}
		/// <summary>
		/// 得到当前页的查询字符串
		/// </summary>
		/// <param name="QueryStringName"></param>
		/// <returns></returns>
		protected string QueryString(string QueryStringName) {
			if (string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString[QueryStringName]))
				return string.Empty;
			else
				return System.Web.HttpContext.Current.Request.QueryString[QueryStringName];
		}
		protected int QueryNum(string QueryStringName) {
			int ret = 0;
			int.TryParse(System.Web.HttpContext.Current.Request.QueryString[QueryStringName], out ret);
			return ret;
		}
	}
}
