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
        /// ��¼���ʱ�����ڵĵ�����Ϣ,����/Debug/[��ǰ����].txt���ļ���
        /// </summary>
        /// <param name="info">Ҫ��¼��������Ϣ</param>
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
        /// ��¼���ʱ�����ڵĵ�����Ϣ,����/Debug/[��ǰ����].txt���ļ���,���ɷ�����Ϣ
        /// </summary>
        /// <param name="info">Ҫ��¼��������Ϣ</param>
        /// <returns>Ҫ��¼����Ϣ��������</returns>
        public string TraceBack(string info)
        {
            Trace(info);
            return info;
        }
    }
}