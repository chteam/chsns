using System;
using System.Collections.Generic;
using CHSNS.Common.Serializer;
using CHSNS.Model;
using CHSNS.Models;

using System.Linq;
namespace CHSNS.Service
{
    using System.ComponentModel.Composition;
    [Export]
    public class NoteService : BaseService<NoteService>
    {
       

        /// <summary>
        /// userid
        /// </summary>
        public void Add(Note note, IUser user)
        {
            note.LastCommentTime = note.EditTime = note.AddTime = DateTime.Now;
            note.LastCommentUsername = "";
            using (var db = DbInstance)
            {
                db.Note.Add(note);
                db.SaveChanges();
            }
            switch ((NoteType) note.Type)
            {
                case NoteType.Note:
                    EventService.Instance.Add(new Event
                                   {
                                       OwnerId = note.UserId,
                                       TemplateName = "AddNote",
                                       AddTime = DateTime.Now,
                                       ShowLevel = 0,
                                       Json = JsonAdapter.Serialize(Dictionary.CreateFromArgs("id", note.Id,
                                                                        "title", note.Title, "addtime",
                                                                        note.AddTime, "name", user.Name))
                                          
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
            using (var db = DbInstance)
            {
                var n = db.Note.FirstOrDefault(c => c.UserId == note.UserId && c.Id == note.Id);
                n.Title = note.Title;
                n.Body = note.Body;
                n.EditTime = DateTime.Now;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete the not e by id
        /// </summary>
        public void Delete(long id, long parentId, NoteType nt)
        {
            using (var db = DbInstance)
            {
                //var n = db.Note.FirstOrDefault(c => c.Id == id && c.UserId == pid);
                //if (null != n)
                //{
                //    db.DeleteObject(n);
                //    db.SaveChanges();
                //}
                db.Database.ExecuteSqlCommand(@"delete from [Note] where id=@p0 and userId=@p1"
                    , id, parentId);
            }
            switch (nt)
            {
                case NoteType.Note:
                    break;
                case NoteType.GroupPost:
                    break;
                default:
                    break;
            }
        }

        public Note Details(long id, NoteType? nt)
        {
            using (var db = DbInstance)
            {
                var type = (byte)(nt ?? NoteType.Note);
                var ret = db.Note.FirstOrDefault(n => n.Id == id && n.Type.Equals(type));
                return ret;
            }
        }

        public List<NotePas> GetLastNotes(int? ni)
        {
            using (var db = DbInstance)
            {
                return (from n in db.Note
                        join p in db.Profile on n.UserId equals p.UserId
                        orderby n.Id descending
                        select new NotePas
                        {
                            AddTime = n.AddTime,
                            Body = n.Summary,
                            CommentCount = n.CommentCount,
                            Id = n.Id,
                            Title = n.Title,
                            UserId = n.UserId,
                            ViewCount = n.ViewCount,
                            WriteName = p.Name
                        }).Take(ni ?? 10).ToList();
            }
        }

        public PagedList<NotePas> GetNotes(long pid, NoteType? nt, int p, int ep)
        {
            using (var db = DbInstance)
            {
                var type = (byte)(nt ?? NoteType.Note);
                var notes = (from n in db.Note
                             join pr in db.Profile on n.UserId equals pr.UserId
                             where n.ParentId == pid && n.Type.Equals(type)
                             orderby n.Id descending
                             select new NotePas
                             {
                                 AddTime = n.AddTime,
                                 Body = n.Summary,
                                 CommentCount = n.CommentCount,
                                 Id = n.Id,
                                 Title = n.Title,
                                 UserId = n.UserId,
                                 ViewCount = n.ViewCount,
                                 WriteName = pr.Name
                             });
                return notes.Pager(p, ep);
            }
        }
    }
}