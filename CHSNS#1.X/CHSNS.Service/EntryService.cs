﻿using System.Collections.Generic;
using CHSNS.Model;
using CHSNS.Abstractions;
using CHSNS.Operator;
using CHSNS.SQLServerImplement;

namespace CHSNS.Service {
    public class EntryService {
        static readonly EntryService _instance = new EntryService();
        private readonly IEntryOperator Entry;
        public EntryService() {
            Entry = new EntryOperator();
        }

        public static EntryService GetInstance() {
            return _instance;
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
        public bool AddVersion(long? id, IEntry entry, IEntryVersion entryVersion, string tags, IUser user)
        {
            return Entry.AddVersion(id, entry, entryVersion, tags, user);
        }
        public IEntryVersion GetVersion(long versionId)
        {
            return Entry.GetVersion(versionId);
        }
        public IEntry Get(long entryId) {
           return  Entry.Get(entryId);
        }

        public IEntry Get(string title) {
            return Entry.Get(title);
        }
    }
}
