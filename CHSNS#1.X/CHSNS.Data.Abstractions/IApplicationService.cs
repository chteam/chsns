using System.Collections.Generic;
using CHSNS.Models;

namespace CHSNS.Service
{
    public interface IApplicationService
    {
        List<Application> Applications { get; }
        List<Application> GetApps(long[] ids);
    }
}
