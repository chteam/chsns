using System.Diagnostics.CodeAnalysis;

namespace MvcHelper
{
    /// <summary>
    /// Class that wraps the options that are passed by the FlexGrid in order to populate data.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
           Justification =
               "FlexiGrid pass data in lower case JSON format; so in order for the deserialization to work properly we need to give a lower case property name.")]
    public class FlexGridFetchOptions
    {
        /// <summary>
        /// Gets or sets current page index.
        /// </summary>
        /// <value>Index of the page.</value>
        public int page { get; set; }

        /// <summary>
        /// Gets or sets the Query type.
        /// <remarks>Normally this will be Name of the field.</remarks>
        /// </summary>
        /// <value>Type of Query.</value>
        public string qtype { get; set; }

        /// <summary>
        /// Gets or sets the query.
        /// <remarks>This is the actual text entered in the search box.</remarks>
        /// </summary>
        /// <value>Queried text.</value>
        public string query { get; set; }

        /// <summary>
        /// Gets or sets the no:of records per page.
        /// </summary>
        /// <value>Records per page.</value>
        public int rp { get; set; }

        /// <summary>
        /// Gets or sets the sorting field name.
        /// </summary>
        /// <value>Name of the field in which sorting is applied.</value>
        public string sortname { get; set; }

        /// <summary>
        /// Gets or sets the order of sorting.
        /// </summary>
        /// <value>Current sort order.</value>
        public string sortorder { get; set; }
    }
}