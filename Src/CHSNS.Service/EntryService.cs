
namespace CHSNS.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CHSNS.Model;
    using CHSNS.Models;
    public class EntryService : BaseService<EntryService>
    {
        public bool HasTitle(string url)
        {
            using (var db = DBExtInstance)
            {
                var exists = db.Entry.Where(c => c.Url == url).Count() != 0;
                return exists;
            }
        }
        public void DeleteVersion(long versionId, long uId)
        {
            using (var db = DBExtInstance)
            {
                var version = db.EntryVersion.FirstOrDefault(c => c.Id == versionId);
                if (version == null) return;
                var entry = db.Entry.FirstOrDefault(c => c.Id == version.EntryId);
                if (entry == null) return;
                entry.EditCount--;
                db.DeleteObject(version);
                db.SaveChanges();
            }
        }

        public void DeleteByVersionId(long versionId, long uId)
        {
            using (var db = DBExtInstance)
            {
                var version = db.EntryVersion.FirstOrDefault(c => c.Id == versionId);
                if (version == null) return;
                var entry = db.Entry.FirstOrDefault(c => c.Id == version.EntryId);
                if (entry == null) return;
                var vs = db.EntryVersion.Where(c => c.EntryId == entry.Id);
                if (entry.CreaterId != uId) return;

                db.DeleteObject(vs);
                db.DeleteObject(entry);
                db.SaveChanges();
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
                        c => c.EntryId == ev.EntryId && c.Status == (int)EntryVersionType.Common)
                        .OrderByDescending(c => c.AddTime)
                        .FirstOrDefault();
                if (lastv != null)
                {
                    var e = db.Entry.FirstOrDefault(c => c.Id == ev.EntryId);
                    e.CurrentId = lastv.Id;
                }
                db.SaveChanges();
            }
        }

        public void PassWaitVersion(long versionId)
        {
            using (var db = DBExtInstance)
            {
                var ev = db.EntryVersion.FirstOrDefault(c => c.Id == versionId);
                ev.Status = (int)EntryVersionType.Common;
                var e = db.Entry.Where(c => c.Id == ev.EntryId).SingleOrDefault();
                e.CurrentId = ev.Id;
                db.SaveChanges();
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
                                   Title = v.Title,
                                   Url = e.Url,
                                   User = new NameIdPas { Name = p.Name, Id = p.UserId },
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

        public List<EntryPas> Historys(string url)
        {
            using (var db = DBExtInstance)
            {
                var newlist = (from v in db.EntryVersion
                               join e in db.Entry on v.EntryId equals e.Id
                               join p in db.Profile on v.UserId equals p.UserId
                               where e.Url == url
                               orderby v.Id descending
                               select new EntryPas
                               {
                                   Id = v.Id,
                                   Url = e.Url,
                                   AddTime = v.AddTime,
                                   EditCount = e.EditCount,
                                   Reason = v.Reason,
                                   Title = v.Title,
                                   User = new NameIdPas { Name = p.Name, Id = p.UserId },
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
                                   Title = v.Title,
                                   Url = e.Url,
                                   User = new NameIdPas { Name = p.Name, Id = p.UserId },
                                   ViewCount = e.ViewCount,
                                   Status = v.Status
                               });
                var li1 = newlist;
                return li1.ToList();
            }
        }

        public bool AddVersion(long? id, Entry entry, EntryVersion entryVersion, string tags, IUser user)
        {
            var isDisplayTitle = entry.IsDisplayTitle;
            using (var db = DBExtInstance)
            {
                if (id.HasValue)
                {
                    entry = db.Entry.Where(c => c.Id == id.Value).FirstOrDefault();
                    entry.UpdateTime = DateTime.Now;
                    entry.EditCount += 1;
                    if (!Equals(entry.IsDisplayTitle, isDisplayTitle))
                        entry.IsDisplayTitle = isDisplayTitle;
                }
                else
                {
                    var old = db.Entry.Where(c => c.Url == entry.Url.Trim()).Count();
                    if (old > 0) return false;
                    db.Entry.AddObject(entry);
                    db.SaveChanges();
                }
                entryVersion.EntryId = entry.Id;
                entryVersion.AddTime = DateTime.Now;
                entryVersion.Reference = entryVersion.Reference ?? "";
                entryVersion.Reason = entryVersion.Reason ?? "";
                db.EntryVersion.AddObject(entryVersion);
                db.SaveChanges();
                entry.CurrentId = entryVersion.Id;
                db.SaveChanges();
            }
            return true;
        }

        public EntryVersion GetVersion(long versionId)
        {
            using (var db = DBExtInstance)
            {
                return
                     db.EntryVersion.FirstOrDefault(c => c.Id == versionId);
            }
        }

        public KeyValuePair<Entry, EntryVersion> Get(long entryId)
        {
            using (var db = DBExtInstance)
            {
                var entry = db.Entry.FirstOrDefault(c => c.Id == entryId);
                return new KeyValuePair<Entry, EntryVersion>(
                    entry,
                    db.EntryVersion.FirstOrDefault(c => c.Id == entry.CurrentId));
            }
        }

        public KeyValuePair<Entry, EntryVersion> Get(string url)
        {
            using (var db = DBExtInstance)
            {
                var entry = db.Entry.FirstOrDefault(c => c.Url == url);
                return new KeyValuePair<Entry, EntryVersion>(
                  entry,
                  db.EntryVersion.FirstOrDefault(c => c.Id == entry.CurrentId));
            }
        }
        public KeyValuePair<Entry, EntryVersion> GetFromVersion(long versionId)
        {
            using (var db = DBExtInstance)
            {
                var v = db.EntryVersion.FirstOrDefault(c => c.Id == versionId);
                return new KeyValuePair<Entry, EntryVersion>(
                    db.Entry.FirstOrDefault(c => c.Id == v.EntryId), v
                    );
            }
        }
        
    }
}
