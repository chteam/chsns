namespace CHSNS.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using CHSNS.Models;
    using System.ComponentModel.Composition;
    [Export]
    public class ApplicationService : BaseService<ApplicationService>
    {
        // private const string APPLISTALL = "APPLISTALL";
        /// <summary>
        /// 缓存的应用列表
        /// </summary>
        public List<Application> Applications
        {
            get
            {
                using (var db = DbInstance)
                {
                    return db.Application.Cast<Application>().ToList();
                }
            }
        }

        public List<Application> GetApps(params long[] ids)
        {
            return ids.Length == 0 ? Applications.Where(c => c.IsSystem).ToList() : Applications.Where(c => ids.Contains(c.Id)).ToList();

        }
    }
}
