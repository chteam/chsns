using System;
using System.Linq;
using CHSNS.Models;
using CHSNS.Model;
using System.Collections.Generic;

namespace CHSNS.Service {
	public class NoteService : BaseService, INoteService {
		public NoteService(IDBManager id) : base(id) { }
		/// <summary>
		/// userid
		/// </summary>
        public void Add(Note note)
		{
		    using (var db = DBExt.Instance)
		    {
		        note.LastCommentTime = note.EditTime = note.AddTime = DateTime.Now;
		        db.Note.InsertOnSubmit(note);
		        db.SaveChanges();
		    }
		    switch ((NoteType) note.Type)
		    {
		        case NoteType.Note:
		            DBExt.Event.Add(new Event
		                                {
		                                    OwnerID = note.UserID,
		                                    TemplateName = "AddNote",
		                                    AddTime = DateTime.Now,
		                                    ShowLevel = 0,
		                                    Json = Dictionary.CreateFromArgs("id", note.ID,
		                                                                     "title", note.Title, "addtime",
		                                                                     note.AddTime, "name", CHUser.Username).
		                                        ToJsonString()
		                                });
		            break;
		        case NoteType.GroupPost:
		            break;
		        default:
		            break;
		    }
		}

        public void Edit(Note note)
        {
            using (var db = DBExt.Instance)
            {
                var n = db.Note.FirstOrDefault(c => c.UserID == note.UserID && c.ID == note.ID);
                n.Title = HttpContext.Server.HtmlEncode(note.Title);
                n.Body = note.Body;
                n.EditTime = DateTime.Now;
                db.SubmitChanges();
            }
            #region sql

//            DataBaseExecutor.Execute(
//                @"update [note] 
//set title=@title,body=@body,EditTime=@edittime
//where id=@id and userid=@userid",
//                "@title", note.Title,
//                "@body", note.Body,
//                "@edittime", DateTime.Now,
//                "@id", note.ID,
//                "@userid", note.UserID);

            #endregion
        }

	    /// <summary>
		/// Delete the not e by id
		/// </summary>
		public void Delete(long id, long pid, NoteType nt) {
            using (var db = DBExt.Instance)
            {
                var n = db.Note.FirstOrDefault(c => c.ID == id && c.UserID == pid);
                if(null!=n)
                {
                    db.Note.DeleteOnSubmit(n);
                    db.SubmitChanges();
                }

            }
	        switch (nt) { 
				case NoteType.Note:
					break;
				case NoteType.GroupPost:
					break;
				default:
					break;
			}

		}

		public NoteDetailsPas Details(long id, NoteType? nt) {
            using (var db = DBExt.Instance)
            {
                var ret = (from n in db.Note
                           join p in db.Profile on n.UserID equals p.UserID
                           where n.ID == id && n.Type.Equals(nt ?? NoteType.Note)
                           select new NoteDetailsPas
                                      {
                                          Note = n,
                                          User = new UserCountPas
                                                     {
                                                         ID = p.UserID,
                                                         Name = p.Name,
                                                         Count = n.CommentCount
                                                     }
                                      }
                          ).FirstOrDefault();
                return ret;
            }
		}

		public List<NotePas> GetLastNotes(int? ni) {
            using (var db = DBExt.Instance)
            {
                return (from n in db.Note
                        join p in db.Profile on n.UserID equals p.UserID
                        orderby n.ID descending
                        select new NotePas
                                   {
                                       AddTime = n.AddTime,
                                       Body = n.Summary,
                                       CommentCount = n.CommentCount,
                                       ID = n.ID,
                                       Title = n.Title,
                                       UserID = n.UserID,
                                       ViewCount = n.ViewCount,
                                       WriteName = p.Name
                                   }).Take(ni ?? 10).ToList();
            }
		}

        public PagedList<NotePas> GetNotes(long pid, NoteType? nt, int p, int ep)
        {
            using (var db = DBExt.Instance)
            {
                return (from n in db.Note
                        join pr in db.Profile on n.UserID equals pr.UserID
                        where n.PID == pid && n.Type.Equals(nt ?? NoteType.Note)
                        orderby n.ID descending
                        select new NotePas
                                   {
                                       AddTime = n.AddTime,
                                       Body = n.Summary,
                                       CommentCount = n.CommentCount,
                                       ID = n.ID,
                                       Title = n.Title,
                                       UserID = n.UserID,
                                       ViewCount = n.ViewCount,
                                       WriteName = pr.Name
                                   }).Pager(p, ep);
            }
        }

	}
}
