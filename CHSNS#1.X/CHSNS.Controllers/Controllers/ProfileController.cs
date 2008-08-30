	using System;
	using System.Collections.Generic;
	using CHSNS.Extension;
	using CHSNS.Filter;

namespace CHSNS.Controllers
{

	
	[LoginedFilter]
	public class ProfileController : BaseController
	{
		public void setting() {
			ViewData.Add("tabs", this.QueryNum("tabs"));
		}
		
	}
}
