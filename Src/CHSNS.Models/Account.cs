namespace CHSNS.Models
{
    using System.ComponentModel.DataAnnotations.Schema;using System.ComponentModel.DataAnnotations;

    public partial class Account{
    

        [Key]
        public virtual long UserId{get;set;}
        [RegularExpression(@"[\w\W]{4,32}")]
        [Required(ErrorMessage = "�û���������д")]
        [StringLength(50)]
        [Display(Name = "�û���")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "���������д")]
        [RegularExpression(@"[\w\W]{4,32}")]
        [StringLength(32)]
        [Display(Name = "����")]
        public string Password { get; set; }
    
        public virtual long? Code{get;set;}
    }
}
