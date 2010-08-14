using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CHSNS.Models
{
    [MetadataType(typeof(AccountMeta))]
    public partial class Account
    {
        public class AccountMeta
        {
            [RegularExpression(@"[\w\W]{4,32}")]
            [Required(ErrorMessage = "请填写用户名")]
            [StringLength(50)]
            [Display(Name = "用户名")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "请填写密码")]
            [RegularExpression(@"[\w\W]{4,32}")]
            [StringLength(32)]
            [Display(Name = "密码")]
            public string Password { get; set; }
        }
    }
}
