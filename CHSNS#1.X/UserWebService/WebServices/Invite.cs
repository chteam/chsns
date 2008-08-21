/*
 * Created by 邹健
 * Date: 2007-10-9
 * Time: 18:24
 * 
 * 
 */
using System;
using System.ComponentModel;
using System.Web.Services;
using CHSNS;
using CHSNS.Config;
namespace Chsword
{
	/// <summary>
	/// Description of Invite
	/// </summary>
	[WebService
 	 (	Name = "Invite",
  		Description = "Invite",
  		Namespace = "http://www.Invite.example"
 	 )
	]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService()]
	public class Invite : WebServices
	{
		public Invite()
		{
		}
		
		[WebMethod(EnableSession=true)]
		public bool SendInviteMail(string mail_address,string Customstr)
		{
			if(Session["userid"]==null){
				return false;
			}
			mail_address=Regular.FormatJoin(mail_address);
			String[] mails=mail_address.Split(',');
			Email.InviteSend(
				string.Format("{0}邀请您加入",Session["username"].ToString()),
				string.Format(ChCache.GetConfig("Email","invite"),
				              Session["username"].ToString(),
				              Customstr,
							  SiteConfig.Current.BaseConfig.Url
							  ,SiteConfig.Current.BaseConfig.Title),
				mails,Session["username"].ToString());
			return true;
		}
	}
}
