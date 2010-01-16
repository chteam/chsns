using System;
using System.Collections.Generic;
using System.Linq;
using CHSNS.Model;
using CHSNS.Abstractions;
using CHSNS.Operator;
using CHSNS.SQLServerImplement;

namespace CHSNS.Service {
    public class EntryService {
        static readonly EntryService Instance = new EntryService();
        private readonly EntryOperator Entry;
        public EntryService() {
            Entry = new EntryOperator();
        }

        public static EntryService GetInstance() {
            return Instance;
        }
        public bool HasTitle(string title) {
            return Entry.HasTitle(title);
        }
        public void DeleteByVersionId(long versionId, long uId) {
            Entry.DeleteByVersionId(versionId, uId);
        }
        public void LockCommonVersion(long versionId) {
            Entry.LockCommonVersion(versionId);
        }
        public void PassWaitVersion(long versionId) {
            Entry.PassWaitVersion(versionId);
        }
        public PagedList<EntryPas> List(int page, int pageSize)
        {
          return   Entry.List(page, pageSize);
        }
        public List<EntryPas> Historys(string title)
        {
            return Entry.Historys(title);
        }
        public List<EntryPas> Historys(long entryId) {
            return Entry.Historys(entryId);
        }
        public bool AddVersion(long? id, IEntry entry, IEntryVersion entryVersion, string tags, IUser user) {
            var dt = DateTime.Now;
            if(!id.HasValue)
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
                
            return Entry.AddVersion(id, entry, entryVersion, tags);
        }
        public IEntryVersion GetVersion(long versionId)
        {
            return Entry.GetVersion(versionId);
        }
        public IEntry Get(long entryId) {
           return  Entry.Get(entryId).Key;
        }

        public IEntry Get(string title) {
            return Entry.Get(title);
        }
    }
}
