namespace CHSNS.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ContactInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual long UserId { get; set; }

        public virtual string Address { get; set; }

        public virtual string QQ { get; set; }

        public virtual string Msn { get; set; }

        public virtual string WangWang { get; set; }

        public virtual string NeteasePop { get; set; }

        public virtual string UC { get; set; }

        public virtual string Telphone { get; set; }

        public virtual string Mobiephone { get; set; }

        public virtual string WebSite { get; set; }

        public virtual byte TellMethod { get; set; }

        public virtual byte ShowLevel { get; set; }
    }
}