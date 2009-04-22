namespace CHSNS.Models.Abstractions {
    public interface INote {
        long ID { get; set; }

        string Title { get; set; }

        string Summary { get; set; }

        string Body { get; set; }

        System.DateTime AddTime { get; set; }

        System.DateTime EditTime { get; set; }

        byte Type { get; set; }

        long PID { get; set; }

        long UserID { get; set; }

        byte IsTellMe { get; set; }

        bool? IsAnonymous { get; set; }

        byte ShowLevel { get; set; }

        long ViewCount { get; set; }

        long PushCount { get; set; }

        long TrackBackCount { get; set; }

        long CommentCount { get; set; }

        long LastCommentUserID { get; set; }

        System.DateTime LastCommentTime { get; set; }

        string Ext { get; set; }

    }
}