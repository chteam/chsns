using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.Routing;
using System.Web.Mvc;
using System.Web;

namespace CHSNS.Web {
	public partial class _Default : Page {
		public void Page_Load(object sender, System.EventArgs e) {
            HttpContext.Current.RewritePath(Request.ApplicationPath);
            IHttpHandler httpHandler = new MvcHttpHandler();
            httpHandler.ProcessRequest(HttpContext.Current);
		}
	}
}
