using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Web;
using System.Web.Caching;

namespace CHSNS {
	/// <summary>
	/// 配置文件序列化及反序列化
	/// </summary>
	public class ConfigSerializer {
		static string PATH = "~/Config/{0}.xml";
		static string KEY = "config.{0}";
		/// <summary>
		/// 序列化到配置文件　
		/// </summary>
		/// <typeparam name="T">序列化此类型</typeparam>
		/// <param name="obj">要序列化的对象</param>
		/// <param name="key">键值</param>
		public static void Serializer<T>(T obj, string key) where T : class {
			ConfigSerializer._Serializer<T>(obj, key);
		}
		/// <summary>
		/// 序列化到配置文件　
		/// </summary>
		/// <typeparam name="T">序列化此类型</typeparam>
		/// <param name="obj">要序列化的对象</param>
		/// <param name="key">键值</param>
		static void _Serializer<T>(T obj, string key) where T : class {
			XmlSerializer mySerializer = new XmlSerializer(typeof(T));
			StreamWriter myWriter = new StreamWriter(
				HttpContext.Current.Server.MapPath(string.Format(PATH, key))
				);
			mySerializer.Serialize(myWriter, obj);
			myWriter.Close();
		}
		/// <summary>
		/// 从配置文件反序列化
		/// </summary>
		/// <typeparam name="T">反序列化的目标类型</typeparam>
		/// <param name="key">键</param>
		/// <param name="useCache">是否使用缓存的值</param>
		/// <returns></returns>
		public static T Load<T>(string key, bool useCache) where T : class {
			if (useCache) {
				return Load<T>(key);
			}
			return _Load<T>(key) as T;
		}
		/// <summary>
		/// 从配置文件反序列化
		/// </summary>
		/// <typeparam name="T">反序列化的目标类型</typeparam>
		/// <param name="key">键</param>
		/// <returns></returns>
		public static T Load<T>(string key) where T : class {
			if (!CHCache.Contains(string.Format(KEY, key))) {
				CHCache.Add(string.Format(KEY, key), _Load<T>(key));
			}
			return CHCache.Get<T>(string.Format(KEY, key));
		}
		/// <summary>
		/// 从配置文件反序列化
		/// </summary>
		/// <typeparam name="T">反序列化的目标类型</typeparam>
		/// <param name="key">键</param>
		/// <returns></returns>
		static public object _Load<T>(string key) where T : class {
			XmlSerializer mySerializer = new XmlSerializer(typeof(T));
			FileStream myFileStream = new FileStream(
				HttpContext.Current.Server.MapPath(string.Format(PATH, key))
				, FileMode.Open);
			return mySerializer.Deserialize(myFileStream);
		}
	}
}