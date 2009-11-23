using System;
using CHSNS.Abstractions;

namespace CHSNS.Model
{
    public class EntryVersionImplement:IEntryVersion
    {
        public long Id { get; set; }
        public string Reason { get; set; }
        public DateTime AddTime { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public long UserId { get; set; }
        public int Status { get; set; }
        public long? EntryId { get; set; }
        public string ParentText { get; set; }
        public string Ext { get; set; }
    }
}