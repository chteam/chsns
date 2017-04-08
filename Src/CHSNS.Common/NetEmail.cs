namespace CHSNS.Common.Email
{
    using CHSNS.Interface;

 
    public class NetEmail : IEmail
    {
        #region IEmail Members

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">收件人邮件地址</param>
        /// <param name="from">发件人邮件地址</param>
        /// <param name="subject">邮件主题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="userName">登录smtp主机时用到的用户名,注意是邮件地址'@'以前的部分</param>
        /// <param name="password">登录smtp主机时用到的用户密码</param>
        /// <param name="smtpHost">发送邮件用到的smtp主机</param>
        public void Send(string to, string from, string subject, string body, string userName, string password,
                         string smtpHost)
        {
            throw new System.NotImplementedException();
            /*var f = new MailAddress(from);
            var t = new MailAddress(to);
            var message = new MailMessage(f, t) {Subject = subject, IsBodyHtml = true, Body = body};
            var client = new SmtpClient(smtpHost)
                             {
                                 Credentials = new NetworkCredential(userName, password)
                             };
            //设置发送邮件身份验证方式
            //注意如果发件人地址是abc@def.com，则用户名是abc而不是abc@def.com
            client.Send(message);
            */
        }

        #endregion
    }
}