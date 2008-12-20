
using System.Web;
using System.Web.Mvc;
using System;
using CHSNS.Data;
using CHSNS.Filter;

namespace CHSNS.Controllers {
	
//	[Helper(typeof(StringHelper),"String")]
	[OnlineFilter]
	[HandleError]
	abstract public class BaseController : Controller  {
		public Boolean IsPost {
			get {
				return Request.Form.Count != 0;
			}
		}
		#region Êý¾Ý²Ù×÷
		private IDBExt _dbext;
		protected IDBExt DBExt {
			get {
				if (_dbext == null)
					_dbext = new DBExt();
				return _dbext;
			}
			set {
				throw new NotImplementedException();
			}
		}

		protected override void OnResultExecuted(ResultExecutedContext filterContext) {
			if (_dbext != null)
				DBExt.Dispose();
		}
		#endregion
		public string Title {
			set {
				ViewData["Page_Title"] = value;
			}
		}

		public string Message {
			set {
				TempData["msg"] = value;
			}
		}
		protected static void InitPage(ref int? p) {
			if (!p.HasValue || p == 0) p = 1;
		}
		protected override void OnResultExecuting(ResultExecutingContext filterContext) {
			if (ViewData.ContainsKey("Page_Title"))
				ViewData["Page_Title"] += "-" + Config.SiteConfig.Current.BaseConfig.Title;
		}
		protected static void Validate404(object obj) {
			if (obj == null)
				throw new HttpException(404, "Not Found");
		}
	}
}