namespace CHSNS.Abstractions {
    public interface INote {
        long Id { get; set; }

        string Title { get; set; }

        string Summary { get; set; }

        string Body { get; set; }

        System.DateTime AddTime { get; set; }

        System.DateTime EditTime { get; set; }

        byte Type { get; set; }

        long ParentId { get; set; }

        long UserId { get; set; }

        byte IsTellMe { get; set; }

        bool? IsAnonymous { get; set; }

        byte ShowLevel { get; set; }

        long ViewCount { get; set; }

        long PushCount { get; set; }

        long TrackBackCount { get; set; }

        long CommentCount { get; set; }

        long LastCommentUserId { get; set; }

        System.DateTime LastCommentTime { get; set; }

        string Ext { get; set; }

    }
}