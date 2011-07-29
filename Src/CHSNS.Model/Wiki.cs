namespace CHSNS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Wiki
    {
        [Key]
        public virtual long Id { get; set; }

        public virtual string Url { get; set; }

        public virtual long CreatorId { get; set; }
    
        public virtual int Status { get; set; }

        public virtual string Ext { get; set; }

        public virtual bool IsTitleDisplay { get; set; }

        public DateTime CreatedTime { get; set; }

        public virtual ICollection<WikiVersion> WikiVersions { get; set; }
    }
}
