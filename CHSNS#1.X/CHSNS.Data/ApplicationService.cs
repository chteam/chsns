

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
		public IList<Application> Applications
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
				return HttpContext.Application[APPLISTALL] as IList<Application>;
			}
		}

		public IList<Application> GetApps(long[] ids)
		{
			if (ids.Length == 0)
				return Applications.Where(c => c.IsSystem).ToList();
			return Applications.Where(c => ids.Contains(c.ID)).ToList();
		}
	}
}
