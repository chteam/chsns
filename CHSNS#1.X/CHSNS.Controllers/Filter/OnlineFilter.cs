using System.Web.Mvc;

namespace CHSNS
{
	public class OnlineFilter : ActionFilterAttribute {
		public override void OnActionExecuting(ActionExecutingContext filterContext) {            
			//if (CHCache.IsNullorEmpty("Application.Showpage")) {
			//    if (!System.IO.File.Exists(CHServer.MapPath("/Chsword.lic"))) {
			//        System.IO.File.Create(CHServer.MapPath("/Chsword.lic"));
			//        CHCache.SetCache("Application.Showpage", false);
			//    } else {
			//        NetworkCross net = new NetworkCross();
			//        string mac = net.GetNetCardMacAddress();
			//        Encrypt en = new Encrypt();
			//        string regwill = en.MD5Encrypt(en.DESEncrypt(mac, "40717407"), 32);
			//        string regstr = File.ReadAllText(CHServer.MapPath("/Chsword.lic"));
			//        if (regwill == regstr)
			//            CHCache.SetCache("Application.Showpage", true);
			//        else
			//            CHCache.SetCache("Application.Showpage", false);
			//    }
			//}
			//if (!Convert.ToBoolean(CHCache.GetCache("Application.Showpage"))) {
			//    context.Response.Write("您的应用程序没有注册请联系CHSNS工作人员进行注册" +
			//        "<a href='http://www.eice.com.cn'>www.eice.com.cn</a>");
			//    return false;
			//}
			Online.Update();
			Online.RemoveOffline();
		}
	}
}