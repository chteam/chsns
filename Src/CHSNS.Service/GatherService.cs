using CHSNS.Model;
using CHSNS.Operator;

namespace CHSNS.Service {
	/// <summary>
	/// 统计的类
	/// </summary>
	public class GatherService{
        static readonly GatherService _instance = new GatherService();
        private readonly IGatherOperator Gather;
        public GatherService() {
            Gather = new GatherOperator();
        }

        public static GatherService GetInstance() {
            return _instance;
        }
		/// <summary>
		/// 我的统计
		/// </summary>
		/// <returns></returns>
        public EventPagePas EventGather(long uId) {
		    return Gather.EventGather(uId);
		}
	}
}

