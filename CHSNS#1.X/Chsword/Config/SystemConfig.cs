
namespace CHSNS.Config
{
	using System;
	using System.Xml.Serialization;
	//using System.Web;
	using System.IO;
using System.Collections.Generic;
	using System.Collections;
	[Serializable]
	public class SystemConfig
	{
		public SystemConfig() {
			_ControllerAssemblies = new List<string>();
		}
		static readonly string FILEPATH = System.Web.HttpContext.Current.Server.MapPath("~/ChAlumna.config");
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
		List<string> _ControllerAssemblies;

		public List<string> ControllerAssemblies {
			get { return _ControllerAssemblies; }
			set { _ControllerAssemblies = value; }
		}



		#region 序列化
		/// <summary>
		/// 反序列化
		/// </summary>
		static public SystemConfig Load() {
			if (!System.IO.File.Exists(FILEPATH)) {
				return new SystemConfig();
			}
			XmlSerializer mySerializer = new XmlSerializer(typeof(SystemConfig));
			SystemConfig s = new SystemConfig();
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
				XmlSerializer mySerializer = new XmlSerializer(typeof(SystemConfig));
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