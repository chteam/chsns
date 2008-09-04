﻿using System.Data;

namespace CHSNS.Data {
	public class ReplyMediator : BaseMediator {
		public ReplyMediator(DBExt id) : base(id) { }
		public DataRowCollection NewFiveReply() {
			return DataBaseExecutor.GetRows("Reply_New", "@userid", CHUser.UserID);
		}

	}
}
