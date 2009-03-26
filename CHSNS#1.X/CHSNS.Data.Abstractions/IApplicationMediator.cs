using System.Collections.Generic;
using CHSNS.Models;

namespace CHSNS.Service
{
    public interface IApplicationService
    {
        IList<Application> Applications { get; }
        IList<Application> GetApps(long[] ids);
    }
}
