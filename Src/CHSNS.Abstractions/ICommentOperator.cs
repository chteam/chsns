﻿using System.Collections.Generic;
using CHSNS.Model;
using CHSNS.Models;
//

namespace CHSNS.Operator
{
	public interface ICommentOperator
	{
		void Add(Comment cmt, CommentType type);
		Reply AddReply(Reply r);
        PagedList<CommentPas> CommentList(long ShowerID, CommentType type, int p,int pageSize);
		bool Delete(long id, CommentType type);
		void DeleteReply(long id, long userid);
        //IList<CommentPas> GetReply(long userid);
        PagedList<CommentPas> GetReply(long uid, int p, int ep);
	}
}