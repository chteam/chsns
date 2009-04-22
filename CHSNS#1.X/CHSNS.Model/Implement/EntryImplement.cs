using System;
using CHSNS.Abstractions;

namespace CHSNS.Model
{
    public class EntryImplement:IEntry
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public long CreaterID { get; set; }
        public DateTime UpdateTime { get; set; }
        public long? CurrentID { get; set; }
        public int EditCount { get; set; }
        public long ViewCount { get; set; }
        public int Status { get; set; }
        public string Ext { get; set; }
    }
}