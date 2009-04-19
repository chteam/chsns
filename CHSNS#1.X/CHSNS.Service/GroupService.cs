using CHSNS.Operator;

namespace CHSNS.Service {
	public class GroupService {//}:BaseService, IGroupService {
		//public GroupService(IDBManager id) : base(id) { }
	        static readonly GroupService _instance = new GroupService();
            private readonly IGroupOperator Group;
        public GroupService() {
                Group = new GroupOperator();
        }

        public static GroupService GetInstance() {
            return _instance;
        }
	}
}
