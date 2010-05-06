using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MvcHelper
{
    /// <summary>
    /// Class that represents a FlexiGrid Row.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
          Justification =
              "FlexiGrid pass data in lower case JSON format; so in order for the deserialization to work properly we need to give a lower case property name.")]
    public class FlexGridRowData
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FlexGridRowData"/> class.
        /// </summary>
        /// <param name="id">Name of the identity field.</param>
        /// <param name="data">Clls in this row.</param>
        public FlexGridRowData(string id, IList<string> data)
        {
            this.id = id;
            this.cell = data;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the identity field of this row.
        /// </summary>
        /// <value>Name of the identity field.</value>
        public string id { get; set; }

        /// <summary>
        /// Gets or sets the cells of this row.
        /// </summary>
        /// <value>List of cells in this row.</value>
        public IList<string> cell { get; set; }

        #endregion
    }
}
