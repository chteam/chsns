using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace CHSNS.Email {
	/// <summary>
	/// .net 2.0邮件发送方式
	/// </summary>
	public class NetEmail:IEmail {
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
		public void Send(string to, string from, string subject, string body, string userName, string password, string smtpHost) {
			MailAddress f = new MailAddress(from);
			MailAddress t = new MailAddress(to);
			MailMessage message = new MailMessage(f, t);
			message.Subject = subject;//设置邮件主题
			message.IsBodyHtml = true;//设置邮件正文为html格式
			message.Body = body;//设置邮件内容
			SmtpClient client = new SmtpClient(smtpHost);
			//设置发送邮件身份验证方式
			//注意如果发件人地址是abc@def.com，则用户名是abc而不是abc@def.com
			client.Credentials = new NetworkCredential(userName, password);
			client.Send(message);
		}
	}
}
