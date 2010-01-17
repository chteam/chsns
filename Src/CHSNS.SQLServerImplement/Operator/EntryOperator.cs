using System;
using System.Collections.Generic;
using System.Linq;
using CHSNS.Model;
using CHSNS.Abstractions;
using CHSNS.Operator;
using Microsoft.Data.Extensions
;
namespace CHSNS.SQLServerImplement
{
    public class EntryOperator : BaseOperator
    {//, IEntryOperator {
        public bool HasTitle(string url)
        {
            using (var db = DBExtInstance)
            {
                var exists = db.Entry.Where(c => c.Url == url).Count() != 0;
                return exists;
            }
        }
        /// <summary>
        /// RemoveEntry_VersionId
        /// </summary>
        /// <param name="versionId"></param>
        /// <param name="uId"></param>
        public void DeleteByVersionId(long versionId, long uId)
        {
            using (var db = DBExtInstance)
            {
                db.ExecuteFunctionNonQuery("RemoveEntry_VersionId", "VersionId", versionId,
                    "CreaterId", uId);
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
                db.SubmitChanges();
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

        public bool AddVersion(long? id, IEntry entry, IEntryVersion entryVersion, string tags, IUser user)
        {
            var dt = DateTime.Now;
            if (!id.HasValue)
            {
                entry.Status = (int)EntryType.Common;
                entry.CreaterId = user.UserID;
                entry.UpdateTime = dt;
                entry.EditCount = 1;
            }
            entryVersion.UserId = user.UserID;
            entryVersion.Status = (int)(user.IsAdmin ? EntryType.Common : EntryType.Wait);
            entryVersion.AddTime = dt;
            entryVersion.Reference += "";
            entryVersion.Ext = JsonAdapter.Serialize(new EntryExt { Tags = tags.Split(',').ToList() });
            using (var db = DBExtInstance)
            {
                var x = db.ExecuteFunctionScalar("EntryAddVersion",
                        "id", id,
     "@title", entryVersion.Title,
     "@url", entry.Url,
     "@createrId", entry.CreaterId,
     "@status", entry.Status,
     "@ext", entry.Ext,
     "@reason", entryVersion.Reason,
     "@description", entryVersion.Description,
     "@reference", entryVersion.Reference,
     "@userId", entryVersion.UserId,
     "@parentText", entryVersion.ParentText,
     "@vExt", entryVersion.Ext, "@vStatus", entryVersion.Status
                    );
                if (x != null && x.Equals(0)) return false;
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
        static readonly Materializer<Entry> Entry = new Materializer<Entry>(r =>
                              new Entry
                              {
                                  Id = r.Field<long>("Id"),
                                  Status = r.Field<int>("status"),
                                  Url = r.Field<string>("Url"),
                              });
        static readonly Materializer<EntryVersion> EntryVersion = new Materializer<EntryVersion>(r =>
                           new EntryVersion
                           {
                               Id = r.Field<long>("Id"),
                               Title = r.Field<string>("Title"),
                               Description = r.Field<string>("Description"),
                               Ext = r.Field<string>("Ext"),
                           });
        public KeyValuePair<IEntry, IEntryVersion> Get(long entryId)
        {
            using (var db = DBExtInstance)
            using (var cmd = db.CreateStoredProcedure("GetEntryVersion_Id", "Id", entryId))
            using (db.CreateConnectionScope())
            using (var reader = cmd.ExecuteReader())
            {
                var e = Entry.Materialize(reader).FirstOrDefault();
                IEntryVersion v = null;
                if (reader.NextResult())
                    v = EntryVersion.Materialize(reader).FirstOrDefault();
                return new KeyValuePair<IEntry, IEntryVersion>(e, v);
            }
        }

        public KeyValuePair<IEntry, IEntryVersion> Get(string url)
        {
            using (var db = DBExtInstance)
            using (var cmd = db.CreateStoredProcedure("GetEntryVersion_Url", "url", url))
            using (db.CreateConnectionScope())
            using (var reader = cmd.ExecuteReader())
            {
                var e = Entry.Materialize(reader).FirstOrDefault();
                IEntryVersion v = null;
                if (reader.NextResult())
                    v = EntryVersion.Materialize(reader).FirstOrDefault();
                return new KeyValuePair<IEntry, IEntryVersion>(e, v);
            }
        }
        public KeyValuePair<IEntry, IEntryVersion> GetFromVersion(long versionId)
        {
            using (var db = DBExtInstance)
            using (var cmd = db.CreateStoredProcedure("GetEntryVersion_VersionId", "VersionId", versionId))
            using (db.CreateConnectionScope())
            using (var reader = cmd.ExecuteReader())
            {
                var e = Entry.Materialize(reader).FirstOrDefault();
                IEntryVersion v = null;
                if (reader.NextResult())
                    v = EntryVersion.Materialize(reader).FirstOrDefault();
                return new KeyValuePair<IEntry, IEntryVersion>(e, v);
            }
        }
    }
}
