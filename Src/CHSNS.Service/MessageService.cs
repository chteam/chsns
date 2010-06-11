using CHSNS.Config;
using CHSNS.Model;

using CHSNS.Operator;
using CHSNS.Models;

namespace CHSNS.Service
{
    /// <summary>
    /// Site Message Service,
    /// Jian Zou 2009 03 27,2009 4 16
    /// </summary>
    public class MessageService
    {
                static readonly MessageService Instance = new MessageService();
                private readonly IMessageOperator _message;
        public MessageService() {
                    _message = new MessageOperator();
        }

        public static MessageService GetInstance(){
            return Instance;
        }

        //  public MessageService(IDBManager id) : base(id) { }
        public PagedList<MessageItemPas> GetInbox(long uid, int p, SiteConfig site){
            return _message.GetInbox(uid, p, site.EveryPage.MessageBox);
        }

        public PagedList<MessageItemPas> GetOutbox(long uid, int p, SiteConfig site)
        {

            return _message.GetOutbox(uid, p, site.EveryPage.MessageBox);
            
        }
        public void Add(Message m,IContext context)
        {
            _message.Add(m, context.HttpContext.Server);
        }

        public void Delete(long id, MessageBoxType t, long uid)
        {
            _message.Delete(id, t, uid);
        }

        public MessageDetailsPas Details(long id, long uId)
        {
            return _message.Details(id, uId);
        }
    }
}

