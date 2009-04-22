using System.Collections.Generic;
using System.Net.Mime;
using CHSNS.Models;
using CHSNS.Models.Abstractions;

namespace CHSNS.Operator
{
    public interface IApplicationOperator
    {
        List<IApplication> Applications { get; }
        List<IApplication> GetApps(long[] ids);
    }
}
