/*
 * Created by 邹健
 * Date: 2007-10-19
 * Time: 22:51
 * 
 * 
 */
namespace ChAlumna {

	using System;
	using System.Runtime.CompilerServices;
	using System.Web;
	using System.Web.Profile;
	
	using ChAlumna.Models;
	using Chsword;
	using Castle.MonoRail.Framework.Configuration;
	using ChAlumna.Config;
	using System.IO;
	using System.Xml.Serialization;
	using ChAlumna.Controllers;
	//using ChAlumna.Controllers.Ajax;

	[CompilerGlobalScope]
	public class Global : HttpApplication {
		private bool __initialized;

		public Global() {
			if (!__initialized) {
				__initialized = true;
			}
		}

		public void Application_Start(object sender, EventArgs e) {
			// 在应用程序启动时运行的代码
			//Application.Add("Application.IsMustJoinClass", true);
			//网站设置，是否必须加入班级
			SystemConfig system = SystemConfig.Currect;

			ConfigPath path = new ConfigPath();
			//Routing
			MonoRailConfiguration.GetConfig().RoutingRules.Deserialize(
				Xml.CreateXmlDocument(path.Routing)
			);
			MonoRailConfiguration.GetConfig()
				.ControllersConfig.Assemblies = system.ControllerAssemblies.ToArray();

		}

		public void Application_End(object sender, EventArgs e) {
		}

		public void Application_Error(object sender, EventArgs e) {
		}

		public void Session_OnStart(object sender, EventArgs e) {
			if (!ChSession.isLogined) {	//当前不处于登录状态
				if (ChCookies.IsExists && ChCookies.IsAutoLogin) {
					try {
						string pwd = ChCookies.UserPassword;
						Identity identity = new Identity();
						identity.Login(ChCookies.Userid.ToString(),
							pwd,
							true,
							false
							);
					} catch{}
				} 
			}
		}

		public void Session_OnEnd(object sender, EventArgs e) { }
	}
}
