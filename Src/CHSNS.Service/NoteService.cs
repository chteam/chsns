using System;
using System.Collections.Generic;
using CHSNS.Model;
using CHSNS.Models;
using CHSNS.Operator;

namespace CHSNS.Service
{
    public class NoteService : BaseService<NoteService>
    {
       
        private readonly NoteOperator _note;

        public NoteService()
        {
            _note = new NoteOperator();
 
        }


        /// <summary>
        /// userid
        /// </summary>
        public void Add(Note note, IUser user)
        {
            _note.Add(note);
            switch ((NoteType) note.Type)
            {
                case NoteType.Note:
                    EventService.Instance.Add(new Event
                                   {
                                       OwnerId = note.UserId,
                                       TemplateName = "AddNote",
                                       AddTime = DateTime.Now,
                                       ShowLevel = 0,
                                       Json = Dictionary.CreateFromArgs("id", note.Id,
                                                                        "title", note.Title, "addtime",
                                                                        note.AddTime, "name", user.Name).
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
            _note.Edit(note);
        }

        /// <summary>
        /// Delete the not e by id
        /// </summary>
        public void Delete(long id, long pid, NoteType nt)
        {
            _note.Delete(id, pid, nt);
        }

        public NoteDetailsPas Details(long id, NoteType? nt)
        {
            return
                _note.Details(id, nt);
        }

        public List<NotePas> GetLastNotes(int? ni)
        {
            return
                _note.GetLastNotes(ni);
        }

        public PagedList<NotePas> GetNotes(long pid, NoteType? nt, int p, int ep)
        {
            return _note.GetNotes(pid, nt, p, ep);
        }
    }
}