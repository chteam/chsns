using System.Collections.Generic;
using CHSNS.Models;

namespace CHSNS.Data
{
    public interface IApplicationMediator
    {
        IList<Application> Applications { get; }
        IList<Application> GetApps(long[] ids);
    }
}
