using System;using ChAlumna;
namespace Chsword.Web.UI {
	/// <summary>
	/// �û�ҳ��(MyPage)�Ļ���
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
