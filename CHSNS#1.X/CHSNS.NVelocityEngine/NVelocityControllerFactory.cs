using System.Web.Mvc;
using System.Web.Routing;
namespace CHSNS.NVelocityEngine {
	/// <summary>
	/// NVelocity引擎的工厂
	/// </summary>
	public class NVelocityControllerFactory : DefaultControllerFactory {
		protected override IController CreateController(RequestContext requestContext, string controllerName) {
			Controller controller = (Controller)base.CreateController(requestContext, controllerName);
			controller.ViewEngine = new NVelocityViewEngine();
			return controller;
		}
	}
}