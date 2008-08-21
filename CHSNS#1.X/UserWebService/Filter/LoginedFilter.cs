

namespace ChAlumna.Controllers {
	using System;
	using Castle.MonoRail.Framework;
	using Castle.MonoRail.Framework.Helpers;
	using ChAlumna.Models;
	using ChAlumna.Config;
	using Castle.MonoRail.Framework.Services;
	public class LoginedFilter : IFilter {
		public bool Perform(ExecuteEnum exec, IRailsEngineContext context, Controller controller) {

			if (!ChSession.isLogined) {
				context.Flash["msg"] = "请先<a href='/'>登录</a>，如果您没有账号，请先<a href='/reg/AgreementStep.ashx'>注册</a>";
				context.Response.Redirect("", "home", "Error");
				test(context, controller);
				return false;
			}
			if (ChUser.Current.Status < UserStatusType.Field) {
				context.Flash["msg"] = "您尚未通过邮件验证<a href='/reg/resend.ashx'>重发</a>";
				context.Response.Redirect("", "Home", "Error");
				return false;
			}
			if (controller.Name.ToLower() == "message") {
				return true;
			}
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

			return true;
		}
		void test(IRailsEngineContext context, Controller controller) {
			if (controller.AreaName == "app") {
				context.Flash["msg"] = "您的权限不足,不能够使用本站提供的应用程序";
				context.Response.Redirect("", "Home", "Error");
			}
		}
	}
}
