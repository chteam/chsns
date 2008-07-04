using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS {
	public class SiteConfig {
		public string Path {
			get {
				return "/";//必以／开始以／结束
			}
		}
		public string Style {
			get {
				return "Default";
			}
		}
		/// <summary>
		/// 预实现为单例
		/// </summary>
		static public SiteConfig Current {
			get {
				return new SiteConfig();

			}
		}
	}
}

