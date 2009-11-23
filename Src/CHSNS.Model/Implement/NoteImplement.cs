using System;
using CHSNS.Abstractions;

namespace CHSNS.Model{
    public class NoteImplement :INote{
        #region Implementation of INote

        public long Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime EditTime { get; set; }
        public byte Type { get; set; }
        public long ParentId { get; set; }
        public long UserId { get; set; }
        public byte IsTellMe { get; set; }
        public bool? IsAnonymous { get; set; }
        public byte ShowLevel { get; set; }
        public long ViewCount { get; set; }
        public long PushCount { get; set; }
        public long TrackBackCount { get; set; }
        public long CommentCount { get; set; }
        public long LastCommentUserId { get; set; }
        public DateTime LastCommentTime { get; set; }
        public string Ext { get; set; }

        #endregion
    }
}