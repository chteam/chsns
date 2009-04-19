

using System.Collections.Generic;
using System.Linq;
using System.Web;
using CHSNS.Models;

namespace CHSNS.Service
{
	public class ApplicationService : BaseService, IApplicationService
	{
		private const string APPLISTALL = "APPLISTALL";

		public ApplicationService(IDBManager id) : base(id)
		{
		}

		/// <summary>
		/// 缓存的应用列表
		/// </summary>
		public List<Application> Applications
		{
			get
			{
				if (HttpContext.Application[APPLISTALL] == null)
				{
					HttpContext.Application.Lock();
                    using (var db = DBExt.Instance)
                    {
                        HttpContext.Application[APPLISTALL] = db.Application.ToList();
                    }
					HttpContext.Application.UnLock();
				}
				return HttpContext.Application[APPLISTALL] as List<Application>;
			}
		}

		public List<Application> GetApps(long[] ids)
		{
		    return ids.Length == 0 ? Applications.Where(c => c.IsSystem).ToList() : Applications.Where(c => ids.Contains(c.ID)).ToList();
		}
	}
}
