
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.Models;


namespace CHSNS.Controllers {
    using System.ComponentModel.Composition;
    using CHSNS.Service;

    public partial class CommentController : BaseController
    {
        [Import]
        public UserService UserInfo { get; set; }
        [Import]
        public CommentService Comment { get; set; }
        #region reply
        /// <summary>
        ///回复列表
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns></returns>
        public virtual ActionResult Reply(long? userid)
        {
            if (!userid.HasValue) userid = WebUser.UserId;
            var user = UserInfo.GetUser(
                userid.Value,
                c => new Profile{
                                             UserId = c.UserId,
                                             Name = c.Name,
                                             //Count = c.NoteCount
                                         });
            ViewData["NowPage"] = 1;
            ViewData["PageCount"] = 0;// user.Count;
            ViewData["replylist"] = Comment.GetReply(user.UserId, 1, 10);
            Title = user.Name + "的留言本";
            return View(user);
        }
        public virtual ActionResult ReplyList(long userid, int p)
        {
            var u = Comment.GetReply(userid, p, 10);
            return View("Comment/Item", u);
        }
        /// <summary>
        /// 回复用户
        /// </summary>
        /// <param name="replyerId">The replyer ID.</param>
        /// <param name="body"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Authorize]
        public virtual ActionResult AddReply(long replyerId, string body, long userId)
        {
            using (var ts = new TransactionScope()) {
                var r = new Reply { Body = body, UserId = userId };

                //UpdateModel(r, new[] { "Body", "UserId" });
                var ownerId = r.UserId;
                r.SenderId = WebUser.UserId;
                r.AddTime = DateTime.Now;
                r = Comment.AddReply(r);
                if (replyerId != ownerId) {
                    r.UserId = replyerId;
                    Comment.AddReply(r);
                }
                r.UserId = ownerId;
                var model = new List<CommentPas>{
                    new CommentPas{
                    Sender = new NameIdPas{
                        Id = WebUser.UserId,
                        Name = WebUser.Name
                    },
                    Comment =new CommentItemPas{ 
                         ID = r.Id,
                         OwnerID=r.UserId,
                               Body = r.Body,
                               AddTime = r.AddTime,
                               IsDel = r.IsDel	}
                }
            };
                ts.Complete();
                return View("Comment/Item", model);
            }
        }
        /// <summary>
        /// Deletes the reply.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public virtual ActionResult DeleteReply(long id)
        {

            Comment.DeleteReply(id, WebUser.UserId);

            return new EmptyResult();

        }
        #endregion

        #region comment
        public virtual ActionResult List(long id, int p, CommentType type)
        {
            var cl = Comment.CommentList(id, CommentType.Note, p, WebContext.Site);
            
            return View("Comment/Item", cl);
        }

        [Authorize]
        public virtual ActionResult Delete(long id)
        {
            // TODO:少删除的权限判断

            Comment.Delete(id, CommentType.Note);

            return this.Empty();
        }
        [Authorize]
        public virtual ActionResult Add(long showerId, long ownerId, string body, CommentType type)
        {
            var cmt = new Comment {
                ShowerId = showerId,
                OwnerId = ownerId,
                SenderId = WebUser.UserId,
                Body = body,
                Type = (byte)type,
                AddTime = DateTime.Now,
                IsTellMe = 0
            };
            var model = new List<CommentPas>{
                    new CommentPas{
                    Sender = new NameIdPas{
                        Id = WebUser.UserId,
                        Name = WebUser.Name
                    },
                    Comment =new CommentItemPas{ 
                         ID = cmt.Id,
                         OwnerID=cmt.OwnerId,
                               Body = cmt.Body,
                               AddTime =cmt.AddTime,
                               IsDel =cmt.IsDel
                    }
                }
            };
            Comment.Add(cmt, type);
            return View("Comment/Item", model);
        }
        #endregion
    }
}
