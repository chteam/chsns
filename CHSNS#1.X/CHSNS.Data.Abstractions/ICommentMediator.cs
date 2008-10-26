using System;
namespace CHSNS.Data {
	public interface ICommentMediator {
		void Add(CHSNS.Models.Comment cmt, CHSNS.CommentType type);
		CHSNS.Models.Reply AddReply(CHSNS.Models.Reply r);
		System.Linq.IQueryable<CHSNS.ModelPas.CommentPas> CommentList(long ShowerID, CHSNS.CommentType type);
		bool Delete(long id, CHSNS.CommentType type);
		void DeleteReply(long id, long userid);
		System.Linq.IQueryable<CHSNS.ModelPas.CommentPas> GetReply(long userid);
		System.Data.DataRowCollection NewFiveReply();
	}
}
