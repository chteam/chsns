using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MythBusters.Controllers
{
	
    public class AppController : BaseController
    {
		/// <summary>
		/// 安装时访问的页面
		/// </summary>
		/// <param name="invite_id"></param>
		/// <param name="xn_sig_session_key"></param>
		/// <returns></returns>
		public ActionResult Installed(string invite_id, string xn_sig_session_key, string xn_sig_user)
        {
        	//var db = new DataVisitor();
			var api = GetApi();
			var x=api.Invitations.GetOsInfo(invite_id);
			var list = new List<long>();
			var inids=x.Select(c => c.InviterUid);
			foreach (var item in inids)
			{
				long t;
				if (long.TryParse(item, out t))
					list.Add(t);
			}
			//if (list.Count > 0)
			//	db.AddInvite(list.FirstOrDefault());
			return RedirectToAction("index", "home", new
			                                         	{
			                                         		xn_sig_session_key,
			                                         		xn_sig_user
			                                         	});
        }

		public ActionResult UnInstall()
		{
			return Content("");
		}
		public ActionResult Setup()
		{
			return Content("");
		}

    }
}
