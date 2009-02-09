using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS
{
    public class ViewPage : System.Web.Mvc.ViewPage
    {
        public IContext CHContext { get { return new CHContext(); } }
    }
    public class ViewPage<TModel> : System.Web.Mvc.ViewPage<TModel> where TModel : class
    {
        public IContext CHContext { get { return new CHContext(); } }
    }
    public class ViewMasterPage : System.Web.Mvc.ViewMasterPage
    {
        public IContext CHContext { get { return new CHContext(); } }
    }
    public class ViewMasterPage<TModel> : System.Web.Mvc.ViewMasterPage<TModel> where TModel : class
    {
        public IContext CHContext { get { return new CHContext(); } }

    }
    public class ViewUserControl : System.Web.Mvc.ViewUserControl
    {
        public IContext CHContext { get { return new CHContext(); } }
    }
    public class ViewUserControl<TModel> : System.Web.Mvc.ViewUserControl<TModel> where TModel : class
    {
        public IContext CHContext { get { return new CHContext(); } }
    }
}
