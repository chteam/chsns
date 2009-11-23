using System.Net.Mail;
using System.Web.Mvc;

namespace CHSNS.Services
{
	public interface IEmailTemplateService
	{
		MailMessage RenderMessage(ViewContext viewContext);
	}
}