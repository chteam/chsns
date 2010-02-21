using System;
using CHSNS.Model;
using System.Collections.Generic;

using CHSNS.Operator;
using CHSNS.Models;

namespace CHSNS.Service {
	public class NoteService{
                static readonly NoteService _instance = new NoteService();
                private readonly INoteOperator Note;
                private readonly IEventOperator Event;
        public NoteService() {
                    Note = new NoteOperator();
            Event = new EventOperator();
        }

        public static NoteService GetInstance() {
            return _instance;
        }
		/// <summary>
		/// userid
		/// </summary>
        public void Add(Note note,IUser user)
		{
		    Note.Add(note);
		    switch ((NoteType) note.Type)
		    {
		        case NoteType.Note:
                    Event.Add(new Event
		                                {
		                                    OwnerId = note.UserId,
		                                    TemplateName = "AddNote",
		                                    AddTime = DateTime.Now,
		                                    ShowLevel = 0,
		                                    Json = Dictionary.CreateFromArgs("id", note.Id,
		                                                                     "title", note.Title, "addtime",
                                                                             note.AddTime, "name", user.Username).
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
            Note.Edit(note);
        }

	    /// <summary>
		/// Delete the not e by id
		/// </summary>
		public void Delete(long id, long pid, NoteType nt) {
	        Note.Delete(id, pid, nt);
		}

		public NoteDetailsPas Details(long id, NoteType? nt) {
		    return
		        Note.Details(id, nt);
		}

		public List<NotePas> GetLastNotes(int? ni) {
		    return
		        Note.GetLastNotes(ni);
		}

        public PagedList<NotePas> GetNotes(long pid, NoteType? nt, int p, int ep)
        {
            return Note.GetNotes(pid, nt, p, ep);
        }

	}
}
