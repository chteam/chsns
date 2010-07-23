using CHSNS.Model;
using CHSNS.Operator;

namespace CHSNS.Service
{
    /// <summary>
    /// 统计的类
    /// </summary>
    public class GatherService : BaseService<GatherService>
    {

        private readonly GatherOperator _gather;
        public GatherService()
        {
            _gather = new GatherOperator();
        }

        /// <summary>
        /// 我的统计
        /// </summary>
        /// <returns></returns>
        public EventPagePas EventGather(long uId)
        {
            return _gather.EventGather(uId);
        }
    }
}

