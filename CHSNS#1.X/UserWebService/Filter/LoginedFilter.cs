using System;

using System.Web.Mvc;
using CHSNS;

namespace CHSNS {

	public class LoginedFilter : ActionFilterAttribute {
		public override void OnActionExecuting(ActionExecutingContext filterContext) {            
			if (!CHUser.IsLogin) {
				throw new Exception("����<a href='/'>��¼</a>�������û���˺ţ�����<a href='/reg/AgreementStep.ashx'>ע��</a>");
			}
			if (CHSNSUser.Current.Status < UserStatusType.Field) {
				throw new Exception("����δͨ���ʼ���֤<a href='/reg/resend.ashx'>�ط�</a>");
			}
			//if (filterContext..Name.ToLower() == "message") {
			//    //return true;
			//}
			//if (controller.Name.ToLower() != "profile") {
			//    if (ChUser.Current.Status < UserStatusType.Basic) {

			//        context.Response.Redirect("", "profile", "edit");
			//        test(context, controller);
			//        return false;
			//    }
			//    //if (ChUser.Current.Status < UserStatusType.InfoOver ) {
			//    //    context.Response.Redirect("/EditMyInfo.aspx?tabs=1");
			//    //    return false;
			//    //}
			//    if (SiteConfig.Currect.BaseConfig.IsMustField) {
			//        if (ChUser.Current.Status < UserStatusType.IsApplyToField
			//&& (controller.Name.ToLower() != "group")) {

			//            context.Response.Redirect("", "group", "ClassList");
			//            test(context, controller);
			//            return false;
			//        }

			//    }
			//}

			//return true;
		}
		
	}
}
