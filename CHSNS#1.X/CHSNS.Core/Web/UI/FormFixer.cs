using System;
using System.IO;
using System.Web;

namespace Chsword.Web.UI {

	public class FormFixerHtml32TextWriter : System.Web.UI.Html32TextWriter {
		private string _url; // ¼ÙµÄURL
		public FormFixerHtml32TextWriter(TextWriter writer)
			: base(writer) {
			_url = HttpContext.Current.Request.RawUrl;
		}
		public override void WriteAttribute(string name, string value, bool encode) {
			if (_url != null && string.Compare(name, "action", true) == 0) {
				value = _url;
			}
			base.WriteAttribute(name, value, encode);
		}
	}
	public class FormFixerHtmlTextWriter : System.Web.UI.HtmlTextWriter {
		private string _url;
		public FormFixerHtmlTextWriter(TextWriter writer): base(writer) {
			_url = HttpContext.Current.Request.RawUrl;
		}
		public override void WriteAttribute(string name, string value, bool encode) {
			if (_url != null && string.Compare(name, "action", true) == 0) {
				value = _url;
			}
			base.WriteAttribute(name, value, encode);
		}
	}
}
