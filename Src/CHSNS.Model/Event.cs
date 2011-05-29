namespace CHSNS.Models
{
    using System;

    public class Event
    {
        public virtual long Id { get; set; }

        public virtual string TemplateName { get; set; }

        public virtual long OwnerId { get; set; }

        public virtual long? ViewerId { get; set; }

        public virtual DateTime AddTime { get; set; }

        public virtual int ShowLevel { get; set; }

        public virtual string Json { get; set; }
    }
}