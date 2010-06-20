using System;
using System.Diagnostics;
using System.Web;

namespace CHSNS
{
	/// <summary>
	/// 一组帮助您跟踪代码执行情况的方法
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
		/// 记录设计时环境内的调试消息,存于/Debug/[当前日期].txt的文件内
		/// </summary>
		/// <param name="info">要记录下来的信息</param>
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
		/// 记录设计时环境内的调试消息,存于/Debug/[当前日期].txt的文件内,并可返回信息
		/// </summary>
		/// <param name="info">要记录下来的信息</param>
		/// <returns>要记录的信息不动返回</returns>
		static public string TraceBack(string info) {
			Trace(info);
			return info;
		}
		//static void SaveTextFile1(string text) {
		//    using (System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\a.txt", true)) { sw.WriteLine(text); }
		//}
	}
}