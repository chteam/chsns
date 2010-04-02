using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace CHSNS.Models
{
	[MetadataType(typeof(AccountMeta))]
	public partial class Account
	{
		[DisplayName("account")]
		class AccountMeta
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
