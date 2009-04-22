namespace CHSNS.Abstractions {
    public interface IMessage {

        long ID { get; set; }

        long FromID { get; set; }

        long ToID { get; set; }

        string Title { get; set; }

        string Body { get; set; }

        System.DateTime SendTime { get; set; }

        bool IsSee { get; set; }

        bool IsFromDel { get; set; }

        bool IsToDel { get; set; }

        bool IsHtml { get; set; }
    }
}