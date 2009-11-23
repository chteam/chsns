using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CHSNS.Models;

namespace CHSNS.Controllers {
	public class ViewController : BaseController {
		//有可能未登录用户查看
		public ActionResult ShowViewList(byte type,int everyrow,long ownerid,int count) {
			ViewListPas vl = new ViewListPas() {
				EveryRow = everyrow,
				Rows = DataBaseExecutor.GetRows("ViewList"
				, "@viewerid", CHUser.UserID
				, "@ownerid", ownerid
				, "@viewclass", type
				, "@count", count)
			};
			return View(vl);
		}
	}
}
