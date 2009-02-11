using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CHSNS
{
    public static class ViewContextExt
    {
        public static IContext CH(this ViewContext v) { return new CHContext(); }
    }

}
