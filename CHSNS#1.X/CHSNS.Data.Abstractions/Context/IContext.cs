using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using CHSNS.Config;
using CHSNS.Service;

namespace CHSNS
{
    public interface IContext
    {
        ICache Cache { get; set; }
        IUser User { get; set; }
        ICookies Cookies { get; set; }
        IOnline Online { get; set; }
        SiteConfig Site { get; set; }
        ISerializer ConfigSerializer { get; set; }
        IDBManager DBManager { get; set; }
        HttpContextBase HttpContext { get; set; }
    }
}
