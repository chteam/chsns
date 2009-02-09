using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHSNS.Config;
using System.Web.Mvc;
using CHSNS.Controllers;

namespace CHSNS
{
    public static class ViewExtension
    {
        public static SiteConfig Site(this ViewPage vp) {
            return (vp.ViewContext.Controller as BaseController).CHContext.Site;
        }
        public static SiteConfig Site(this ViewMasterPage vp)
        {
            return (vp.ViewContext.Controller as BaseController).CHContext.Site;
        }
        public static SiteConfig Site(this ViewUserControl vp)
        {
            return (vp.ViewContext.Controller as BaseController).CHContext.Site;
        }
    }
}
