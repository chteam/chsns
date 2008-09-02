namespace CHSNS.Controllers.Admin {
	using System.Linq;
	using System.Collections.Generic;
	using Tools;
	using Models;
	public class UserManage : BaseAdminController {
		public void userset(long userid) {
			Account ac = (from a in DB.Account
						  where a.UserID == userid
						  select a).SingleOrDefault();
			ViewData["user"] = ac;


		}
		public void userlist() {
			//新用户,通过用户
			IList<Account> data = (from a in DB.Account
								   where a.Status > 0
								   orderby a.ID descending
								   select new Account {
									   UserID = a.UserID,
									   Name = a.Name,
									   Status = a.Status,
									   Email = a.Email
								   }).Take(100).ToList();
			//ViewData["data"] = PaginationHelper.CreatePagination(this, data, 6);
			ViewData["data"] = data.AsPagination(1, 6);
		}
	}
}
