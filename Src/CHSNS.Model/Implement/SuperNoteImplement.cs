using System;
using CHSNS.Abstractions;

namespace CHSNS.Model
{
    public class SuperNoteImplement : ISuperNote
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Faceurl { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public long UserID { get; set; }
        public long ViewCount { get; set; }
        public DateTime AddTime { get; set; }
        public byte ShowLevel { get; set; }
        public long? SystemCategory { get; set; }
        public long? Category { get; set; }
        public byte Type { get; set; }
    }
}