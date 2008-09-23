
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Mvc;
using CHSNS.Filter;
using CHSNS.Models;
namespace CHSNS.Controllers {
	[LoginedFilter]
	public class CommentController : BaseController {

		/// <summary>
		/// �ظ��û�
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
