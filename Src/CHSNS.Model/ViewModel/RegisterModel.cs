
namespace CHSNS.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterModel : Account
    {
        [Required(ErrorMessage="确认密码必须填写")]
        [RegularExpression(@"[\w\W]{4,32}")]
        [StringLength(32)]
        [Display(Name = "确认密码")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "昵称必须填写")]
        [RegularExpression(@"[\w\W]{4,32}")]
        [StringLength(50)]
        [Display(Name = "昵称")]
        public string Nickname { get; set; }

        public Account ToAccount() {
            return new Account { Password = Password, UserName = UserName };
        }
    }
}
