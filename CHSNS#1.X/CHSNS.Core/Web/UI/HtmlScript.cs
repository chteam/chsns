using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Security.Permissions;
namespace Chsword.Web.UI {
	/// <summary>
	/// 可以生成script标签
	/// </summary>
	[ControlBuilder(typeof(HtmlEmptyTagControlBuilder)), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class HtmlScript : HtmlControl {
		// Methods
		public HtmlScript(): base("script") {
		}
		protected override void Render(HtmlTextWriter writer) {
			writer.WriteBeginTag(this.TagName);
			this.RenderAttributes(writer);
			writer.Write(">");
			writer.WriteEndTag(TagName);
			writer.Write("\n");
		}
		protected override void RenderAttributes(HtmlTextWriter writer) {
			if (!string.IsNullOrEmpty(this.Src)) {
				base.Attributes["src"] = base.ResolveClientUrl(this.Src);
			}
			base.Attributes["type"] = "text/javascript";
			base.RenderAttributes(writer);
		}
		/// <summary>
		/// 脚本的URL
		/// </summary>
		[UrlProperty]
		[DefaultValue("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual string Src {
			get {
				string text = base.Attributes["src"];
				if (text == null) {
					return string.Empty;
				}
				return text;
			}
			set {
				base.Attributes["src"] = MapStringAttributeToString(value);
			}
		}
		string MapStringAttributeToString(string s) {
			if ((s != null) && (s.Length == 0)) {
				return null;
			}
			return s;
		}
	}
}
