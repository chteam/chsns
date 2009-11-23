using System.Web.Mvc;

namespace CHSNS {
	public class XmlViewResult : ViewResult {
		private readonly string viewName;

		public XmlViewResult() : this("") { }

		public XmlViewResult(string viewName) {
			this.viewName = viewName;
		}

		public override void ExecuteResult(ControllerContext context) {
			if (!string.IsNullOrEmpty(viewName))
				ViewName = viewName;

			TempData = context.Controller.TempData;
			ViewData = context.Controller.ViewData;

			base.ExecuteResult(context);

			context.HttpContext.Response.ContentType = "text/xml";
		}
	}
}