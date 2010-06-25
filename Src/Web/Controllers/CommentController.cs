
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.Models;


namespace CHSNS.Controllers {

    public partial class CommentController : BaseController
    {
        #region reply
        /// <summary>
        ///回复列表
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns></returns>
        public virtual ActionResult Reply(long? userid)
        {
            if (!userid.HasValue) userid = CHUser.UserId;
            var user = DataExt.UserInfo.GetUser(
                userid.Value,
                c => new Profile{
                                             UserId = c.UserId,
                                             Name = c.Name,
                                             //Count = c.NoteCount
                                         });
            ViewData["NowPage"] = 1;
            ViewData["PageCount"] = 0;// user.Count;
            ViewData["replylist"] = DataExt.Comment.GetReply(user.UserId, 1, 10);
            Title = user.Name + "的留言本";
            return View(user);
        }
        public virtual ActionResult ReplyList(long userid, int p)
        {
            var u = DataExt.Comment.GetReply(userid, p, 10);
            return View("Comment/Item", u);
        }
        /// <summary>
        /// 回复用户
        /// </summary>
        /// <param name="ReplyerID">The replyer ID.</param>
        /// <param name="Body"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [LoginedFilter]
        public virtual ActionResult AddReply(long ReplyerID, string Body, long UserID)
        {
            using (var ts = new TransactionScope()) {
                Reply r = new Reply { Body = Body, UserId = UserID };

                //UpdateModel(r, new[] { "Body", "UserId" });
                var ownerId = r.UserId;
                r.SenderId = CHUser.UserId;
                r.AddTime = DateTime.Now;
                r = DataExt.Comment.AddReply(r);
                if (ReplyerID != ownerId) {
                    r.UserId = ReplyerID;
                    DataExt.Comment.AddReply(r);
                }
                r.UserId = ownerId;
                var model = new List<CommentPas>{
					new CommentPas{
					Sender = new NameIdPas{
						Id = CHUser.UserId,
						Name = CHUser.NickName
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
        [LoginedFilter]
        public virtual ActionResult DeleteReply(long id)
        {

            DataExt.Comment.DeleteReply(id, CHUser.UserId);

            return new EmptyResult();

        }
        #endregion

        #region comment
        public virtual ActionResult List(long id, int p, CommentType type)
        {
            var cl = DataExt.Comment.CommentList(id, CommentType.Note, p, CHContext.Site);
            
            return View("Comment/Item", cl);
        }

        [LoginedFilter]
        public virtual ActionResult Delete(long id)
        {
            // TODO:少删除的权限判断

            DataExt.Comment.Delete(id, CommentType.Note);

            return this.Empty();
        }
        [LoginedFilter]
        public virtual ActionResult Add(long ShowerID, long OwnerID, string Body, CommentType type)
        {
            var cmt = new Comment {
                ShowerId = ShowerID,
                OwnerId = OwnerID,
                SenderId = CHUser.UserId,
                Body = Body,
                Type = (byte)type,
                AddTime = DateTime.Now,
                IsTellMe = 0
            };
            var model = new List<CommentPas>{
					new CommentPas{
					Sender = new NameIdPas{
						Id = CHUser.UserId,
						Name = CHUser.NickName
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
            DataExt.Comment.Add(cmt, type);
            return View("Comment/Item", model);
        }
        #endregion
    }
}
