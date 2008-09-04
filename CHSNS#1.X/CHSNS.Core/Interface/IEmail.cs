/*
 * Created by 邹健
 * User: 邹健
 * Date: 2007-10-5
 * Time: 11:06
 */

using System;

namespace CHSNS.Interface
{
	/// <summary>
	/// This is a Inter face of Email sender.邮件发送善类的接口
	/// </summary>
	#region 邮件收发代码接口
	public interface IEmail {

		int MailDomainPort { set;}

		string From { set;get;}

		string FromName { set;get;}

		bool isHtml { set;get;}

		string Subject { set;get;}

		string Body { set;get;}

		string MailDomain { set;}

		string MailServerUserName { set;}

		string MailServerPassWord { set;}

		string RecipientName { set;get;}


		bool AddRecipient(params string[] username);

		bool Send();

	}

	#endregion
}
