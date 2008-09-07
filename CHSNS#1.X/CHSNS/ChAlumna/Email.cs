namespace CHSNS {
	using System;
	using CHSNS.Models;
	using Chsword;
	using Chsword.Interface;
	using CHSNS.Interface;
	using CHSNS.Config;

	/// <summary>
	/// 基本的发送邮件应用类,使用Chsword
	/// </summary>
	public class Email {
		/// <summary>
		///发送系统邮件
		/// </summary>
		static public void SystemSend(string mail_subject, string mail_body, string mail_Address,string to_name) {

			BaseConfig cs = SiteConfig.Current.BaseConfig;

			//IEmail sm=new SysMailMessage();
			//sm.From = cs.SenderEmail;//"chsword@126.com";
			//sm.MailServerUserName = cs.SmtpUser;//"chsword";
			//sm.MailServerPassWord = cs.SmtpPassword;// "789123";
			//sm.MailDomain = cs.SmtpServer;// "smtp.126.com";
			//sm.MailDomainPort = cs.SmtpPort;//25;
			//sm.FromName = cs.SenderName;// "邹健";
			
			//sm.Subject=mail_subject;//
			//sm.Body=mail_body;

			//sm.isHtml = true;
			//sm.AddRecipient(mail_Address);
			//sm.RecipientName=to_name;
			//sm.Send();
		}
		static public void InviteSend(string mail_subject, string mail_body, string[] mail_Address,string from_name) {
			BaseConfig cs = SiteConfig.Current.BaseConfig;

			//IEmail sm = new SysMailMessage();
			//sm.From = cs.SenderEmail;//"chsword@126.com";
			//sm.MailServerUserName = cs.SmtpUser;//"chsword";
			//sm.MailServerPassWord = cs.SmtpPassword;// "789123";
			//sm.MailDomain = cs.SmtpServer;// "smtp.126.com";
			//sm.MailDomainPort = cs.SmtpPort;//25;

			//sm.FromName=from_name;
			
			//sm.Subject=mail_subject;//
			//sm.Body=mail_body;
			//sm.RecipientName="";
			//sm.isHtml=false;
			//sm.AddRecipient(mail_Address);
			//sm.Send();
		}
 

	}
}
