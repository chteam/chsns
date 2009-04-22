namespace CHSNS.Models.Abstractions {
    public interface IReply {

        long ID { get; set; }

        long UserID { get; set; }

        long SenderID { get; set; }

        string Body { get; set; }

        System.DateTime AddTime { get; set; }

        bool IsSee { get; set; }

        bool IsDel { get; set; }

        byte IsTellMe { get; set; }
    }
}