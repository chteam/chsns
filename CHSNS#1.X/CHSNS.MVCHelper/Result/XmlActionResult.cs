using System.Web.Mvc;
using System.Xml.Linq;

namespace CHSNS
{
    public class XmlActionResult : ActionResult
    {
        private readonly XDocument document;

        public XmlActionResult(XDocument document)
        {
            this.document = document;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "text/xml";
            document.Save(context.HttpContext.Response.Output, SaveOptions.DisableFormatting);
        }
    }
}
