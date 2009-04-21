using CHSNS.Config;
using CHSNS.Model;
using CHSNS.Models.Abstractions;
using CHSNS.Operator;

namespace CHSNS.Service
{
    /// <summary>
    /// Site Message Service,
    /// Jian Zou 2009 03 27,2009 4 16
    /// </summary>
    public class MessageService
    {
                static readonly MessageService _instance = new MessageService();
                private readonly IMessageOperator Message;
        public MessageService() {
                    Message = new MessageOperator();
        }

        public static MessageService GetInstance(){
            return _instance;
        }

        //  public MessageService(IDBManager id) : base(id) { }
        public PagedList<MessageItemPas> GetInbox(long uid, int p, SiteConfig site){
            return Message.GetInbox(uid, p, site.EveryPage.MessageBox);
        }

        public PagedList<MessageItemPas> GetOutbox(long uid, int p, SiteConfig site)
        {

            return Message.GetOutbox(uid, p, site.EveryPage.MessageBox);
            
        }
        public void Add(IMessage m,IContext context)
        {
            Message.Add(m, context.HttpContext.Server);
        }

        public void Delete(long id, MessageBoxType t, long uid)
        {
            Message.Delete(id, t, uid);
        }

        public MessageDetailsPas Details(long id, long uId)
        {
            return Message.Details(id, uId);
        }
    }
}

