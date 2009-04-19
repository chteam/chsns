﻿namespace CHSNS.Operator {
	public interface IEventOperator {
		void Add(Models.Event e);
		void Delete(long id, long ownerid);
        PagedList<Models.Event> GetEvent(long userid, int p, int ep);
        PagedList<Models.Event> GetUsersEvent(long[] ids, int page, int pageSize);
	}
}