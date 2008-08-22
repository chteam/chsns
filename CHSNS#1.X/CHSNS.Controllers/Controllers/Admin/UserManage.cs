	using System;
	using System.Linq;
	using System.Xml.Linq;
	
	using System.Collections;
	using CHSNS.Models;
using CHSNS.Pagination;
using System.Collections.Generic;
	namespace CHSNS.Controllers.Admin
{

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
			IList<Account> data = (from a in DB.Account
						  where a.status > 0
						  orderby a.regtime descending
						  select new Account()
						  {
							 userid= a.userid,
							 name= a.name,
							 status= a.status,
							 email= a.email
						  }).Take(100).ToList<Account>();
			//ViewData["data"] = PaginationHelper.CreatePagination(this, data, 6);
			ViewData["data"] = PaginationHelper.AsPagination<Account>(data, 1, 6);
		}
	}
}
