using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity;
using System.Web.Configuration;
using System.Web;
namespace CHSNS {
	public static class UnitySingleton {
		static string APPSTR = "UnitySingleton.Current";
		/// <summary>
		/// 得到当前应用程序集合
		/// </summary>
		static public IUnityContainer Current{
			get {
				IUnityContainer _container = null;
				if (HttpContext.Current.Application[APPSTR] == null) {
					_container = new UnityContainer();
					UnityConfigurationSection section;
					// 从web.config 配置文件读取unity节点的配置
					object config = WebConfigurationManager.OpenWebConfiguration("/Unity").GetSection("unity");
					section = (UnityConfigurationSection)config;//ConfigurationManager.GetSection("unity");
					// 将读取的配置信息应用到Unity 容器
					section.Containers.Default.Configure(_container);
					HttpContext.Current.Application.Lock();
					HttpContext.Current.Application[APPSTR] = _container;
					HttpContext.Current.Application.UnLock();
				}
				return HttpContext.Current.Application[APPSTR] as IUnityContainer;
			}
		}
	/// <summary>
	/// 当前应用中的系统应用
	/// </summary>
		static public IEnumerable<ISystemApplication> CurrentSystemApplication {
			get {
				return UnitySingleton.Current.ResolveAll<ISystemApplication>();
			}
		}
	/// <summary>
	/// 更新应用
	/// </summary>
		public static void Update(){
			HttpContext.Current.Application[APPSTR] = null;
		}
		/// <summary>
		/// 是否存在如下的系统应用
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static bool SytemHas(string name) {
			return UnitySingleton.CurrentSystemApplication.Any(c => c.ControllerName != name);
		}
	}
}
