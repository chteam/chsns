namespace CHSNS.Common
{
    using System;
    using System.Diagnostics;
    public class SystemLogger
    {
        public SystemLogger(HttpContextBase httpContext,IContext context)
        {
            HttpContext = httpContext;
        }

        public HttpContextBase HttpContext { get; private set; }
        public IContext Context { get; set; }

        public void Info(string text)
        {
            EventLog.WriteEntry("CHSNS", text, EventLogEntryType.Information);
        }

        public void Warning(string text)
        {
            EventLog.WriteEntry("CHSNS", text, EventLogEntryType.Warning);
        }

        public void Error(string text)
        {
            EventLog.WriteEntry("CHSNS", text, EventLogEntryType.Error);
        }

        public void FailureAudit(string text)
        {
            EventLog.WriteEntry("CHSNS", text, EventLogEntryType.FailureAudit);
        }

        /// <summary>
        /// 记录设计时环境内的调试消息,存于/Debug/[当前日期].txt的文件内
        /// </summary>
        /// <param name="info">要记录下来的信息</param>
        public void Trace(string info)
        {
            if (Context.User != null)
                Info(string.Format("{0}\t{2}\t\t{1}\t", DateTime.Now.ToLongTimeString(), info,
                                   Context.User.UserId));
            else
                Info(string.Format("{0}\t{2}IP:{3}\t\t{1}\t",
                                   DateTime.Now.ToLongTimeString(), info,
                                   HttpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"],
                                   HttpContext.Request.ServerVariables["REMOTE_ADDR"]));
        }

        /// <summary>
        /// 记录设计时环境内的调试消息,存于/Debug/[当前日期].txt的文件内,并可返回信息
        /// </summary>
        /// <param name="info">要记录下来的信息</param>
        /// <returns>要记录的信息不动返回</returns>
        public string TraceBack(string info)
        {
            Trace(info);
            return info;
        }
    }
}