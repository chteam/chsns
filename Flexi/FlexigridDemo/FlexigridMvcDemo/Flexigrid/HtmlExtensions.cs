using System.Web.Mvc;

namespace MvcHelper
{
    public static class HtmlExtensions
    {
        public static FlexigridTableSettings<T> Flexigrid<T>(this HtmlHelper helper) where T : class
        {
            return new FlexigridTableSettings<T>();
        }

        public static FlexigridSettings Flexigrid(this HtmlHelper helper)
        {
            return new FlexigridSettings();
        }
    }
}
