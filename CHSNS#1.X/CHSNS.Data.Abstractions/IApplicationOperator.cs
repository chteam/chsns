using System.Collections.Generic;
using System.Net.Mime;
using CHSNS.Models;

namespace CHSNS.Operator
{
    public interface IApplicationOperator
    {
        List<IApplication> Applications { get; }
        List<IApplication> GetApps(long[] ids);
    }
}
