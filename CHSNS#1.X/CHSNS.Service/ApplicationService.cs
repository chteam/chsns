

using System.Collections.Generic;
using CHSNS.Models.Abstractions;
using CHSNS.Operator;

namespace CHSNS.Service {
    public class ApplicationService {

        static readonly ApplicationService _instance = new ApplicationService();
        private readonly IApplicationOperator Application;
        public ApplicationService() {
            Application = new ApplicationOperator();
        }

        public static ApplicationService GetInstance() {
            return _instance;
        }
       // private const string APPLISTALL = "APPLISTALL";
        /// <summary>
        /// 缓存的应用列表
        /// </summary>
        public List<IApplication> Applications {
            get {
                return Application.Applications;
            }
        }

        public List<IApplication> GetApps(long[] ids) {
            return Application.GetApps(ids);
        }
    }
}
