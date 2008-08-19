using System;using ChAlumna;
namespace Chsword.Web.UI {
	/// <summary>
	/// 用户页面(MyPage)的基类
	/// </summary>
	public class Default : Chsword.Web.UI.Page {
		protected override void OnInit(EventArgs e) {
			base.OnInit(e);
			SetCssJs(Path.urlFilename);
			Online.Update();
			Online.RemoveOffline();
		}

	}
}
