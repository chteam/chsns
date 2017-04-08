namespace CHSNS.Result
{
    using Microsoft.AspNetCore.Mvc;
    using System.Xml.Linq;

    public class XmlActionResult : ActionResult
    {
        private readonly XDocument _document;

        public XmlActionResult(XDocument document)
        {
            this._document = document;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "text/xml";
            _document.Save(context.HttpContext.Response.Output, SaveOptions.DisableFormatting);
        }
    }
}
