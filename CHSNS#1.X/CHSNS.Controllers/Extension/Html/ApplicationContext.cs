using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CHSNS.Config;
using System.Web;

namespace CHSNS
{
    public static class HtmlHelperContext
    {
        public static SiteConfig CHSite(this HttpApplicationStateBase application){
            return new SiteConfig();
            // TODO:
        }
    }
}
