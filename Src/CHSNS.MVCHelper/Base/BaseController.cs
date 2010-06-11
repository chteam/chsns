using System.Web.Mvc;
using CHSNS.Service;

namespace CHSNS.Controllers {

    //	[Helper(typeof(StringHelper),"String")]
    [OnlineFilter]
    [HandleError]
    abstract public class BaseController : NewBaseController {
        #region Êý¾Ý²Ù×÷
        private DataManager _dataExt;
        protected DataManager DataExt {
            get { return _dataExt ?? (_dataExt = new DataManager()); }
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext) {
            if (_dataExt != null)
                DataExt.Dispose();
        }
        #endregion
    }
}