namespace CHSNS.Config {
	using System;

	/// <summary>
	/// 网站配置
	/// </summary>
	[Serializable]
	public class SiteConfig {
		public BaseConfig BaseConfig { get; set; }
		public RegVisitConfig RegVisitConfig { get; set; }
		public Publish Publish { get; set; }
		public NoteConfig Note { get; set; }
		/// <summary>
		/// 反序列化
		/// </summary>
		static public SiteConfig Load() {
			return ConfigSerializer.Load<SiteConfig>("Config");
		}
		/// <summary>
		/// Gets the current.
		/// </summary>
		public static SiteConfig Current {
			get {
				return Load();
			}
		}
		/// <summary>
		/// 序列化为xml
		/// </summary>
		public void Save() {
			string fn = "Config";
			ConfigSerializer.Serializer(this, fn);
		}
	}
}
