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
		public NoteDetailsPas Details(long id) {
			var ret = (from n in DBExt.DB.Note
					   join p in DBExt.DB.Profile on n.UserID equals p.UserID
					   where n.ID == id
					   select new NoteDetailsPas {
						   Note = n,
						   User = new UserItemPas {
							   ID = p.UserID,
							   Name = p.Name
						   }
					   }
					  ).FirstOrDefault();
			return ret;
		}
		/// <summary>
		/// userid
		/// </summary>
		public void Add(Note note, long userid) {
			note.LastCommentTime = note.EditTime = note.AddTime = DateTime.Now;
			note.UserID = userid;
			DBExt.DB.AddToNote(note);
			DBExt.DB.SaveChanges();
		}
		public void Edit(Note note,long userid){
			DataBaseExecutor.Execute("");
		}
	}
}
