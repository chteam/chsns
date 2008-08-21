

namespace ChAlumna.Controllers {
	using System;
	using Castle.MonoRail.Framework;
	using Chsword;
	public class OnlineFilter : IFilter {
		public bool Perform(ExecuteEnum exec, IRailsEngineContext context, Controller controller) {
			//if (ChCache.IsNullorEmpty("Application.Showpage")) {
			//    if (!System.IO.File.Exists(ChServer.MapPath("/Chsword.lic"))) {
			//        System.IO.File.Create(ChServer.MapPath("/Chsword.lic"));
			//        ChCache.SetCache("Application.Showpage", false);
			//    } else {
			//        NetworkCross net = new NetworkCross();
			//        string mac = net.GetNetCardMacAddress();
			//        Encrypt en = new Encrypt();
			//        string regwill = en.MD5Encrypt(en.DESEncrypt(mac, "40717407"), 32);
			//        string regstr = File.ReadAllText(ChServer.MapPath("/Chsword.lic"));
			//        if (regwill == regstr)
			//            ChCache.SetCache("Application.Showpage", true);
			//        else
			//            ChCache.SetCache("Application.Showpage", false);
			//    }
			//}
			//if (!Convert.ToBoolean(ChCache.GetCache("Application.Showpage"))) {
			//    context.Response.Write("您的应用程序没有注册请联系CHSNS工作人员进行注册" +
			//        "<a href='http://www.eice.com.cn'>www.eice.com.cn</a>");
			//    return false;

			//}

			Online.Update();
			Online.RemoveOffline();
			return true;
		}
	}
}
