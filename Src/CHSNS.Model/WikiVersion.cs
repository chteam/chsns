namespace CHSNS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class WikiVersion
    {
        public virtual long Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Reason { get; set; }
        public virtual DateTime AddTime { get; set; }
        public virtual string Description { get; set; }
        public virtual string Reference { get; set; }
        public virtual long UserId { get; set; }
        public virtual int Status { get; set; }

        [ForeignKey("Wiki")]
        public virtual long WikiId { get; set; }

        public virtual Wiki Wiki { get; set; }
        public virtual string Ext { get; set; }
    }
}