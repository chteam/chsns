using System;
using CHSNS.Config;

namespace CHSNS {
	public class CHSite {
		public static BaseConfig BaseConfig {
			get {
				return SiteConfig.Current.BaseConfig;
			}
		}
		public static RegVisitConfig RegVisitConfig {
			get {
				return SiteConfig.Current.RegVisitConfig;
			}
		}
		public static Publish Publish {
			get {
				return SiteConfig.Current.Publish;
			}
		}
		/// <summary>
		/// 服务器启动时间
		/// </summary>
		/// <value>The system uptime.</value>
		public static String SystemUptime {
			get {
				int tickCount = Environment.TickCount;
				if (tickCount < 0) {
					tickCount += 2147483647;
				}
				tickCount /= 1000;
				TimeSpan span = TimeSpan.FromSeconds(tickCount);
				return ((((span.Days + "d ") + span.Hours + "h ") + span.Minutes + "m ") + span.Seconds + "s");
			}
		}
	}
}
