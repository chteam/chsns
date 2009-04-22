using CHSNS.Model;
using CHSNS.Models.Abstractions;

namespace CHSNS.Operator
{
    public interface IMessageOperator
    {
        void Add(IMessage m, System.Web.HttpServerUtilityBase server);
        void Delete(long id, MessageBoxType t, long uid);
        MessageDetailsPas Details(long id, long uid);
        PagedList<MessageItemPas> GetInbox(long uid, int page,int pageSize);
        PagedList<MessageItemPas> GetOutbox(long uid, int page,int pageSize);
        //  long InboxCount(long userid);
        // long OutboxCount(long userid);
    }
}
