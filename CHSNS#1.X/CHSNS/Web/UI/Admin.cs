using System;
using CHSNS;
namespace CHSNS.Web.UI {
	/// <summary>
	/// ����Աҳ��
	/// </summary>
	public class Admin : Chsword.Web.UI.Page {
		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);
			if (CHUser.Status < 199) {
				Response.Redirect("/");
			}
			//SetCssJs("");
		}
	}
}
