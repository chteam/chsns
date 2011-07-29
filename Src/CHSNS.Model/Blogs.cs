namespace CHSNS.Models
{
    using System;

    public class Blogs
    {
        public virtual int Id { get; set; }
        public virtual long UserId { get; set; }

        public virtual DateTime CreateTime { get; set; }

        public virtual string Title { get; set; }

        public virtual string SubTitle { get; set; }

        public virtual string Publish { get; set; }

        public virtual string WriteName { get; set; }

        public virtual string CommentEmail { get; set; }

        public virtual string Skin { get; set; }

        public virtual string Css { get; set; }

        public virtual string MetaKey { get; set; }

        public virtual bool IsWebServices { get; set; }

        public virtual long PostCount { get; set; }

        public virtual long CommentCount { get; set; }

        public virtual long TrackBackCount { get; set; }
    }
}