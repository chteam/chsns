namespace CHSNS.Config {
	using System;

	/// <summary>
	/// ��վ����
	/// </summary>
	[Serializable]
	public class SiteConfig {
		public BaseConfig BaseConfig { get; set; }
		public RegVisitConfig RegVisitConfig { get; set; }
		public Publish Publish { get; set; }
		public NoteConfig Note { get; set; }
		/// <summary>
		/// �����л�
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
		/// ���л�Ϊxml
		/// </summary>
		public void Save() {
			string fn = "Config";
			ConfigSerializer.Serializer(this, fn);
		}
	}
}
