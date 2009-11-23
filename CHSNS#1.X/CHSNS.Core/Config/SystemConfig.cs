
namespace CHSNS.Config
{
	using System;
	using System.Xml.Serialization;
	//using System.Web;
	using System.IO;
using System.Collections.Generic;

	[Serializable]
	public class SystemConfig
	{
		public SystemConfig() {
			ControllerAssemblies = new List<string>();
		}
		static readonly string FILEPATH = System.Web.HttpContext.Current.Server.MapPath("~/CHSNS.config");
		string _ConnectionString = "";
		/// <summary>
		/// 连接字符串 
		/// </summary>
		public string ConnectionString {
			get { return _ConnectionString; }
			set { _ConnectionString = value; }
		}
		string _DataBaseType = "MsSqlServer";

		public string DataBaseType { 
			get { return _DataBaseType; }
			set { _DataBaseType = value; }
		}

		string _Path = "/";
		/// <summary>
		/// 路径
		/// </summary>
		public string Path {
			get { return _Path; }
			set { _Path = value; }
		}

		public List<string> ControllerAssemblies { get; set; }

		#region 序列化
		/// <summary>
		/// 反序列化
		/// </summary>
		static public SystemConfig Load() {
			if (!File.Exists(FILEPATH)) {
				return new SystemConfig();
			}
			var mySerializer = new XmlSerializer(typeof(SystemConfig));
			SystemConfig s;
			using (Stream stream = new FileStream(FILEPATH, FileMode.Open, FileAccess.Read, FileShare.Read)) {
				s = mySerializer.Deserialize(stream) as SystemConfig;
			}
			return s;
		}
		/// <summary>
		/// 序列化为xml
		/// </summary>
		public void Save() {
			using (Stream stream = new FileStream(FILEPATH, FileMode.Create)) {
				var mySerializer = new XmlSerializer(typeof(SystemConfig));
				mySerializer.Serialize(stream, this);
			}
		}
		public static SystemConfig Currect {
			get {
				return Load();
			}
		}
		#endregion
	}
}