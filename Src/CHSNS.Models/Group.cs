namespace CHSNS.Models
{
    using System;

    public class Group
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string LogoUrl { get; set; }

        public virtual DateTime AddTime { get; set; }

        public virtual string Summary { get; set; }

        public virtual long CreaterId { get; set; }

        public virtual long UserCount { get; set; }

        public virtual byte AdminCount { get; set; }

        public virtual long PostCount { get; set; }

        public virtual long ViewCount { get; set; }

        public virtual byte JoinLevel { get; set; }

        public virtual byte ShowLevel { get; set; }

        public virtual byte Status { get; set; }

        public virtual byte Type { get; set; }

        public virtual string Ext { get; set; }
    }
}