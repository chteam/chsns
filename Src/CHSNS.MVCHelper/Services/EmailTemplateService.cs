using System;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace CHSNS.Services
{
	/// <remarks>
	/// Inspired by Castle's EmailTemplateService.
	/// </remarks>
	public class EmailTemplateService : IEmailTemplateService
	{
		private const string HeaderPattern = @"[ \t]*(?<header>(to|from|cc|bcc|subject|reply-to|X-\w+)):[ \t]*(?<value>(.)+)(\r*\n*)?";

		private static readonly Regex HeaderRegEx = new Regex(HeaderPattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase | RegexOptions.Compiled);

		private readonly IViewEngine _viewEngine;

		public EmailTemplateService(IViewEngine viewEngine)
		{
			if(viewEngine == null) throw new ArgumentNullException("viewEngine");
			_viewEngine = viewEngine;
		}

		#region Message Processing

		public IViewEngine viewEngine
		{
			get { return _viewEngine; }
		}

		private static bool IsLineAHeader(string line, out string header, out string value)
		{
			Match match = HeaderRegEx.Match(line);

			if(match.Success)
			{
				header = match.Groups["header"].ToString();
				value = match.Groups["value"].ToString();
				return true;
			}
			header = value = null;
			return false;
		}

		private static void ProcessHeader(MailMessage message, string header, string value)
		{
			switch(header.ToLowerInvariant())
			{
				case "to":
					message.To.Add(BuildMailAddress(value));
					break;

				case "cc":
					message.CC.Add(BuildMailAddress(value));
					break;

				case "bcc":
					message.Bcc.Add(BuildMailAddress(value));
					break;

				case "subject":
					message.Subject = value;
					break;

				case "from":
					message.From = BuildMailAddress(value);
					break;

				case "reply-to":
					message.ReplyTo = BuildMailAddress(value);
					break;

				default:
					message.Headers[header] = value;
					break;
			}
		}

		private static MailAddress BuildMailAddress(string value)
		{
			int indexOfOpeningParenthesis = value.IndexOf('(');
			if(indexOfOpeningParenthesis < 0)
			{
				return new MailAddress(value);
			}
			int indexOfClosingParenthesis = value.IndexOf(')');
			int length = indexOfClosingParenthesis - indexOfOpeningParenthesis - 1;

			string email = value.Substring(0, indexOfOpeningParenthesis);
			string name = value.Substring(indexOfOpeningParenthesis + 1, length);

			return new MailAddress(email, name);
		}

		private static MailMessage ProcessContentStream(Stream stream, Encoding encoding)
		{
			var message = new MailMessage();

			stream.Position = 0;
			using(var reader = new StreamReader(stream, encoding))
			{
				bool isInBody = false;
				var body = new StringBuilder();
				string line;

				while((line = reader.ReadLine()) != null)
				{
					if(!isInBody && String.IsNullOrEmpty(line))
						continue; //skip blank lines in beginning of message

					string header;
					string value;
					if(!isInBody && IsLineAHeader(line, out header, out value))
					{
						ProcessHeader(message, header, value);
					}
					else
					{
						isInBody = true;
						body.AppendLine(line);
					}
				}

				message.Body = body.ToString();
			}

			if(message.Body.ToLowerInvariant().Contains("<html>"))
				message.IsBodyHtml = true;

			return message;
		}

		#endregion

		public virtual MailMessage RenderMessage(ViewContext viewContext)
		{
			var response = viewContext.HttpContext.Response;

			response.Flush(); //clear out anything that is in there already

			MailMessage message;
			Stream filter = null;

			var oldFilter = response.Filter;
			try
			{
				filter = new MemoryStream();
				response.Filter = filter;

				var view = viewContext.View;
				//= _viewEngine.FindView(viewContext.Controller.ControllerContext, viewContext., null).View;
				view.Render(viewContext, viewContext. HttpContext. Response.Output);

				response.Flush(); //flush content to our filter
				message = ProcessContentStream(filter, response.ContentEncoding);
			}
			finally
			{
				if(filter != null)
					filter.Dispose();

				response.Filter = oldFilter;
			}

			return message;
		}
	}
}