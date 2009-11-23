using System;
using CHSNS.Abstractions;

namespace CHSNS.Model{
    public class EventImplement :IEvent{
        public long ID { get; set; }
        public string TemplateName { get; set; }
        public long OwnerID { get; set; }
        public long? ViewerID { get; set; }
        public DateTime AddTime { get; set; }
        public int ShowLevel { get; set; }
        public string Json { get; set; }
    }
}