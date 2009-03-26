using CHSNS.Model;
using CHSNS.Models;

namespace CHSNS.Service
{
    public interface IMessageService
    {
        void Add(Message m);
        void Delete(long id, MessageBoxType t, long userid);
        MessageDetailsPas Details(long id, long userid);
        PagedList<MessageItemPas> GetInbox(long userid, int p, int ep);
        PagedList<MessageItemPas> GetOutbox(long userid, int p, int ep);
        //  long InboxCount(long userid);
        // long OutboxCount(long userid);
    }
}
