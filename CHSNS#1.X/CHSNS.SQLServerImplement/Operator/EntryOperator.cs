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
                var v = db.EntryVersion.FirstOrDefault(c => c.ID == versionId);
                if (v == null) return;
                var e = db.Entry.FirstOrDefault(c => c.ID == v.EntryID);
                if (e == null) return;
                var vs = db.EntryVersion.Where(c => c.EntryID == e.ID);
                if (e.CreaterID != uId) return;

                db.EntryVersion.DeleteAllOnSubmit(vs);
                db.Entry.DeleteOnSubmit(e);
                db.SaveChanges();
            }
        }

        public void LockCommonVersion(long versionId)
        {
            using (var db = DBExtInstance)
            {
                var ev = db.EntryVersion.FirstOrDefault(c => c.ID == versionId);
                ev.Status = (int)EntryVersionType.Lock;
               
                var lastv =
                    db.EntryVersion.Where(
                        c => c.EntryID == ev.EntryID && c.Status == (int) EntryVersionType.Common)
                        .OrderByDescending(c=>c.AddTime)
                        .FirstOrDefault();
                if(lastv !=null)
                {
                    var e = db.Entry.FirstOrDefault(c => c.ID == ev.EntryID);
                    e.CurrentID = lastv.ID;
                }
                db.SaveChanges();
            }
        }

        public void PassWaitVersion(long versionId)
        {
            using (var db = DBExtInstance) {
                var ev = db.EntryVersion.FirstOrDefault(c => c.ID == versionId);
                ev.Status = (int)EntryVersionType.Common;
                var e = db.Entry.Where(c => c.ID == ev.EntryID).SingleOrDefault();
                e.CurrentID = ev.ID;
                db.SaveChanges();
            }
        }

        public PagedList<EntryPas> List(int page, int pageSize)
        {
            using (var db = DBExtInstance)
            {
                var newlist = (from v in db.EntryVersion
                               join e in db.Entry on v.EntryID equals e.ID
                               join p in db.Profile on v.UserID equals p.UserID
                               orderby v.ID descending
                               select new EntryPas
                                          {
                                              ID = v.ID,
                                              AddTime = v.AddTime,
                                              EditCount = e.EditCount,
                                              Reason = v.Reason,
                                              Title = e.Title,
                                              User = new NameIDPas {Name = p.Name, ID = p.UserID},
                                              ViewCount = e.ViewCount,
                                              Status = v.Status
                                          });
                var li1 = newlist;
                // li1 = li1.Where(c => c.User.ID == CHUser.UserId);
                //AreaList.Load(AreaType.EntryArea).Where(
                //   c => c.ID == e.AreaID).FirstOrDefault().Title
                return li1.Pager(page, pageSize);
            }
        }

        public List<EntryPas> Historys(string title)
        {
            using (var db = DBExtInstance)
            {
                var newlist = (from v in db.EntryVersion
                               join e in db.Entry on v.EntryID equals e.ID
                               join p in db.Profile on v.UserID equals p.UserID
                               where e.Title == title
                               orderby v.ID descending
                               select new EntryPas
                                          {
                                              ID = v.ID,
                                              AddTime = v.AddTime,
                                              EditCount = e.EditCount,
                                              Reason = v.Reason,
                                              Title = e.Title,
                                              User = new NameIDPas {Name = p.Name, ID = p.UserID},
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
                               join e in db.Entry on v.EntryID equals e.ID
                               join p in db.Profile on v.UserID equals p.UserID
                               where e.ID == entryId
                               orderby v.ID descending
                               select new EntryPas
                                          {
                                              ID = v.ID,
                                              AddTime = v.AddTime,
                                              EditCount = e.EditCount,
                                              Reason = v.Reason,
                                              Title = e.Title,
                                              User = new NameIDPas {Name = p.Name, ID = p.UserID},
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
                    entry = db.Entry.Where(c => c.ID == id.Value).FirstOrDefault();
                    entry.UpdateTime = DateTime.Now;
                    entry.EditCount += 1;
                }
                else {
                    var old = db.Entry.Where(c => c.Title == entry.Title.Trim()).Count();
                    if (old > 0) return false;
                    db.AddToEntry(entry as Entry);
                    db.SaveChanges();
                }
                entryVersion.EntryID = entry.ID;
                db.AddToEntryVersion(entryVersion as EntryVersion);
                db.SaveChanges();
                entry.CurrentID = entryVersion.ID;
                db.SaveChanges();
            }
            return true;
        }

        public IEntryVersion GetVersion(long versionId)
        {
            using (var db = DBExtInstance)
            {
               return 
                    db.EntryVersion.FirstOrDefault(c => c.ID == versionId);
            }
        }

        public IEntry Get(long entryId)
        {
            using (var db = DBExtInstance) {
                return db.Entry.FirstOrDefault(c => c.ID == entryId);
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
