
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Mvc;
using CHSNS.Models;
using System.Linq;
using CHSNS.Config;
using CHSNS.ModelPas;
namespace CHSNS.Controllers {

	public class CommentController : BaseController {
		#region reply
		/// <summary>
		///回复列表
		/// </summary>
		/// <param name="userid">The userid.</param>
		/// <returns></returns>
		public ActionResult Reply(long? userid) {
			if (!userid.HasValue) userid = CHUser.UserID;
			var user = DBExt.UserInfo.GetUser(
					userid.Value,
					c => new UserCountPas {
						ID = c.UserID,
						Name = c.Name,
						//Count = c.ReplyCount
					});
			ViewData["NowPage"] = 1;
			ViewData["PageCount"] = user.Count;
			ViewData["replylist"] = new PagedList<CommentPas>(
				DBExt.Comment.GetReply(user.ID), 1, 10);
			Title = user.Name + "的留言本";
			return View(user);
		}
		public ActionResult ReplyList(long userid, int p) {
			var u = DBExt.Comment.GetReply(userid).Pager(p, 10);
			return View("Comment/Item", u);
		}
		/// <summary>
		/// 回复用户
		/// </summary>
		/// <param name="ReplyerID">The replyer ID.</param>
		/// <param name="Body"></param>
		/// <returns></returns>
		[LoginedFilter]
		public ActionResult AddReply(long ReplyerID, string Body,long UserID) {
			using (var ts = new TransactionScope()) {
				var r = new Reply {Body = Body, UserID = UserID};
				
				//UpdateModel(r, new[] { "Body", "UserID" });
				var OwnerID = r.UserID;
				r.SenderID = CHUser.UserID;
				r.AddTime = DateTime.Now;
				r = DBExt.Comment.AddReply(r);
				if (ReplyerID != OwnerID) {
					r.UserID = ReplyerID;
					DBExt.Comment.AddReply(r);
				}
				r.UserID = OwnerID;
				var model = new List<CommentPas>{
					new CommentPas{
					Sender = new NameIDPas{
						ID = CHUser.UserID,
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
			using (var ts = DBExt.ExeTransaction()) {
				DBExt.Comment.DeleteReply(id, CHUser.UserID);
				ts.Commit();
				return new EmptyResult();
			}
		}
		#endregion

		#region comment
		public ActionResult List(long id, int p, CommentType type) {
			var cl = DBExt.Comment.CommentList(id, CommentType.Note).Pager(p,
				SiteConfig.Current.Note.CommentEveryPage
				).OrderBy(c => c.Comment.ID);
			return View("Comment/Item", cl);
		}
		[LoginedFilter]
		public ActionResult Delete(long id) {
			// TODO:少删除的权限判断
			using (var ts = DBExt.ExeTransaction()) {
				DBExt.Comment.Delete(id, CommentType.Note);
				ts.Commit();
				return this.Empty();
			}
		}
		[LoginedFilter]
		public ActionResult Add(long ShowerID,long OwnerID,string Body, CommentType type) {
			var cmt = new Comment {
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
					Sender = new NameIDPas{
						ID = CHUser.UserID,
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
			DBExt.Comment.Add(cmt, type);
			return View("Comment/Item", model);
		}
		#endregion
	}
}
