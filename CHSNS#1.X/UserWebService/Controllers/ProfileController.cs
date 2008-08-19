namespace ChAlumna.Controllers
{
	using System;
	using System.Collections.Generic;
	using Castle.MonoRail.Framework;
	[Helper(typeof(PersonalHelper))]
	[Filter(ExecuteEnum.BeforeAction, typeof(LoginedFilter))]
	public class ProfileController : BaseController
	{
		public void setting() {
			ViewData.Add("tabs", QueryNum("tabs"));
		}
		public void edit() {
			int i = 0;
			switch (QueryString("mode").ToLower()) {
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
