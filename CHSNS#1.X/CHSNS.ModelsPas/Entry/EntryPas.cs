using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.ModelPas
{
    public class EntryPas
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public DateTime AddTime { get; set; }
        public NameIDPas User { get; set; }
        public string Reason { get; set; }
        public NameIDPas Area { get; set; }
        public int EditCount { get; set; }
        public long ViewCount { get; set; }
        public EntryVersionType Status { get; set; }
    }
}
