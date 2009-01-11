using System;
using System.Linq;
using CHSNS.Models;
using CHSNS.ModelPas;

namespace CHSNS.Data {
	public class NoteMediator : BaseMediator, INoteMediator {
		public NoteMediator(IDBExt id) : base(id) { }
		public int AddViewCount(long id) {
			return DataBaseExecutor.Execute(@"update [note] set viewcount=viewcount+1 where id=@id", "@id", id);
		}
		/// <summary>
		/// userid
		/// </summary>
		public void Add(Note note) {
			note.LastCommentTime = note.EditTime = note.AddTime = DateTime.Now;
			DBExt.DB.Note.InsertOnSubmit(note);
			DBExt.DB.SaveChanges();
			switch ((NoteType)note.Type) {
				case NoteType.Note:
					DataBaseExecutor.Execute(
						@"update [profile] set NoteCount=NoteCount+1 where userid=@userid",
						 "@userid", note.UserID);
					DBExt.Event.Add(new Event {
						OwnerID = note.UserID,
						TemplateName = "AddNote",
						AddTime = DateTime.Now,
						ShowLevel = 0,
						Json = Dictionary.CreateFromArgs("id", note.ID,
						"title", note.Title, "addtime", note.AddTime, "name", CHUser.Username).ToJsonString()
					});
					break;
				case NoteType.GroupPost:
					DataBaseExecutor.Execute(
						@"update [Group] set PostCount=PostCount+1 where id=@id",
						 "@id", note.PID);
					break;
				default:
					break;
			}
		}
		public void Edit(Note note) {
			DataBaseExecutor.Execute(
				@"update [note] 
set title=@title,body=@body,EditTime=@edittime
where id=@id and userid=@userid",
				"@title", note.Title,
				"@body", note.Body,
				"@edittime", DateTime.Now,
				"@id", note.ID,
				"@userid", note.UserID);
		}
		/// <summary>
		/// Delete the note by id
		/// </summary>
		public void Delete(long id, long pid, NoteType nt) {
			switch (nt) { 
				case NoteType.Note:
					DataBaseExecutor.Execute(
						@"delete [note] where id=@id and userid=@userid",
						 "@id", id,
						 "@userid", pid);
					DataBaseExecutor.Execute(
						@"update [profile] set NoteCount=NoteCount-1 where userid=@userid",
										 "@userid", pid);
					break;
				case NoteType.GroupPost:
					break;
				default:
					break;
			}

		}

		#region INoteMediator 成员


		public NoteDetailsPas Details(long id, NoteType? nt) {
			var ret = (from n in DBExt.DB.Note
					   join p in DBExt.DB.Profile on n.UserID equals p.UserID
					   where n.ID == id && n.Type.Equals(nt ?? NoteType.Note)
					   select new NoteDetailsPas {
						   Note = n,
						   User = new UserCountPas {
							   ID = p.UserID,
							   Name = p.Name,
							   Count = n.CommentCount
						   }
					   }
					  ).FirstOrDefault();
			return ret;
		}

		public IQueryable<NotePas> GetLastNotes(int? ni) {
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
					}).Take(ni ?? 10);
		}

		public IQueryable<NotePas> GetNotes(long pid, NoteType? nt) {
			return (from n in DBExt.DB.Note
					join p in DBExt.DB.Profile on n.UserID equals p.UserID
					where n.PID == pid && n.Type.Equals(nt ?? NoteType.Note)
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

		#endregion
	}
}
