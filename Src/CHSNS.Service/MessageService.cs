
namespace CHSNS.Service
{
    using System;
    using System.Linq;
    using CHSNS.Config;
    using CHSNS.Model;
    using CHSNS.Models;    using System.ComponentModel.Composition;
    /// <summary>
    /// Site Message Service,
    /// Jian Zou 2009 03 27,2009 4 16
    /// </summary>

    [Export]
    public class MessageService : BaseService<MessageService>
    {
        public PagedList<MessageItemPas> GetInbox(long userId, int page, SiteConfig site)
        {
            using (var db = DBExtInstance)
            {
                var ret = (from m in db.Message
                           join p1 in db.Profile on m.FromId equals p1.UserId
                           where m.ToId == userId && !m.IsToDel
                           orderby m.IsSee, m.Id descending
                           select new MessageItemPas
                           {
                               ID = m.Id,
                               Username = p1.Name,
                               UserID = p1.UserId,
                               Title = m.Title,
                               SendTime = m.SendTime,
                               IsSee = m.IsSee
                           });
                return ret.Pager(page, site.EveryPage.MessageBox);
            }
        }

        public PagedList<MessageItemPas> GetOutbox(long userId, int page, SiteConfig site)
        {
            using (var db = DBExtInstance)
            {
                var ret = (from m in db.Message
                           join p1 in db.Profile on m.ToId equals p1.UserId
                           where m.FromId == userId && !m.IsFromDel
                           orderby m.Id descending
                           select new MessageItemPas
                           {
                               ID = m.Id,
                               Username = p1.Name,
                               UserID = p1.UserId,
                               Title = m.Title,
                               SendTime = m.SendTime,
                               IsSee = m.IsSee
                           }
                          );
                return ret.Pager(page, site.EveryPage.MessageBox);
            }
        }

        public void Add(Message m, IContext context)
        {
            var server = context.HttpContext.Server;
            using (var db = DBExtInstance)
            {

                m.Title = server.HtmlEncode(m.Title ?? "");
                m.Body = m.IsHtml ? m.Body : server.HtmlEncode(m.Body);
                m.SendTime = DateTime.Now;
                db.Message.Add(m);
                db.SaveChanges();
            }
        }

        public void Delete(long id, MessageBoxType t, long uid)
        {
            using (var db = DBExtInstance)
            {
                var message = db.Message.FirstOrDefault(m => m.Id == id);
                if (null == message) return;
                if (t == MessageBoxType.Inbox)
                    message.IsToDel = true;
                else
                    message.IsFromDel = true;
                db.SaveChanges();
            }
        }

        public MessageDetailsPas Details(long id, long userId)
        {
            MessageDetailsPas ret;
            using (var db = DBExtInstance)
            {
                var ret1 = (from m in db.Message
                            where m.Id == id
                            join pout in db.Profile on m.FromId equals pout.UserId
                            join pin in db.Profile on m.ToId equals pin.UserId
                            select new { m, pout, pin }
                       ).FirstOrDefault();

                if (ret1.pin.UserId == userId && !ret1.m.IsSee)
                {
                    ret1.m.IsSee = true;
                    db.SaveChanges();
                }
                ret = new MessageDetailsPas
                {
                    UserInbox = new UserItemPas { Id = ret1.pin.UserId, Name = ret1.pin.Name },
                    UserOutbox = new UserItemPas { Id = ret1.pout.UserId, Name = ret1.pout.Name },
                    Message =
                        new MessageItemPas
                        {
                            Body = ret1.m.Body,
                            ID = ret1.m.Id,
                            IsSee = ret1.m.IsSee,
                            SendTime = ret1.m.SendTime,
                            Title = ret1.m.Title,
                            IsHtml = ret1.m.IsHtml
                        }
                };
            }
            //        if (ret.UserInbox.ID == uid && !ret.Message.IsSee)
            //        {//我是收件人,则表示已经看过了,可以更新
            //            DataBaseExecutor.Execute(@"update [message] set IsSee=1 where id=@id", "@id", ret.Message.ID);
            //            DataBaseExecutor.Execute(@"update [profile] set unreadMessageCount=unreadMessageCount-1 where userid=@userid and unreadMessageCount>0",
            //"@userid", uid);
            //        }
            return ret;
        }
    }
}

