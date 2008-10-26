using System;
using CHSNS;
using CHSNS.Config;
using CHSNS.Models;
using System.Web.Mvc;
using CHSNS.Data;
namespace CHSNS.Controllers {
	//[Layout("basemaster")]

	//[Helper(typeof(ChHelper))]
	[HandleError]
	abstract public class BaseBlockController : Controller {
		public Boolean IsPost {
			get {
				return Request.Form.Count != 0;
			}
		}

		private IDBExt _dbext;
		protected IDBExt DBExt {
			get {
				if (_dbext == null)
					_dbext = new Data.DBExt();
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
	}
}
