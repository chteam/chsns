using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.Routing;
using System.Web;

namespace CHSNS.Web {
	public partial class _Default : Page {
		public void Page_Load(object sender, System.EventArgs e) {
            string originalPath = Request.Path;
            HttpContext.Current.RewritePath(Request.ApplicationPath, false);
            IHttpHandler httpHandler = new MvcHttpHandler();
            httpHandler.ProcessRequest(HttpContext.Current);
            HttpContext.Current.RewritePath(originalPath, false);
		}
	}
}
