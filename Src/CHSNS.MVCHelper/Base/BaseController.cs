

namespace CHSNS.Controllers {
    using System.Web.Mvc;
    using CHSNS.Service;
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

        private GolbalService _global;
        public GolbalService Global
        {
            get { return _global ?? (_global = new GolbalService(CHContext)); }
        }
    }
}