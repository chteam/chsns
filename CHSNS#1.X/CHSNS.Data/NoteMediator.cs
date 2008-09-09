using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHSNS.Models;

namespace CHSNS.Data {
	public class NoteMediator : BaseMediator {
		public NoteMediator(DBExt id) : base(id) { }
		public IQueryable<Note> GetNotes(long userid) {
			return (from n in DBExt.DB.Note
			        where n.UserID == userid
			        orderby n.ID descending
			        select n);
		}
	}
}
