using CHSNS.Config;
using System.Web;

namespace CHSNS
{
    public static class HtmlHelperContext
    {
        public static SiteConfig CHSite(this HttpApplicationStateBase application)
        {
            return new SiteConfig(new ConfigSerializer(new CHContext()));
            // TODO:
        }
    }
}
