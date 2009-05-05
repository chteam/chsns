
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Mvc;
using CHSNS.Model;
using CHSNS.Abstractions;

namespace CHSNS.Controllers {

    public class CommentController : BaseController {
        #region reply
        /// <summary>
        ///�ظ��б�
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns></returns>
        public ActionResult Reply(long? userid) {
            if (!userid.HasValue) userid = CHUser.UserID;
            var user = DbExt.UserInfo.GetUser(
                userid.Value,
                c => new ProfileImplement{
                                             UserId = c.UserId,
                                             Name = c.Name,
                                             //Count = c.NoteCount
                                         });
            ViewData["NowPage"] = 1;
            ViewData["PageCount"] = 0;// user.Count;
            ViewData["replylist"] = DbExt.Comment.GetReply(user.UserId, 1, 10);
            Title = user.Name + "�����Ա�";
            return View(user);
        }
        public ActionResult ReplyList(long userid, int p) {
            var u = DbExt.Comment.GetReply(userid, p, 10);
            return View("Comment/Item", u);
        }
        /// <summary>
        /// �ظ��û�
        /// </summary>
        /// <param name="ReplyerID">The replyer ID.</param>
        /// <param name="Body"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [LoginedFilter]
        public ActionResult AddReply(long ReplyerID, string Body, long UserID) {
            using (var ts = new TransactionScope()) {
                IReply r = new ReplyImplement { Body = Body, UserID = UserID };

                //UpdateModel(r, new[] { "Body", "UserId" });
                var OwnerID = r.UserID;
                r.SenderID = CHUser.UserID;
                r.AddTime = DateTime.Now;
                r = DbExt.Comment.AddReply(r);
                if (ReplyerID != OwnerID) {
                    r.UserID = ReplyerID;
                    DbExt.Comment.AddReply(r);
                }
                r.UserID = OwnerID;
                var model = new List<CommentPas>{
					new CommentPas{
					Sender = new NameIdPas{
						Id = CHUser.UserID,
						Name = CHUser.Username
					},
					Comment =new CommentItemPas{ 
						 ID = r.ID,
						 OwnerID=r.UserID,
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
        [AcceptVerbs("Post")]
        [LoginedFilter]
        public ActionResult DeleteReply(long id) {

            DbExt.Comment.DeleteReply(id, CHUser.UserID);

            return new EmptyResult();

        }
        #endregion

        #region comment
        public ActionResult List(long id, int p, CommentType type){
            var cl = DbExt.Comment.CommentList(id, CommentType.Note, p, CHContext.Site);
            return View("Comment/Item", cl);
        }

        [LoginedFilter]
        public ActionResult Delete(long id) {
            // TODO:��ɾ����Ȩ���ж�

            DbExt.Comment.Delete(id, CommentType.Note);

            return this.Empty();
        }
        [LoginedFilter]
        public ActionResult Add(long ShowerID, long OwnerID, string Body, CommentType type) {
            var cmt = new CommentImplement {
                ShowerID = ShowerID,
                OwnerID = OwnerID,
                SenderID = CHUser.UserID,
                Body = Body,
                Type = (byte)type,
                AddTime = DateTime.Now,
                IsTellMe = 0
            };
            var model = new List<CommentPas>{
					new CommentPas{
					Sender = new NameIdPas{
						Id = CHUser.UserID,
						Name = CHUser.Username
					},
					Comment =new CommentItemPas{ 
						 ID = cmt.ID,
						 OwnerID=cmt.OwnerID,
							   Body = cmt.Body,
							   AddTime =cmt.AddTime,
							   IsDel =cmt.IsDel
					}
				}
			};
            DbExt.Comment.Add(cmt, type);
            return View("Comment/Item", model);
        }
        #endregion
    }
}
