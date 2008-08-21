using System;
using System.Collections;
using System.IO;
using System.Web;

namespace CHSNS {
	/// <summary>
	/// ������ 
	/// AU:�޽�
	/// LE:2007 10 24
	/// </summary>
	public class ChCache {
		static TimeSpan? _timespan=null;
		public static System.Web.Caching.Cache Cache {
			get {
				return HttpContext.Current.Cache;
			}
		}
		#region �������
		/// <summary>
		/// ��⻺���Ƿ���ڡ�
		/// </summary>
		/// <param name="CacheName">��������</param>
		/// <returns>������,��������򷵻�True��</returns>
		static public bool IsNullorEmpty(String CacheName) {
			if (HttpContext.Current.Cache[CacheName] != null)
				return String.IsNullOrEmpty(HttpContext.Current.Cache[CacheName].ToString());
			else
				return true;

		}
		#endregion
	
		#region ��ȡ����
		/// <summary>
		/// ͨ���������Ƶõ�����
		/// </summary>
		/// <param name="CacheName">��������</param>
		/// <returns>Object����</returns>
		static public object GetCache(String CacheName) {
			if(HttpContext.Current.Cache[CacheName]==null)
				return "undefine with Cache name is "+ CacheName;
			return HttpContext.Current.Cache[CacheName];
		}
		#endregion
		
		#region ��ȡ�����ļ� Config ������XML
		/// <summary>
		/// ��ȡXml�����ļ��Ľڵ�����
		/// </summary>
		/// <param name="filename">�����ļ�����</param>
		/// <param name="Name">�ڵ�����</param>
		/// <returns>String,�ڵ����ݵ��ַ���</returns>
		static public String GetConfig(string filename,String Name) {
			return Xml.GetItemText(filename, Name);
		}
		/// <summary>
		/// ��ȡConfig.Xml�����ļ��Ľڵ�����
		/// </summary>
		/// <param name="Name">�ڵ�����</param>
		/// <returns>String,�ڵ����ݵ��ַ���</returns>
		static public String GetConfig(String Name) {
			return GetConfig("Config", Name);
		}
		#endregion

		#region �Ƴ�����
		/// <summary>
		/// ������л���
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
		
		#region ���û���/д�뻺��/���ļ�д�뻺��
		/// <summary>
		/// ��ͬ��Xml�ļ�����Ϊ���档
		/// </summary>
		/// <param name="CacheName">��������/Xml�ļ�����</param>
		/// <returns>Bool,�Ƿ�洢�ɹ���</returns>
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
		/// ���û��棬�����л��治���κβ�������δ��ӵĻ��������ӡ�
		/// </summary>
		/// <param name="CacheName">��������</param>
		/// <param name="CacheValue">�����ֵ</param>
		/// <returns>Bool,�Ƿ�洢�ɹ���</returns>
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
		/// ���û��棬�����û�����Ч��
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
		/// ���ļ�����
		/// </summary>
		/// <param name="fn">�ļ�·��</param>
		/// <param name="CacheName">��������</param>
		/// <returns>Bool,�Ƿ�洢�ɹ���</returns>
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
	
		#region ��ȡģ��
		/// <summary>
		/// ��ȡģ���ļ�
		/// </summary>
		/// <param name="master_name">ģ���ļ���.</param>
		/// <returns>String,ģ���ļ�����.</returns>
		static string GetTemplate(string master_name) {
			String text = Xml.GetItemText("Config", "Style");
			String filePath = HttpContext.Current.Request.MapPath(String.Format("~/Template/{0}/{1}.htm", text, master_name));
			return Regular.ClearRemarks(File.ReadAllText(filePath).Replace("\t", ""));
		}
		/// <summary>
		/// ��ȡģ���ļ�,����֮����
		/// </summary>
		/// <param name="master_name">ģ���ļ���.</param>
		/// <returns>String,ģ���ļ�����.</returns>
		static public string GetTemplateCache(string master_name) {
			//tnameΪģ������
			String CacheName = String.Format("Master.{0}", master_name);
			if (IsNullorEmpty(CacheName)) {
				SetCache(CacheName, GetTemplate(master_name));
			}
			return HttpContext.Current.Cache[CacheName].ToString();
		}
		#endregion


		#region ����
		/// <summary>
		/// ��ȡ�����û���Ĵ洢ʱ��,Ĭ��ֵΪ1��
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
