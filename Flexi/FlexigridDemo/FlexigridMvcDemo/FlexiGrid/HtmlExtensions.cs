using System.Web.Mvc;

namespace MvcHelper
{
    /// <summary>
    /// Html Extensions that are used in the View.
    /// </summary>
    public static class HtmlExtensions
    {
        /// <summary>
        /// Helper extension which generates a FlexiGrid.
        /// </summary>
        /// <typeparam name="T">Type of the Model.</typeparam>
        /// <param name="helper">The helper.</param>
        /// <returns>Instance of FlexGridSettings.</returns>
        public static FlexiGridSettings<T> FlexiGrid<T>(this HtmlHelper helper) where T : class 
        {
            return new FlexiGridSettings<T>();
        }

        /// <summary>
        /// Helper extension which generates a FlexiGrid.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <returns>Instance of FlexGridSettings.</returns>
        public static FlexiGridSettings FlexiGrid(this HtmlHelper helper)
        {
            return new FlexiGridSettings();
        }
    }
}
