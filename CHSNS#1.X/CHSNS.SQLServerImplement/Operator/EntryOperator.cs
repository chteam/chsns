using System;
using System.Collections.Generic;
using System.Linq;
using CHSNS.Model;
using CHSNS.Abstractions;
using CHSNS.Operator;

namespace CHSNS.SQLServerImplement {
    public class EntryOperator : BaseOperator, IEntryOperator {
        public bool HasTitle(string title) {
            using (var db = DBExtInstance) {
                var exists = db.Entry.Where(c => c.Title == title).Count() != 0;
                return exists;
            }
        }

        public void DeleteByVersionId(long versionId, long uId) {
            using (var db = DBExtInstance) {
                var v = db.EntryVersion.FirstOrDefault(c => c.Id == versionId);
                if (v == null) return;
                var e = db.Entry.FirstOrDefault(c => c.Id == v.EntryId);
                if (e == null) return;
                var vs = db.EntryVersion.Where(c => c.EntryId == e.Id);
                if (e.CreaterId != uId) return;

                db.EntryVersion.DeleteAllOnSubmit(vs);
                db.Entry.DeleteOnSubmit(e);
                db.SubmitChanges();
            }
        }

        public void LockCommonVersion(long versionId)
        {
            using (var db = DBExtInstance)
            {
                var ev = db.EntryVersion.FirstOrDefault(c => c.Id == versionId);
                ev.Status = (int)EntryVersionType.Lock;
               
                var lastv =
                    db.EntryVersion.Where(
                        c => c.EntryId == ev.EntryId && c.Status == (int) EntryVersionType.Common)
                        .OrderByDescending(c=>c.AddTime)
                        .FirstOrDefault();
                if(lastv !=null)
                {
                    var e = db.Entry.FirstOrDefault(c => c.Id == ev.EntryId);
                    e.CurrentId = lastv.Id;
                }
                db.SubmitChanges();
            }
        }

        public void PassWaitVersion(long versionId)
        {
            using (var db = DBExtInstance) {
                var ev = db.EntryVersion.FirstOrDefault(c => c.Id == versionId);
                ev.Status = (int)EntryVersionType.Common;
                var e = db.Entry.Where(c => c.Id == ev.EntryId).SingleOrDefault();
                e.CurrentId = ev.Id;
                db.SubmitChanges();
            }
        }

        public PagedList<EntryPas> List(int page, int pageSize)
        {
            using (var db = DBExtInstance)
            {
                var newlist = (from v in db.EntryVersion
                               join e in db.Entry on v.EntryId equals e.Id
                               join p in db.Profile on v.UserId equals p.UserId
                               orderby v.Id descending
                               select new EntryPas
                                          {
                                              Id = v.Id,
                                              AddTime = v.AddTime,
                                              EditCount = e.EditCount,
                                              Reason = v.Reason,
                                              Title = e.Title,
                                              User = new NameIdPas {Name = p.Name, Id = p.UserId},
                                              ViewCount = e.ViewCount,
                                              Status = v.Status
                                          });
                var li1 = newlist;
                // li1 = li1.Where(c => c.User.Id == CHUser.UserId);
                //AreaList.Load(AreaType.EntryArea).Where(
                //   c => c.Id == e.AreaId).FirstOrDefault().Title
                return li1.Pager(page, pageSize);
            }
        }

        public List<EntryPas> Historys(string title)
        {
            using (var db = DBExtInstance)
            {
                var newlist = (from v in db.EntryVersion
                               join e in db.Entry on v.EntryId equals e.Id
                               join p in db.Profile on v.UserId equals p.UserId
                               where e.Title == title
                               orderby v.Id descending
                               select new EntryPas
                                          {
                                              Id = v.Id,
                                              AddTime = v.AddTime,
                                              EditCount = e.EditCount,
                                              Reason = v.Reason,
                                              Title = e.Title,
                                              User = new NameIdPas {Name = p.Name, Id = p.UserId},
                                              ViewCount = e.ViewCount,
                                              Status = v.Status
                                          });
                var li1 = newlist;
                return li1.ToList();
            }
        }

        public List<EntryPas> Historys(long entryId)
        {
            using (var db = DBExtInstance)
            {
                var newlist = (from v in db.EntryVersion
                               join e in db.Entry on v.EntryId equals e.Id
                               join p in db.Profile on v.UserId equals p.UserId
                               where e.Id == entryId
                               orderby v.Id descending
                               select new EntryPas
                                          {
                                              Id = v.Id,
                                              AddTime = v.AddTime,
                                              EditCount = e.EditCount,
                                              Reason = v.Reason,
                                              Title = e.Title,
                                              User = new NameIdPas {Name = p.Name, Id = p.UserId},
                                              ViewCount = e.ViewCount,
                                              Status = v.Status
                                          });
                var li1 = newlist;
                return li1.ToList();
            }
        }
        
        public bool AddVersion(long? id, IEntry entry, IEntryVersion entryVersion, string tags)
        {
           
            using (var db = DBExtInstance) { 
                if (id.HasValue) {
                    entry = db.Entry.Where(c => c.Id == id.Value).FirstOrDefault();
                    entry.UpdateTime = DateTime.Now;
                    entry.EditCount += 1;
                }
                else {
                    var old = db.Entry.Where(c => c.Title == entry.Title.Trim()).Count();
                    if (old > 0) return false;
                    db.Entry.InsertOnSubmit(entry as Entry);
                    db.SubmitChanges();
                }
                entryVersion.EntryId = entry.Id;
                db.EntryVersion.InsertOnSubmit(entryVersion as EntryVersion);
                db.SubmitChanges();
                entry.CurrentId = entryVersion.Id;
                db.SubmitChanges();
            }
            return true;
        }

        public IEntryVersion GetVersion(long versionId)
        {
            using (var db = DBExtInstance)
            {
               return 
                    db.EntryVersion.FirstOrDefault(c => c.Id == versionId);
            }
        }

        public IEntry Get(long entryId)
        {
            using (var db = DBExtInstance) {
                return db.Entry.FirstOrDefault(c => c.Id == entryId);
            }
        }

        public IEntry Get(string title)
        {
            using (var db = DBExtInstance) {
              return  db.Entry.FirstOrDefault(c => c.Title == title);  
            }
        }
    }
}
