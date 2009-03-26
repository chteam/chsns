using System.Collections.Generic;
using CHSNS.Models;

namespace CHSNS.Data
{
    public interface IApplicationService
    {
        IList<Application> Applications { get; }
        IList<Application> GetApps(long[] ids);
    }
}
