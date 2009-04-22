

using System.Collections.Generic;
using System.Linq;
using CHSNS.Abstractions;

namespace CHSNS.Operator
{
	public class ApplicationOperator : BaseOperator, IApplicationOperator
	{
	    /// <summary>
		/// 应用列表
		/// </summary>
        public List<IApplication> Applications {
            get {
                using (var db = DBExtInstance) {
                    return db.Application.Cast<IApplication>().ToList();
                }
            }
        }

		public List<IApplication> GetApps(long[] ids)
		{
		    return ids.Length == 0 ? Applications.Where(c => c.IsSystem).ToList() : Applications.Where(c => ids.Contains(c.ID)).ToList();
		}
	}
}
