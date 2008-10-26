using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHSNS.Models;
using CHSNS.ModelPas;

namespace CHSNS.Data {
	public class NoteMediator : BaseMediator, CHSNS.Data.INoteMediator {
		public NoteMediator(DBExt id) : base(id) { }
		public IQueryable<NotePas> GetNotes(long userid) {
			return (from n in DBExt.DB.Note
					join p in DBExt.DB.Profile on n.UserID equals p.UserID
					where n.UserID == userid
					orderby n.ID descending
					select new NotePas {
						AddTime = n.AddTime,
						Body = n.Summary,
						CommentCount = n.CommentCount,
						ID = n.ID,
						Title = n.Title,
						UserID = n.UserID,
						ViewCount = n.ViewCount,
						WriteName = p.Name
					});
		}
		public NoteDetailsPas Details(long id) {
			var ret = (from n in DBExt.DB.Note
					   join p in DBExt.DB.Profile on n.UserID equals p.UserID
					   where n.ID == id
					   select new NoteDetailsPas {
						   Note = new NotePas {
							   AddTime = n.AddTime,
							   Body = n.Body,
							   CommentCount = n.CommentCount,
							   ID = n.ID,
							   Title = n.Title,
							   UserID = n.UserID,
							   ViewCount = n.ViewCount,
						   },
						   User = new UserCountPas {
							   ID = p.UserID,
							   Name = p.Name,
							   Count = n.CommentCount
						   }
					   }
					  ).FirstOrDefault();
			return ret;
		}
		public int AddViewCount(long id) {
			return DataBaseExecutor.Execute(@"update [note] set viewcount=viewcount+1 where id=@id", "@id", id);
		}
		/// <summary>
		/// userid
		/// </summary>
		public void Add(Note note, long userid) {
			note.LastCommentTime = note.EditTime = note.AddTime = DateTime.Now;
			note.UserID = userid;
			DBExt.DB.AddToNote(note);
			DBExt.DB.SaveChanges();
			DataBaseExecutor.Execute("update [profile] set NoteCount=NoteCount+1 where userid=@userid",
									 "@userid", userid);
			DBExt.Event.Add(new Event {
				OwnerID = userid,
				TemplateName = "AddNote",
				AddTime = DateTime.Now,
				ShowLevel = 0,
				Json = Dictionary.CreateFromArgs("id", note.ID,
				"title", note.Title, "addtime", note.AddTime, "name", CHUser.Username).ToJsonString()
			}
			);

		}
		public void Edit(Note note, long userid) {
			DataBaseExecutor.Execute(
				@"update [note] 
set title=@title,body=@body,EditTime=@edittime
where id=@id and userid=@userid",
				"@title", note.Title,
				"@body", note.Body,
				"@edittime", DateTime.Now,
				"@id", note.ID,
				"@userid", userid);
		}
		/// <summary>
		/// Delete the note by id
		/// </summary>
		public void Delete(long id, long userid) {
			DataBaseExecutor.Execute("delete [note] where id=@id and userid=@userid",
									 "@id", id,
									 "@userid", userid);
			DataBaseExecutor.Execute("update [profile] set NoteCount=NoteCount-1 where userid=@userid",
								 "@userid", userid);
		}
		public IQueryable<NotePas> GetLastNotes() {
			return (from n in DBExt.DB.Note
					join p in DBExt.DB.Profile on n.UserID equals p.UserID
					orderby n.ID descending
					select new NotePas {
						AddTime = n.AddTime,
						Body = n.Summary,
						CommentCount = n.CommentCount,
						ID = n.ID,
						Title = n.Title,
						UserID = n.UserID,
						ViewCount = n.ViewCount,
						WriteName = p.Name
					}).Take(10);
		}
	}
}
