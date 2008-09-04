using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CHSNS {
	public enum UserStatusType {
		Lock = -1,
		Guest = 0,
		Start = 1,
		Field = 2,
		Basic = 3,
		InfoOver = 5,
		BaseInfo = 6,
		IsApplyToField = 7,
		User = 8,
		Admin = 200,
		Creater = 255
	}
}
