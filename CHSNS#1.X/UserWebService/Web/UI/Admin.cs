using System;
using ChAlumna;
namespace ChAlumna.Web.UI {
	/// <summary>
	/// ����Աҳ��
	/// </summary>
	public class Admin : Chsword.Web.UI.Page {
		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);
			if (ChSession.Status < 199) {
				Response.Redirect("/");
			}
			//SetCssJs("");
		}
	}
}
