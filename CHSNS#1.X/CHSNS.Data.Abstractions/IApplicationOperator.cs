using System.Collections.Generic;
using CHSNS.Models;

namespace CHSNS.Operator
{
    public interface IApplicationOperator
    {
        List<Application> Applications { get; }
        List<Application> GetApps(long[] ids);
    }
}
