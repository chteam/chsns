namespace CHSNS.Result {
    using System.Web.Mvc;

    public class XmlViewResult : ViewResult {
		private readonly string _viewName;

		public XmlViewResult() : this("") { }

		public XmlViewResult(string viewName) {
			_viewName = viewName;
		}

		public override void ExecuteResult(ControllerContext context) {
			if (!string.IsNullOrEmpty(_viewName))
				ViewName = _viewName;

			TempData = context.Controller.TempData;
			ViewData = context.Controller.ViewData;

			base.ExecuteResult(context);

			context.HttpContext.Response.ContentType = "text/xml";
		}
	}
}