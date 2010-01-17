
using System.Web;
using System.Web.Mvc;
using System;
using CHSNS.Service;
using CHSNS.ViewModel;

namespace CHSNS.Controllers {

    //	[Helper(typeof(StringHelper),"String")]
    [OnlineFilter]
    [HandleError]
    abstract public class BaseController : NewBaseController {
        #region Êý¾Ý²Ù×÷
        private DBManager _dbExt;
        protected DBManager DbExt {
            get {
                if (_dbExt == null)
                    _dbExt = new DBManager();
                return _dbExt;
            }
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext) {
            if (_dbExt != null)
                DbExt.Dispose();
        }
        #endregion
    }
}