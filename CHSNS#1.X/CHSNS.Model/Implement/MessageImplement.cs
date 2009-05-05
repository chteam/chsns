using System;
using CHSNS.Abstractions;

namespace CHSNS.Model{
    public class MessageImplement : IMessage{
        public long Id { get; set; }
        public long FromId { get; set; }
        public long ToId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime SendTime { get; set; }
        public bool IsSee { get; set; }
        public bool IsFromDel { get; set; }
        public bool IsToDel { get; set; }
        public bool IsHtml { get; set; }
    }
}