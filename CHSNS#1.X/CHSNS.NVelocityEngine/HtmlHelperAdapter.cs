using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
//using System.Web.Mvc;
//using Microsoft.Web.Mvc;
using System.Web.Routing;
using System.Web;
namespace CHSNS.NVelocityEngine {
	public class HtmlHelperAdapter : HtmlHelper {
		HtmlHelper HtmlHelper { get; set; }
		public HtmlHelperAdapter(System.Web.Mvc.ViewContext viewContext, System.Web.Mvc.IViewDataContainer viewDataContainer)
			:base(viewContext,viewDataContainer){}
		public  void RenderAction(string actionName) {
			RenderAction(actionName, null);
		}

		public  void RenderAction(string actionName, string controllerName) {
			RenderAction(actionName, controllerName, (RouteValueDictionary)null);
		}

		public  void RenderAction(string actionName, string controllerName, object values) {
			RenderAction(actionName, controllerName, new RouteValueDictionary(values));
		}

		public  void RenderAction( string actionName, string controllerName, RouteValueDictionary values) {
			RouteValueDictionary dictionary = null;
			if (values != null) {
				dictionary = new RouteValueDictionary(values);
			} else {
				dictionary = new RouteValueDictionary();
			}
			foreach (KeyValuePair<string, object> pair in this.ViewContext.RouteData.Values) {
				if (!dictionary.ContainsKey(pair.Key)) {
					dictionary.Add(pair.Key, pair.Value);
				}
			}
			if (!dictionary.ContainsKey("action")) {
				dictionary["action"] = actionName;
			}
			if (!dictionary.ContainsKey("controller") && !string.IsNullOrEmpty(controllerName)) {
				dictionary["controller"] = controllerName;
			}
			RenderRoute(dictionary);
		}

		public void RenderRoute( RouteValueDictionary values) {
			RouteData routeData = new RouteData();
			foreach (KeyValuePair<string, object> pair in values) {
				routeData.Values.Add(pair.Key, pair.Value);
			}
			HttpContextBase httpContext = this.ViewContext.HttpContext;
			RequestContext context = new RequestContext(httpContext, routeData);
			new RenderActionMvcHandler(context).ProcessRequestInternal(httpContext);
		}

		// Nested Types
		private class RenderActionMvcHandler : MvcHandler {
			// Methods
			public RenderActionMvcHandler(RequestContext context)
				: base(context) {
			}

			public void ProcessRequestInternal(HttpContextBase httpContext) {
				base.ProcessRequest(httpContext);
			}
		}

	}
}
