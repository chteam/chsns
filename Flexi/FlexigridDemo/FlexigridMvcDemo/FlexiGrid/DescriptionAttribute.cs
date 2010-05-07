using System;

namespace MvcHelper
{
    internal class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string text)
        {
            this.Text = text;
        }

        public string Text { get; set; }
    }
}
