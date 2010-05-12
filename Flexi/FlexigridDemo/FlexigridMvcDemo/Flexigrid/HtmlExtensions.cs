using System.Web.Mvc;

namespace MvcHelper
{
    public static class HtmlExtensions
    {
        public static FlexigridTableSettings<T> FlexiGrid<T>(this HtmlHelper helper) where T : class
        {
            return new FlexigridTableSettings<T>();
        }

        public static FlexigridSettings FlexiGrid(this HtmlHelper helper)
        {
            return new FlexigridSettings();
        }
    }
}
