using System;
using CHSNS.Model;
using System.Linq;
using CHSNS.Models;
namespace CHSNS.Operator
{
    /// <summary>
    /// Site Message Operator,
    /// Jian Zou 2009 03 27
    /// </summary>
    public class MessageOperator : BaseOperator, IMessageOperator
    {
        public MessageOperator(IDBManager id) : base(id) { }
        public PagedList<MessageItemPas> GetInbox(long uid, int p)
        {
            using (var db = DBExt.Instance)
            {
                var ret = (from m in db.Message
                           join p1 in db.Profile on m.FromID equals p1.UserID
                           where m.ToID == uid && !m.IsToDel
                           orderby m.IsSee, m.ID descending
                           select new MessageItemPas
                           {
                               ID = m.ID,
                               Username = p1.Name,
                               UserID = p1.UserID,
                               Title = m.Title,
                               SendTime = m.SendTime,
                               IsSee = m.IsSee
                           });
                return ret.Pager(p, Site.EveryPage.MessageBox);
            }
        }

        public PagedList<MessageItemPas> GetOutbox(long uid, int p)
        {
            using (var db = DBExt.Instance)
            {
                var ret = (from m in db.Message
                           join p1 in db.Profile on m.ToID equals p1.UserID
                           where m.FromID == uid && !m.IsFromDel
                           orderby m.ID descending
                           select new MessageItemPas
                           {
                               ID = m.ID,
                               Username = p1.Name,
                               UserID = p1.UserID,
                               Title = m.Title,
                               SendTime = m.SendTime,
                               IsSee = m.IsSee
                           }
                          );
                return ret.Pager(p, Site.EveryPage.MessageBox);
            }
        }
        public void Add(Message m)
        {
            using (var db = DBExt.Instance)
            {
                m.Title = HttpContext.Server.HtmlEncode(m.Title ?? "");
                m.Body = m.IsHtml ? m.Body : HttpContext.Server.HtmlEncode(m.Body);
                m.SendTime = DateTime.Now;
                db.Message.InsertOnSubmit(m);
                db.SubmitChanges();
            }
        }

        public void Delete(long id, MessageBoxType t, long uid)
        {
            using (var db = DBExt.Instance)
            {
                var message = db.Message.FirstOrDefault(m => m.ID == id);
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
            using (var db = DBExt.Instance)
            {
                var ret1 = (from m in db.Message
                            where m.ID == id
                            join pout in db.Profile on m.FromID equals pout.UserID
                            join pin in db.Profile on m.ToID equals pin.UserID
                            select new { m, pout, pin }
                       ).FirstOrDefault();

                if (ret1.pin.UserID == uid && !ret1.m.IsSee)
                {
                    ret1.m.IsSee = true;
                    db.SubmitChanges();
                }
                ret = new MessageDetailsPas
                          {
                              UserInbox = new UserItemPas { ID = ret1.pin.UserID, Name = ret1.pin.Name },
                              UserOutbox = new UserItemPas { ID = ret1.pout.UserID, Name = ret1.pout.Name },
                              Message =
                                  new MessageItemPas
                                      {
                                          Body = ret1.m.Body,
                                          ID = ret1.m.ID,
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

