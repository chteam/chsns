
namespace CHSNS{
	using System;
	using System.Web;
	using System.Xml;
	/// <summary>
	/// �Գɻ�Online Judge���� ��Xml������
	/// </summary>
	public class Xml {
		/// <summary>
		/// ͨ��һ��item����name������value���Ե����ݡ�
		/// </summary>
		/// <param name="fn">���ҵ�Xml�ļ���</param>
		/// <param name="name">name���Ե�ֵ��</param>
		/// <returns>����value���Ե�ֵ��</returns>
		static public String GetItemName(String fn, String name) {
			return GetItemText(fn, name);
		}
		/// <summary>
		/// ͨ��һ��item����name��������Ԫ�ص����ݡ�
		/// </summary>
		/// <param name="fn">���ҵ�Xml�ļ���</param>
		/// <param name="name">name���Ե�ֵ��</param>
		/// <returns>��������Ԫ�ص����ݡ�</returns>
		static public String GetItemText(String fn, String name) {
			if (XmlCacheExists(fn)) {
				String result = GetNode(fn, String.Format("//item[@name=\"{0}\"]", name)).InnerText;
				if (XmlCacheExists(String.Format("{0}.{1}", fn, name), result))
					return result;
			}
			return "";
		}
		/// <summary>
		/// ����һ��XML���ӽڵ㡣
		/// </summary>
		/// <param name="fn">���ҵ�Xml�ļ���</param>
		/// <param name="Xpath">Xpath��ѯ���ʽ��</param>
		/// <returns>���صķ���Xpath��Node��</returns>
		static public System.Xml.XmlNode GetNode(String fn, String Xpath) {
			System.Xml.XmlDocument dom = new System.Xml.XmlDocument();
			dom.LoadXml(HttpContext.Current.Cache[fn].ToString());
			return dom.SelectSingleNode(Xpath);
		}
		/// <summary>
		/// �鿴ָ�������Ƿ���ڡ�
		/// </summary>
		/// <param name="CacheName">Ҫ���Ļ������ơ�</param>
		/// <returns>����һ��Boolean����ʾ�Ƿ���ڡ�</returns>
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
