
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Mvc;
using CHSNS.Filter;
using CHSNS.Models;
using CHSNS.Tools;
namespace CHSNS.Controllers {
	[LoginedFilter]
	public class CommentController : BaseController {
		/// <summary>
		///回复列表
		/// </summary>
		/// <param name="userid">The userid.</param>
		/// <returns></returns>
		public ActionResult ReplyList(long? userid) {
			if (!userid.HasValue) userid = CHUser.UserID;
			var user = DBExt.UserInfo.GetUser(
					userid.Value,
					c => new UserCountPas {
						ID = c.UserID,
						Name = c.Name,
						Count = c.NoteCount
					});
			DBExt.Comment.GetReply(userid.Value).Pager(1, 10);
			return View();
		}

		/// <summary>
		/// 回复用户
		/// </summary>
		/// <param name="ReplyerID">The replyer ID.</param>
		/// <returns></returns>
		public ActionResult AddReply(long ReplyerID) {
			using (var ts = new TransactionScope()) {
				var r = new Reply();
				UpdateModel(r, new[] { "Body", "UserID" });
				var OwnerID = r.UserID;
				r.SenderID = CHUser.UserID;
				r.AddTime = DateTime.Now;
				r = DBExt.Comment.AddReply(r);
				if (ReplyerID != OwnerID) {
					r.UserID = ReplyerID;
					DBExt.Comment.AddReply(r);
				}
				r.UserID = OwnerID;
				var model = new List<ReplyPas>{
				new ReplyPas{
					Sender = new NameIDPas{
						ID = CHUser.UserID,
						Name = CHUser.Username
					},
					Reply = r
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
		public ActionResult DeleteReply(long id) {
			using (var ts = new TransactionScope()) {
				DBExt.Comment.DeleteReply(id, CHUser.UserID);
				ts.Complete();
				return new EmptyResult();
			}
		}

	}
}
