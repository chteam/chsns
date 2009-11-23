using System;

using System.Web.Mvc;
using CHSNS;

namespace CHSNS {

	public class LoginedFilter : ActionFilterAttribute {
		public override void OnActionExecuting(ActionExecutingContext filterContext) {            
			if (!CHUser.IsLogin) {
				throw new Exception("请先<a href='/'>登录</a>，如果您没有账号，请先<a href='/reg/AgreementStep.ashx'>注册</a>");
			}
			if (CHSNSUser.Current.Status < UserStatusType.Field) {
				throw new Exception("您尚未通过邮件验证<a href='/reg/resend.ashx'>重发</a>");
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
