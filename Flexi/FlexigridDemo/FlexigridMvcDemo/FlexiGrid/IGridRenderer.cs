using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHelper
{
    public interface IGridRenderer<T> where T : class
    {
        string Render(T data);
    }

}