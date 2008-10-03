using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mail;

namespace CHSNS.Email {
	public class WebEmail : CHSNS.Email.IEmail {
	 /// <summary>
     /// 发送邮件
     /// </summary>
     /// <param name="to">收件人邮件地址</param>
     /// <param name="from">发件人邮件地址</param>
     /// <param name="subject">邮件主题</param>
     /// <param name="body">邮件内容</param>
     /// <param name="username">登录smtp主机时用到的用户名,注意是邮件地址'@'以前的部分</param>
     /// <param name="password">登录smtp主机时用到的用户密码</param>
     /// <param name="smtpHost">发送邮件用到的smtp主机</param>
     public void Send(string to, string from, string subject, string body, string username, string password, string smtpHost)
     {
         MailMessage mail = new MailMessage();
         mail.To = to;//设置收件人地址
         mail.From = from;//设置发件人地址
         mail.Subject = subject;//设置邮件主题
         mail.BodyFormat = MailFormat.Html;//设置邮件以HTML格式发送
         mail.Body = body;//设置邮件内容
         //设置发送邮件时需要身份验证
         mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
         //设置登录邮件主机时的用户名，注意如果发件人地址是abc@def.com，则用户名是abc而不是abc@def.com
         mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", username);
         //设置登录SMTP主机的用户密码
         mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password);
         //设置发送邮件的SMTP主机
         SmtpMail.SmtpServer = smtpHost;
         //发送邮件，如果发送不成功会抛出异常
         SmtpMail.Send(mail);
     }
	}
}
