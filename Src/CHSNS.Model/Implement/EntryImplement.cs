using System;
using CHSNS.Abstractions;

namespace CHSNS.Model
{
    public class EntryImplement:IEntry
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public long CreaterId { get; set; }
        public DateTime UpdateTime { get; set; }
        public long? CurrentId { get; set; }
        public int EditCount { get; set; }
        public long ViewCount { get; set; }
        public int Status { get; set; }
        public string Ext { get; set; }
    }
}