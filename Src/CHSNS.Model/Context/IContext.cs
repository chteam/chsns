using System.Web;
using CHSNS.Config;

namespace CHSNS {
    public interface IContext {
        IPathGenerate Path { get; set; }
        IUser User { get; }
        ICookies Cookies { get; set; }
        IOnline Online { get; set; }
        SiteConfig Site { get; set; }
        ISerializer ConfigSerializer { get; set; }
        HttpContextBase HttpContext { get; set; }
    }
}
