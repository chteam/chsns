using System.Collections.Generic;
using CHSNS.Model;
using CHSNS;
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
        bool AddVersion(long? id, Entry entry, EntryVersion entryVersion, string tags);

   
        EntryVersion GetVersion(long versionId);
        Entry Get(long entryId);
        Entry Get(string title);
    }
}