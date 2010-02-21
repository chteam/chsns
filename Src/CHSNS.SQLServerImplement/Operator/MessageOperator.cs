using System;
using CHSNS.Model;
using System.Linq;

using CHSNS.SQLServerImplement;
using System.Web;
using CHSNS.Models;

namespace CHSNS.Operator
{
    /// <summary>
    /// Site Message Operator,
    /// Jian Zou 2009 03 27
    /// </summary>
    public class MessageOperator : BaseOperator, IMessageOperator
    {
        public PagedList<MessageItemPas> GetInbox(long uId, int page,int pageSize)
        {
            using (var db = DBExtInstance)
            {
                var ret = (from m in db.Message
                           join p1 in db.Profile on m.FromId equals p1.UserId
                           where m.ToId == uId && !m.IsToDel
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
                return ret.Pager(page, pageSize);
            }
        }

        public PagedList<MessageItemPas> GetOutbox(long uid, int page,int pageSize)
        {
            using (var db = DBExtInstance)
            {
                var ret = (from m in db.Message
                           join p1 in db.Profile on m.ToId equals p1.UserId
                           where m.FromId == uid && !m.IsFromDel
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
                return ret.Pager(page, pageSize);
            }
        }
        public void Add(Message m, HttpServerUtilityBase server)
        {
            using (var db = DBExtInstance)
            {

                m.Title = server.HtmlEncode(m.Title ?? "");
                m.Body = m.IsHtml ? m.Body : server.HtmlEncode(m.Body);
                m.SendTime = DateTime.Now;
                db.Message.AddObject(m) ;
                db.SubmitChanges();
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
                db.SubmitChanges();
            }

            #region sql

            //            if (t == MessageBoxType.Inbox)
            //            {
            //                DataBaseExecutor.Execute("update [message] set istodel=1 where id=@id", "@id", id);
            //                DataBaseExecutor.Execute("update [profile] set inboxcount=inboxcount-1 where userid=@id and inboxcount>0", "@id", uid);
            //            }
            //            else
            //            {//发件箱
            //                DataBaseExecutor.Execute("update [message] set isfromdel=1 where id=@id", "@id", id);
            //                int tr = DataBaseExecutor.Execute(@"update [profile] 
            //				set unreadMessageCount=unreadMessageCount-1,outboxcount=outboxcount-1
            //where userid=@uid and unreadMessageCount>0 and outboxcount>0 and 
            //exists(select 1 from [message] where id=@id and issee=0)", "@uid", uid, "@id", id);
            //                if (tr != 1)//上条未更新，证明是已经读的
            //                    DataBaseExecutor.Execute("update [profile] set outboxcount=outboxcount-1 where userid=@id and outboxcount>0", "@id", uid);
            //            }

            #endregion

            // TODO:应该将所有已经双方删除的 彻底更新
        }

        public MessageDetailsPas Details(long id, long uid)
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

                if (ret1.pin.UserId == uid && !ret1.m.IsSee)
                {
                    ret1.m.IsSee = true;
                    db.SubmitChanges();
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

