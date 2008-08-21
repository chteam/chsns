

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
				context.Flash["msg"] = "����<a href='/'>��¼</a>�������û���˺ţ�����<a href='/reg/AgreementStep.ashx'>ע��</a>";
				context.Response.Redirect("", "home", "Error");
				test(context, controller);
				return false;
			}
			if (ChUser.Current.Status < UserStatusType.Field) {
				context.Flash["msg"] = "����δͨ���ʼ���֤<a href='/reg/resend.ashx'>�ط�</a>";
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
				context.Flash["msg"] = "����Ȩ�޲���,���ܹ�ʹ�ñ�վ�ṩ��Ӧ�ó���";
				context.Response.Redirect("", "Home", "Error");
			}
		}
	}
}
