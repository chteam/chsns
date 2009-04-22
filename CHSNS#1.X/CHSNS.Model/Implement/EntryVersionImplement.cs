using System;
using CHSNS.Models.Abstractions;

namespace CHSNS.Model
{
    public class EntryVersionImplement:IEntryVersion
    {
        public long ID { get; set; }
        public string Reason { get; set; }
        public DateTime AddTime { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public long UserID { get; set; }
        public int Status { get; set; }
        public long? EntryID { get; set; }
        public string ParentText { get; set; }
        public string Ext { get; set; }
    }
}