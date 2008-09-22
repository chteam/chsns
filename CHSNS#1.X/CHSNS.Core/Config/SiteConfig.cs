namespace CHSNS.Config
{
	using System;

	/// <summary>
	/// 网站配置
	/// </summary>
	[Serializable]
	public class SiteConfig
	{
		public BaseConfig BaseConfig { get; set; }
		public RegVisitConfig RegVisitConfig { get; set; }
		public Publish Publish { get; set; }
		public string StylePath
		{
			get
			{
				return string.Format("{0}/Style/{1}", BaseConfig.Path, BaseConfig.Style).Replace("//", "/");
			}
		}
		public string Style
		{
			get
			{
				return BaseConfig.Style;
			}
		}
		public string Path
		{
			get
			{
				return "/";//必以／开始以／结束
			}
		}

		/// <summary>
		/// 反序列化
		/// </summary>
		static public SiteConfig Load()
		{
			return ConfigSerializer.Load<SiteConfig>("Config");
		}
		/// <summary>
		/// Gets the current.
		/// </summary>
		public static SiteConfig Current
		{
			get
			{
				return Load();
			}
		}
		/// <summary>
		/// 序列化为xml
		/// </summary>
		public void Save()
		{
			string fn = "Config";
			ConfigSerializer.Serializer(this, fn);
		}

		public static String SystemUptime
		{
			get
			{
				int tickCount = Environment.TickCount;
				if (tickCount < 0)
				{
					tickCount += 2147483647;
				}
				tickCount /= 1000;
				TimeSpan span = TimeSpan.FromSeconds((double)tickCount);
				return ((((span.Days.ToString() + "d ") + span.Hours.ToString() + "h ") + span.Minutes.ToString() + "m ") + span.Seconds.ToString() + "s");
			}
		}


	}
}
