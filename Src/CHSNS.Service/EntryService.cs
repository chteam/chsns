
namespace CHSNS.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CHSNS.Model;
    using CHSNS.Models;
    using System.ComponentModel.Composition;
    [Export]
    public class EntryService : BaseService
    {
        public bool HasTitle(string url)
        {
            using (var db = DbInstance)
            {
                var exists = db.Wikis.Where(c => c.Url == url).Count() != 0;
                return exists;
            }
        }
        public void DeleteVersion(long versionId, long uId)
        {
            using (var db = DbInstance)
            {
                var version = db.WikiVersions.FirstOrDefault(c => c.Id == versionId);
                if (version == null) return;
                var entry = db.Wikis.FirstOrDefault(c => c.Id == version.EntryId);
                if (entry == null) return;
                entry.EditCount--;
                db.WikiVersions.Remove(version);
                db.SaveChanges();
            }
        }

        public void DeleteByVersionId(long versionId, long uId)
        {
            using (var db = DbInstance)
            {
                var version = db.WikiVersions.FirstOrDefault(c => c.Id == versionId);
                if (version == null) return;
                var entry = db.Wikis.FirstOrDefault(c => c.Id == version.EntryId);
                if (entry == null) return;
                var vs = db.WikiVersions.Where(c => c.EntryId == entry.Id);
                if (entry.CreaterId != uId) return;

                db.WikiVersions.BulkRemove(vs);
                db.Wikis.Remove(entry);
                db.SaveChanges();
            }
        }

        public void LockCommonVersion(long versionId)
        {
            using (var db = DbInstance)
            {
                var ev = db.WikiVersions.FirstOrDefault(c => c.Id == versionId);
                ev.Status = (int)EntryVersionType.Lock;

                var lastv =
                    db.WikiVersions.Where(
                        c => c.EntryId == ev.EntryId && c.Status == (int)EntryVersionType.Common)
                        .OrderByDescending(c => c.AddTime)
                        .FirstOrDefault();
                if (lastv != null)
                {
                    var e = db.Wikis.FirstOrDefault(c => c.Id == ev.EntryId);
                    e.CurrentId = lastv.Id;
                }
                db.SaveChanges();
            }
        }

        public void PassWaitVersion(long versionId)
        {
            using (var db = DbInstance)
            {
                var ev = db.WikiVersions.FirstOrDefault(c => c.Id == versionId);
                ev.Status = (int)EntryVersionType.Common;
                var e = db.Wikis.Where(c => c.Id == ev.EntryId).SingleOrDefault();
                e.CurrentId = ev.Id;
                db.SaveChanges();
            }
        }

        public PagedList<EntryPas> List(int page, int pageSize)
        {
            using (var db = DbInstance)
            {
                var newlist = (from v in db.WikiVersions
                               join e in db.Wikis on v.EntryId equals e.Id
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
            using (var db = DbInstance)
            {
                var newlist = (from v in db.WikiVersions
                               join e in db.Wikis on v.EntryId equals e.Id
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
            using (var db = DbInstance)
            {
                var newlist = (from v in db.WikiVersions
                               join e in db.Wikis on v.EntryId equals e.Id
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

        public bool AddVersion(long? id, Wiki wiki, WikiVersion wikiVersion, string tags, IUser user,bool isNew)
        {
            var isDisplayTitle = wiki.IsDisplayTitle;
            using (var db = DbInstance)
            {
                wiki.UpdateTime = DateTime.Now;
                if (id.HasValue)
                {
                    wiki = db.Wikis.Where(c => c.Id == id.Value).FirstOrDefault();
                    wiki.EditCount += 1;
                    if (!Equals(wiki.IsDisplayTitle, isDisplayTitle))
                        wiki.IsDisplayTitle = isDisplayTitle;
                }
                else
                {
                    var old = db.Wikis.Where(c => c.Url == wiki.Url.Trim()).Count();
                    if (old > 0) return false;
                    wiki.EditCount = 1;
                    db.Wikis.Add(wiki);
                    db.SaveChanges();
                
                }

                if (id.HasValue || isNew) {
                    wikiVersion.EntryId = wiki.Id;
                    wikiVersion.AddTime = DateTime.Now;
                    wikiVersion.Reference = wikiVersion.Reference ?? "";
                    wikiVersion.Reason = wikiVersion.Reason ?? "";
                    db.WikiVersions.Add(wikiVersion);
                    db.SaveChanges();
                    wiki.CurrentId = wikiVersion.Id;
                }
                else {
                    var ev = db.WikiVersions.FirstOrDefault(c => c.Id == wikiVersion.Id);
                    ev.Description = wikiVersion.Description;
                    ev.Title = wikiVersion.Title;
                    ev.AddTime = DateTime.Now;
                }
                               
                db.SaveChanges();
            }
            return true;
        }

        public WikiVersion GetVersion(long versionId)
        {
            using (var db = DbInstance)
            {
                return
                     db.WikiVersions.FirstOrDefault(c => c.Id == versionId);
            }
        }

        public Tuple<Wiki, WikiVersion> Get(long entryId)
        {
            using (var db = DbInstance)
            {
                var entry = db.Wikis.FirstOrDefault(c => c.Id == entryId);
                if (entry == null) return Tuple.Create<Wiki, WikiVersion>(null, null);
                var ev = db.WikiVersions.FirstOrDefault(c => c.Id == entry.CurrentId);
                return Tuple.Create(entry, ev);
            }
        }

        public KeyValuePair<Wiki, WikiVersion> Get(string url)
        {
            using (var db = DbInstance)
            {
                var entry = db.Wikis.FirstOrDefault(c => c.Url == url);
                if (entry == null) return new KeyValuePair<Wiki, WikiVersion>(null, null);
                return new KeyValuePair<Wiki, WikiVersion>(
                  entry,
                  db.WikiVersions.FirstOrDefault(c => c.Id == entry.CurrentId));
            }
        }
        public KeyValuePair<Wiki, WikiVersion> GetFromVersion(long versionId)
        {
            using (var db = DbInstance)
            {
                var v = db.WikiVersions.FirstOrDefault(c => c.Id == versionId);
                return new KeyValuePair<Wiki, WikiVersion>(
                    db.Wikis.FirstOrDefault(c => c.Id == v.EntryId), v
                    );
            }
        }
        
    }
}
