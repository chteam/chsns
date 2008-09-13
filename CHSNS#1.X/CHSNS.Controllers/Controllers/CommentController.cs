
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using CHSNS.Extension;
using CHSNS.Filter;
using Chsword;
using CHSNS.Models;
using System;
namespace CHSNS.Controllers {
	[LoginedFilter]
	public class CommentController : BaseController {
		public ActionResult AddReply(long ReplyerID) {
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
			return View("Comment/Item", model);
		}
		[AcceptVerbs("Post")]
		public ActionResult DeleteReply(long id) {
			DBExt.Comment.DeleteReply(id, CHUser.UserID);
			return new EmptyResult();
		}

	}
}
