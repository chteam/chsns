using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHelper
{
    public interface IGridRenderer<T> where T : class
    {
        /// <summary>
        /// Renders the specified data.
        /// </summary>
        /// <param name="data">The data that needs to be rendered..</param>
        /// <returns>Rendered output as string.</returns>
        string Render(T data);
    }

}