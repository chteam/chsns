using CHSNS.Model;
using CHSNS.Models;

namespace CHSNS.Operator
{
    public interface IMessageOperator
    {
        void Add(Message m);
        void Delete(long id, MessageBoxType t, long uid);
        MessageDetailsPas Details(long id, long uid);
        PagedList<MessageItemPas> GetInbox(long uid, int p);
        PagedList<MessageItemPas> GetOutbox(long uid, int p);
        //  long InboxCount(long userid);
        // long OutboxCount(long userid);
    }
}
