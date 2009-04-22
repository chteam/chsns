using System.Collections.Generic;
using CHSNS.Model;
using CHSNS.Abstractions;

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
        bool AddVersion(long? id, IEntry entry, IEntryVersion entryVersion, string tags);

   
        IEntryVersion GetVersion(long versionId);
        IEntry Get(long entryId);
        IEntry Get(string title);
    }
}