using System;
using CHSNS.Models.Abstractions;

namespace CHSNS.Model{
    public class MessageImplement : IMessage{
        public long ID { get; set; }
        public long FromID { get; set; }
        public long ToID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime SendTime { get; set; }
        public bool IsSee { get; set; }
        public bool IsFromDel { get; set; }
        public bool IsToDel { get; set; }
        public bool IsHtml { get; set; }
    }
}