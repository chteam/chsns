

using System.Collections.Generic;
using System.Linq;

using CHSNS.Operator;
using CHSNS.Models;

namespace CHSNS.SQLServerImplement.Operator
{
    public class ApplicationOperator : BaseOperator, IApplicationOperator
    {
        /// <summary>
        /// 应用列表
        /// </summary>
        public List<Application> Applications {
            get {
                using (var db = DBExtInstance) {
                    return db.Application.Cast<Application>().ToList();
                }
            }
        }

        public List<Application> GetApps(long[] ids)
        {
            return ids.Length == 0 ? Applications.Where(c => c.IsSystem).ToList() : Applications.Where(c => ids.Contains(c.Id)).ToList();
        }
    }
}