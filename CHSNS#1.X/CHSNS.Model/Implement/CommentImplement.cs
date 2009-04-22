using System;
using CHSNS.Models.Abstractions;

namespace CHSNS.Model{
    public class CommentImplement : IComment{
        public long ID { get; set; }
        public long? ShowerID { get; set; }
        public long OwnerID { get; set; }
        public long SenderID { get; set; }
        public DateTime AddTime { get; set; }
        public string Body { get; set; }
        public bool IsReply { get; set; }
        public bool IsSee { get; set; }
        public bool IsDel { get; set; }
        public byte Type { get; set; }
        public byte IsTellMe { get; set; }
    }
}