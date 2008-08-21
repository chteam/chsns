using System;
using System.Collections;
using System.IO;
using System.Web;

namespace CHSNS {
	/// <summary>
	/// 缓存类 
	/// AU:邹健
	/// LE:2007 10 24
	/// </summary>
	public class ChCache {
		static TimeSpan? _timespan=null;
		public static System.Web.Caching.Cache Cache {
			get {
				return HttpContext.Current.Cache;
			}
		}
		#region 缓存过期
		/// <summary>
		/// 检测缓存是否过期。
		/// </summary>
		/// <param name="CacheName">缓存名称</param>
		/// <returns>布尔型,缓存存在则返回True。</returns>
		static public bool IsNullorEmpty(String CacheName) {
			if (HttpContext.Current.Cache[CacheName] != null)
				return String.IsNullOrEmpty(HttpContext.Current.Cache[CacheName].ToString());
			else
				return true;

		}
		#endregion
	
		#region 获取缓存
		/// <summary>
		/// 通过缓存名称得到缓存
		/// </summary>
		/// <param name="CacheName">缓存名称</param>
		/// <returns>Object类型</returns>
		static public object GetCache(String CacheName) {
			if(HttpContext.Current.Cache[CacheName]==null)
				return "undefine with Cache name is "+ CacheName;
			return HttpContext.Current.Cache[CacheName];
		}
		#endregion
		
		#region 获取配置文件 Config 或其它XML
		/// <summary>
		/// 获取Xml配置文件的节点内容
		/// </summary>
		/// <param name="filename">配置文件名称</param>
		/// <param name="Name">节点名称</param>
		/// <returns>String,节点内容的字符串</returns>
		static public String GetConfig(string filename,String Name) {
			return Xml.GetItemText(filename, Name);
		}
		/// <summary>
		/// 获取Config.Xml配置文件的节点内容
		/// </summary>
		/// <param name="Name">节点名称</param>
		/// <returns>String,节点内容的字符串</returns>
		static public String GetConfig(String Name) {
			return GetConfig("Config", Name);
		}
		#endregion

		#region 移除缓存
		/// <summary>
		/// 清除所有缓存
		/// </summary>
		static public void RemoveAll() {
			foreach (DictionaryEntry de in Cache)
			{
				Cache.Remove(de.Key.ToString());
			}
		}
		static public void Remove(string key) {
			Cache.Remove(key);
		}
		#endregion
		
		#region 设置缓存/写入缓存/将文件写入缓存
		/// <summary>
		/// 将同名Xml文件设置为缓存。
		/// </summary>
		/// <param name="CacheName">缓存名称/Xml文件名称</param>
		/// <returns>Bool,是否存储成功。</returns>
		static public Boolean SetCache(String CacheName){
			try {
				String fn = HttpContext.Current.Request.MapPath(String.Format("~/Config/{0}.config", CacheName));
				return SetCache(CacheName,File.ReadAllText(fn));
			}
			catch {
				return false;
			}
		}
		/// <summary>
		/// 设置缓存，对已有缓存不做任何操作，对未添加的缓存进行添加。
		/// </summary>
		/// <param name="CacheName">缓存名称</param>
		/// <param name="CacheValue">缓存的值</param>
		/// <returns>Bool,是否存储成功。</returns>
		static public Boolean SetCache(String CacheName,Object CacheValue) {
			try {
				if (!IsNullorEmpty(CacheName))
					return true;
				else {//
					HttpContext.Current.Cache.Add(CacheName, CacheValue, null, DateTime.MaxValue, Timespan, System.Web.Caching.CacheItemPriority.Normal, null);
					return true;
				}
			}
			catch {
				return false;
			}
		}
		/// <summary>
		/// 设置缓存，并设置缓存有效期
		/// </summary>
		/// <param name="CacheName"></param>
		/// <param name="CacheValue"></param>
		/// <param name="ts"></param>
		/// <returns></returns>
		static public Boolean SetCache(String CacheName, Object CacheValue,TimeSpan ts) {
			try {
				if (IsNullorEmpty(CacheName)){//
					HttpContext.Current.Cache.Add(CacheName, CacheValue, null, DateTime.MaxValue, ts, System.Web.Caching.CacheItemPriority.Normal, null);
				}
				return true;
			} catch {
				return false;
			}
		}
		/// <summary>
		/// 将文件缓存
		/// </summary>
		/// <param name="fn">文件路径</param>
		/// <param name="CacheName">缓存名称</param>
		/// <returns>Bool,是否存储成功。</returns>
		static public Boolean SetFileCache(String fn,String CacheName)
		{
			try
			{
				return SetCache(CacheName, File.ReadAllText(fn));
			}
			catch
			{
				return false;
			}
		}
		#endregion
	
		#region 获取模板
		/// <summary>
		/// 读取模板文件
		/// </summary>
		/// <param name="master_name">模板文件名.</param>
		/// <returns>String,模板文件内容.</returns>
		static string GetTemplate(string master_name) {
			String text = Xml.GetItemText("Config", "Style");
			String filePath = HttpContext.Current.Request.MapPath(String.Format("~/Template/{0}/{1}.htm", text, master_name));
			return Regular.ClearRemarks(File.ReadAllText(filePath).Replace("\t", ""));
		}
		/// <summary>
		/// 读取模板文件,并将之缓存
		/// </summary>
		/// <param name="master_name">模板文件名.</param>
		/// <returns>String,模板文件内容.</returns>
		static public string GetTemplateCache(string master_name) {
			//tname为模板名称
			String CacheName = String.Format("Master.{0}", master_name);
			if (IsNullorEmpty(CacheName)) {
				SetCache(CacheName, GetTemplate(master_name));
			}
			return HttpContext.Current.Cache[CacheName].ToString();
		}
		#endregion


		#region 属性
		/// <summary>
		/// 获取或设置缓存的存储时间,默认值为1天
		/// </summary>
		static public TimeSpan Timespan {
			get {
				if(_timespan==null){
					return new TimeSpan(1, 0, 0, 0, 0);
				}else
					return _timespan.Value; }
			set { _timespan = value; }
		}


#endregion

	}
}
