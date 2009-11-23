using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CHSNS.NVelocityEngine {
	public class NVelocityViewLocator : IViewLocator {

		#region IViewLocator 成员

		public string GetMasterLocation(System.Web.Routing.RequestContext requestContext, string masterName) {
			return string.Format(
				"/Shared/{0}.vm", masterName);
		}

		public string GetViewLocation(System.Web.Routing.RequestContext requestContext, string viewName) {
			return string.Format(
					"/{1}/{0}.vm", viewName, requestContext.RouteData.Values["Controller"]);
		}

		#endregion
	}
}
