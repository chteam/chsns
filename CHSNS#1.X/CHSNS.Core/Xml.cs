
namespace CHSNS{
	using System;
	using System.Web;
	using System.Xml;
	/// <summary>
	/// 对成幻Online Judge内置 的Xml操作。
	/// </summary>
	public class Xml {
		/// <summary>
		/// 通过一个item结点的name查找其value属性的内容。
		/// </summary>
		/// <param name="fn">查找的Xml文件。</param>
		/// <param name="name">name属性的值。</param>
		/// <returns>返回value属性的值。</returns>
		static public String GetItemName(String fn, String name) {
			return GetItemText(fn, name);
		}
		/// <summary>
		/// 通过一个item结点的name查找其子元素的内容。
		/// </summary>
		/// <param name="fn">查找的Xml文件。</param>
		/// <param name="name">name属性的值。</param>
		/// <returns>查找其子元素的内容。</returns>
		static public String GetItemText(String fn, String name) {
			if (XmlCacheExists(fn)) {
				String result = GetNode(fn, String.Format("//item[@name=\"{0}\"]", name)).InnerText;
				if (XmlCacheExists(String.Format("{0}.{1}", fn, name), result))
					return result;
			}
			return "";
		}
		/// <summary>
		/// 查找一个XML的子节点。
		/// </summary>
		/// <param name="fn">查找的Xml文件。</param>
		/// <param name="Xpath">Xpath查询表达式。</param>
		/// <returns>返回的符合Xpath的Node。</returns>
		static public System.Xml.XmlNode GetNode(String fn, String Xpath) {
			System.Xml.XmlDocument dom = new System.Xml.XmlDocument();
			dom.LoadXml(HttpContext.Current.Cache[fn].ToString());
			return dom.SelectSingleNode(Xpath);
		}
		/// <summary>
		/// 查看指定缓存是否存在。
		/// </summary>
		/// <param name="CacheName">要检测的缓存名称。</param>
		/// <returns>返回一个Boolean，表示是否存在。</returns>
		static Boolean XmlCacheExists(String CacheName) {
			CHCache cache = new CHCache();
			if (CHCache.IsNullorEmpty(CacheName))
				if (!CHCache.SetCache(CacheName))
					return false;
			return true;
		}
		static Boolean XmlCacheExists(String CacheName, String CacheValue) {
			CHCache cache = new CHCache();
			if (CHCache.IsNullorEmpty(CacheName))
				if (!CHCache.SetCache(CacheName, CacheValue))
					return false;
			return true;
		}

	}
}
