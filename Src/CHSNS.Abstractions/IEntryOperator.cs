using System.Collections.Generic;
using CHSNS.Model;
using CHSNS.Models;

namespace CHSNS.Operator
{
    public interface IEntryOperator
    {
        bool HasTitle(string title);
        void DeleteByVersionId(long versionId,long uId);
        void LockCommonVersion(long versionId);
        void PassWaitVersion(long versionId);
        PagedList<EntryPas> List(int page, int pageSize);
        List<EntryPas> Historys(string title);
        List<EntryPas> Historys(long entryId);
		bool AddVersion(long? id, Entry entry, EntryVersion entryVersion, string tags, IUser user);

   
        EntryVersion GetVersion(long versionId);
		KeyValuePair<Entry, EntryVersion> Get(long entryId);
		KeyValuePair<Entry, EntryVersion> Get(string url);
    }
}