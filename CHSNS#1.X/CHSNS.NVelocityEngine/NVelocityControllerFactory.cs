using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Generic;
using System.Linq;

namespace CHSNS.NVelocityEngine
{

	public class NVelocityControllerFactory : DefaultControllerFactory
	{
		protected override IController CreateController(RequestContext requestContext, string controllerName) {
			Controller controller = (Controller)base.CreateController(requestContext, controllerName);
			controller.ViewEngine = new NVelocityViewEngine();//修改默认的视图引擎为我们刚才创建的视图引擎
			return controller;
		}
	}
}