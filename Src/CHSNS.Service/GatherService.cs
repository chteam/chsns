using CHSNS.Model;
using CHSNS.Operator;

namespace CHSNS.Service {
	/// <summary>
	/// 统计的类
	/// </summary>
	public class GatherService{
        static readonly GatherService Instance = new GatherService();
        private readonly IGatherOperator _gather;
        public GatherService() {
            _gather = new GatherOperator();
        }

        public static GatherService GetInstance() {
            return Instance;
        }
		/// <summary>
		/// 我的统计
		/// </summary>
		/// <returns></returns>
        public EventPagePas EventGather(long uId) {
		    return _gather.EventGather(uId);
		}
	}
}

