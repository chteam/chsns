	using System;
	using System.Collections.Generic;namespace CHSNS.Controllers
{

	
	[LoginedFilter]
	public class ProfileController : BaseController
	{
		public void setting() {
			ViewData.Add("tabs", this.QueryNum("tabs"));
		}
		public void edit() {
			int i = 0;
			switch (this.QueryString("mode").ToLower()) {
				case "school":
					i = 1;
					break;
				case "contact":
					i = 2;
					break;
				case "personalinfo":
					i = 3;
					break;
				case "magicbox":
					i = 4;
					break;
				case "upload":
					i = 5;
					break;
				default://basic
					i = 0;
					break;
			}
			ViewData.Add("tabs", i);
		}
	}
}
