

using System.Collections.Generic;

using CHSNS.Operator;
using CHSNS.SQLServerImplement.Operator;
using CHSNS.Models;

namespace CHSNS.Service {
    public class ApplicationService {

        static readonly ApplicationService Instance = new ApplicationService();
        private readonly IApplicationOperator Application;
        public ApplicationService() {
            Application = new ApplicationOperator();
        }

        public static ApplicationService GetInstance() {
            return Instance;
        }
       // private const string APPLISTALL = "APPLISTALL";
        /// <summary>
        /// 缓存的应用列表
        /// </summary>
        public List<Application> Applications {
            get {
                return Application.Applications;
            }
        }

        public List<Application> GetApps(long[] ids) {
            return Application.GetApps(ids);
        }
    }
}
