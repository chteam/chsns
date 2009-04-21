namespace CHSNS.Models.Abstractions {
    public interface IComment {

        long ID { get; set; }

        long? ShowerID { get; set; }

        long OwnerID { get; set; }

        long SenderID { get; set; }

        System.DateTime AddTime { get; set; }

        string Body { get; set; }

        bool IsReply { get; set; }

        bool IsSee { get; set; }

        bool IsDel { get; set; }

        byte Type { get; set; }

        byte IsTellMe { get; set; }
    }
}