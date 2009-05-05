using System;

namespace CHSNS.Model
{
    public class EntryPas
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime AddTime { get; set; }
        public NameIdPas User { get; set; }
        public string Reason { get; set; }
        public NameIdPas Area { get; set; }
        public int EditCount { get; set; }
        public long ViewCount { get; set; }
        public int Status { get; set; }
    }
}
