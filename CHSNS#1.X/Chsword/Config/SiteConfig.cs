namespace CHSNS.Config
{
	using System;
	//using System.Data;
	using System.Runtime.Serialization;
	using System.IO;
	using System.Web;
	//using Chsword;
	using System.Xml.Serialization;

	using System.Collections.Generic;
	[Serializable]
	public class SiteConfig {
	//	static string fn = SystemConfig.Currect.Path
		
		BaseConfig _BaseConfig;

		public BaseConfig BaseConfig {
			get { return _BaseConfig; }
			set { _BaseConfig = value; }
		}

		public string StylePath {
			get {
				return string.Format("{0}/Style/{1}", BaseConfig.Path, BaseConfig.Style).Replace("//", "/");
			}
		}
		public string Style {
			get
			{
				return BaseConfig.Style;
			}
		}
		public string Path {
			get {
				return "/";//必以／开始以／结束
			}
		}
		RegVisitConfig _RegVisitConfig;

		public RegVisitConfig RegVisitConfig {
			get { return _RegVisitConfig; }
			set { _RegVisitConfig = value; }
		}
		Publish _Publish;

		public Publish Publish {
			get { return _Publish; }
			set { _Publish = value; }
		}
		/// <summary>
		/// 当前网站的连接字符串
		/// </summary>
		static public string SiteConnectionString {
			get {
				if (HttpContext.Current.Application[ConfigString.CONNECTIONSTRING] == null) {
					HttpContext.Current.Application.Lock();
					HttpContext.Current.Application[ConfigString.CONNECTIONSTRING] = SystemConfig.Currect.ConnectionString;
					HttpContext.Current.Application.UnLock();
				}
				return HttpContext.Current.Application[ConfigString.CONNECTIONSTRING].ToString();
			}
		}

		/// <summary>
		/// 反序列化
		/// </summary>
		static public SiteConfig Load() {
			if (HttpContext.Current.Application[ConfigString.SITECONFIG] == null) {
				ConfigPath path = new ConfigPath();
				string fn = path.SiteConfig;
				if (!System.IO.File.Exists(fn)) {
					return new SiteConfig();
				}
				XmlSerializer mySerializer = new XmlSerializer(typeof(SiteConfig));
				using (Stream stream = new FileStream(fn, FileMode.Open, FileAccess.Read, FileShare.Read)) {
					HttpContext.Current.Application.Lock();
					HttpContext.Current.Application[ConfigString.SITECONFIG] = mySerializer.Deserialize(stream);
					HttpContext.Current.Application.UnLock();
				}
			}
			return HttpContext.Current.Application[ConfigString.SITECONFIG] as SiteConfig;
		}
		/// <summary>
		/// 序列化为xml
		/// </summary>
		public void Save() {
			ConfigPath path = new ConfigPath();
			string fn = path.SiteConfig;
			using (Stream stream = new FileStream(fn, FileMode.Create)) {
				XmlSerializer mySerializer = new XmlSerializer(typeof(SiteConfig));
				mySerializer.Serialize(stream, this);
				HttpContext.Current.Application.Lock();
				HttpContext.Current.Application[ConfigString.SITECONFIG] = this;
				HttpContext.Current.Application.UnLock();
			}
		}
		public static SiteConfig Current {
			get {
				return Load();
			}
		}
		public static String SystemUptime {
			get {
				int tickCount = Environment.TickCount;
				if (tickCount < 0) {
					tickCount += 2147483647;
				}
				tickCount /= 1000;
				TimeSpan span = TimeSpan.FromSeconds((double)tickCount);
				return ((((span.Days.ToString() + "d ") + span.Hours.ToString() + "h ") + span.Minutes.ToString() + "m ") + span.Seconds.ToString() + "s");
			}
		}
		

	}
}
