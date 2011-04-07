using System.Web;
namespace CHSNS
{
    public static class CH
    {
        public static IContext Context
        {
            get
            {
                return new WebContext(new HttpContextWrapper(HttpContext.Current));
            }
        }
    }
}
