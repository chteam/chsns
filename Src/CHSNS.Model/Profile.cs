namespace CHSNS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Profile
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual long UserId { get; set; }

        public virtual byte AccountType { get; set; }

        public virtual string Name { get; set; }

        public virtual string Face { get; set; }

        public virtual long Score { get; set; }

        public virtual long ShowScore { get; set; }

        public virtual long DelScore { get; set; }

        public virtual byte ShowLevel { get; set; }

        public virtual DateTime RegTime { get; set; }

        public virtual DateTime LoginTime { get; set; }

        public virtual long ViewCount { get; set; }

        public virtual long FileSizeAll { get; set; }

        public virtual long FileSizeCount { get; set; }

        public virtual string Applications { get; set; }

        public virtual string Applicationlist { get; set; }

        public virtual byte Status { get; set; }
    }
}