using System;

namespace MvcHelper
{
    /// <summary>
    /// Description attribute.
    /// </summary>
    internal class DescriptionAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptionAttribute"/> class.
        /// </summary>
        /// <param name="text">Textual description.</param>
        public DescriptionAttribute(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>Textual description.</value>
        public string Text { get; set; }
    }
}
