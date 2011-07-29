namespace CHSNS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GroupUser
    {
        [Key]
        [Column(Order=0)]
        public virtual long UserId { get; set; }
        [Key]
        [Column(Order = 1)]
        public virtual long GroupId { get; set; }

        public virtual DateTime AddTime { get; set; }

        public virtual long PostCount { get; set; }

        public virtual byte Status { get; set; }
    }
}