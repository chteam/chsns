	using System;
	using System.Collections.Generic;namespace CHSNS.Controllers
{

	
	[LoginedFilter]
	public class ProfileController : BaseController
	{
		public void setting() {
			ViewData.Add("tabs", this.QueryNum("tabs"));
		}
		
	}
}
