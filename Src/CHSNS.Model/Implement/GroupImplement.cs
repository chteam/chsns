using System;
using CHSNS.Abstractions;

namespace CHSNS.Model {
    public class GroupImplement:IGroup {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public DateTime AddTime { get; set; }
        public string Summary { get; set; }
        public long CreaterId { get; set; }
        public long UserCount { get; set; }
        public byte AdminCount { get; set; }
        public long PostCount { get; set; }
        public long ViewCount { get; set; }
        public byte JoinLevel { get; set; }
        public byte ShowLevel { get; set; }
        public byte Status { get; set; }
        public byte Type { get; set; }
        public string Ext { get; set; }
    }
}
