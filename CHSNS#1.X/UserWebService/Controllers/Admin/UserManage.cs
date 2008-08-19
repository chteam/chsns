namespace ChAlumna.Controllers.Admin
{
	using System;
	using System.Linq;
	using System.Xml.Linq;
	using Castle.MonoRail.Framework.Helpers;
	using System.Collections;
	using ChAlumna.Models;
	public class UserManage : BaseAdminController 
	{
		public void userset(long userid) {
			Account ac = (from a in DB.Account
						 where a.userid == userid
						 select a).SingleOrDefault();
			ViewData["user"] = ac;
			

		}
		public void userlist() {
			//新用户,通过用户
			IList data = (from a in DB.Account
						  where a.status > 0
						  orderby a.regtime descending
						  select new
						  {
							  a.userid,
							  a.name,
							  a.status,
							  a.email
						  }).Take(100).ToList();
			ViewData["data"] = PaginationHelper.CreatePagination(this, data, 6);
		}
	}
}
