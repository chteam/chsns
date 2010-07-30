using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CHSNS.Models
{
	[MetadataType(typeof(AccountMeta))]
	public partial class Account
	{
		[DisplayName("account")]
		public class AccountMeta
		{
			[RegularExpression(@"[\w\W]{4,32}")]
			[Required(ErrorMessage="dfsfsdf")]
			[StringLength(50)]
			public string UserName { get; set; }
			[Required]
			[RegularExpression(@"[\w\W]{4,32}")]
			[StringLength(32)]
			public string Password { get; set; }
		}
	}
}
