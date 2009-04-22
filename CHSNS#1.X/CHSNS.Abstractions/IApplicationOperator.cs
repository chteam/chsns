using System.Collections.Generic;
using CHSNS.Abstractions;

namespace CHSNS.Operator
{
    public interface IApplicationOperator
    {
        List<IApplication> Applications { get; }
        List<IApplication> GetApps(long[] ids);
    }
}
