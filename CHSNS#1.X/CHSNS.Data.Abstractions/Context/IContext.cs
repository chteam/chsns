using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHSNS.Config;
using CHSNS.Data;

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
    }
}
