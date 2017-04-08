namespace CHSNS.Models
{
    using System.ComponentModel.DataAnnotations.Schema;using System.ComponentModel.DataAnnotations;

    public partial class Account{
    

        [Key]
        public virtual long UserId{get;set;}
        [RegularExpression(@"[\w\W]{4,32}")]
        [Required(ErrorMessage = "用户名必须填写")]
        [StringLength(50)]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "密码必须填写")]
        [RegularExpression(@"[\w\W]{4,32}")]
        [StringLength(32)]
        [Display(Name = "密码")]
        public string Password { get; set; }
    
        public virtual long? Code{get;set;}
    }
}
