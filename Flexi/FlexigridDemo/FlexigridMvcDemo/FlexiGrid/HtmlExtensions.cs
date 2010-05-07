using System.Web.Mvc;

namespace MvcHelper
{
    public static class HtmlExtensions
    {
        public static FlexiGridSettings<T> FlexiGrid<T>(this HtmlHelper helper) where T : class
        {
            return new FlexiGridSettings<T>();
        }

        public static FlexiGridSettings FlexiGrid(this HtmlHelper helper)
        {
            return new FlexiGridSettings();
        }
    }
}
