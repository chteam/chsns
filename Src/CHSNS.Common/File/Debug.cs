using System;
using System.Diagnostics;
using System.Web;

namespace CHSNS
{
	/// <summary>
	/// һ����������ٴ���ִ������ķ���
	/// </summary>
	public class Debug {
		static void SaveTextFile(string path, string text)
		{
		   // IOFactory.StoreFile.WriteLine(path, text);
		}
        public static void Info(string text)
        {
            EventLog.WriteEntry("CHSNS", text, EventLogEntryType.Information);
        }
        public static void Warning(string text)
        {
            EventLog.WriteEntry("CHSNS", text, EventLogEntryType.Warning);
        }
        public static void Error(string text)
        {
            EventLog.WriteEntry("CHSNS", text, EventLogEntryType.Error);
        }
        public static void FailureAudit(string text)
        {
            EventLog.WriteEntry("CHSNS", text, EventLogEntryType.FailureAudit);
        }
		/// <summary>
		/// ��¼���ʱ�����ڵĵ�����Ϣ,����/Debug/[��ǰ����].txt���ļ���
		/// </summary>
		/// <param name="info">Ҫ��¼��������Ϣ</param>
		static public void Trace(string info){
			string fn = string.Format("{0}\\Debug\\{1}.txt", HttpContext.Current.Server.MapPath("/"), DateTime.Now.ToString("yyyyMMdd"));
			//SaveTextFile1(fn);
			if (HttpContext.Current.Session["userid"]!=null)
				SaveTextFile(fn, string.Format("{0}\t{2}\t\t{1}\t", DateTime.Now.ToLongTimeString(), info, HttpContext.Current.Session["userid"]));
			else
				SaveTextFile(fn, string.Format("{0}\t{2}IP:{3}\t\t{1}\t", 
				                               DateTime.Now.ToLongTimeString(), info,
				                               HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"],
				                               HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]));
		}
		/// <summary>
		/// ��¼���ʱ�����ڵĵ�����Ϣ,����/Debug/[��ǰ����].txt���ļ���,���ɷ�����Ϣ
		/// </summary>
		/// <param name="info">Ҫ��¼��������Ϣ</param>
		/// <returns>Ҫ��¼����Ϣ��������</returns>
		static public string TraceBack(string info) {
			Trace(info);
			return info;
		}
		//static void SaveTextFile1(string text) {
		//    using (System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\a.txt", true)) { sw.WriteLine(text); }
		//}
	}
}