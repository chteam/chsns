using System;
using System.Web;

namespace CHSNS
{
	/// <summary>
	/// 一组帮助您跟踪代码执行情况的方法
	/// </summary>
	public class Debug {
		static void SaveTextFile(string path, string text)
		{
			using (var sw = new System.IO.StreamWriter(path, true))
			{
				sw.WriteLine(text);
			}
		}

		/// <summary>
		/// 记录设计时环境内的调试消息,存于/Debug/[当前日期].txt的文件内
		/// </summary>
		/// <param name="info">要记录下来的信息</param>
		static public void Trace(string info){
			string fn = string.Format("{0}\\Debug\\{1}.txt", HttpContext.Current.Server.MapPath("/"), DateTime.Now.ToString("yyyyMMdd"));
			//SaveTextFile1(fn);
			if (HttpContext.Current.Session["userid"]!=null)
				SaveTextFile(fn, string.Format("[{0}][用户:{2}] : {1}", DateTime.Now.ToLongTimeString(), info, HttpContext.Current.Session["userid"]));
			else
				SaveTextFile(fn, string.Format("[{0}][未登录用户:IP{2},代理IP:{3}] : {1}", 
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