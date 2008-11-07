using System.Data;
using System.Linq;
using CHSNS.ModelPas;
using CHSNS.Models;

namespace CHSNS.Data
{
	public interface ICommentMediator
	{
		void Add(Comment cmt, CommentType type);
		Reply AddReply(Reply r);
		IQueryable<CommentPas> CommentList(long ShowerID, CommentType type);
		bool Delete(long id, CommentType type);
		void DeleteReply(long id, long userid);
		IQueryable<CommentPas> GetReply(long userid);
		DataRowCollection NewFiveReply();
	}
}
