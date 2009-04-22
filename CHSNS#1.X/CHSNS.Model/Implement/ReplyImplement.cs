using System;
using CHSNS.Models.Abstractions;

namespace CHSNS.Model{
    public class ReplyImplement :IReply{
        public long ID { get; set; }
        public long UserID { get; set; }
        public long SenderID { get; set; }
        public string Body { get; set; }
        public DateTime AddTime { get; set; }
        public bool IsSee { get; set; }
        public bool IsDel { get; set; }
        public byte IsTellMe { get; set; }
    }
}