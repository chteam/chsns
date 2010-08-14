
namespace CHSNS.Helper {
    using System;
    using System.IO;
    using System.Web;
    using System.Web.UI;
    using System.Web.Mvc;
    using System.Web.Hosting;
    using System.Web.Mvc;
    using CHSNS.Common;

    public static class ImageSpriteHelper
    {
        #region ResolveUrl
        
        private static Control s_helperControl = CreateHelperControl();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "The object is used by the caller and does not go out of scope")]
        private static Control CreateHelperControl()
        {
            var control = new Control();
            control.AppRelativeTemplateSourceDirectory = "~/";
            return control;
        }
        private static string ResolveUrl(string path)
        {
            return s_helperControl.ResolveClientUrl(path);
        }
        #endregion

        /// <summary>
        /// Creates the proper CSS link reference within the target CSHTML page's head section
        /// </summary>
        /// <param name="virtualPath">The relative path of the image to be displayed, or its directory</param>
        public static IHtmlString ImportStylesheet(this HtmlHelper html,string virtualPath) {
            
            var context = html.ViewContext.HttpContext;
            int fileNameLength = Path.GetFileName(virtualPath).Length;
            if (fileNameLength > 0) {
                // Cannot use Path.GetDirectoryName, as it breaks the ~/ prefix of the path
                virtualPath = virtualPath.Remove(virtualPath.Length - fileNameLength);
            }

            string cssFileName = ImageOptimizations.LinkCompatibleCssFile(context.Request.Browser);
            if (cssFileName == null) {
                return null;
            }

            virtualPath = Path.Combine(virtualPath, cssFileName);
            string physicalPath = context.Server.MapPath(virtualPath);

            if (File.Exists(physicalPath)) {
                TagBuilder htmlTag = new TagBuilder("link");
                htmlTag.Attributes["href"] = ResolveUrl(virtualPath);
                htmlTag.Attributes["rel"] = "stylesheet";
                htmlTag.Attributes["type"] = "text/css";
                htmlTag.Attributes["media"] = "all";
                return new HtmlString(htmlTag.ToString(TagRenderMode.SelfClosing));
            }

            return null;
        }

        /// <summary>
        /// Creates a reference to the sprite / inlined version of the desired image
        /// </summary>
        /// <param name="virtualPath">The relative path of the image to be displayed</param>
        public static IHtmlString Image(this HtmlHelper html,string virtualPath) {
            TagBuilder htmlTag = new TagBuilder("img");
            var context = html.ViewContext.HttpContext;
            if (ImageOptimizations.LinkCompatibleCssFile(context.Request.Browser) == null) {
                htmlTag.Attributes["src"] = ResolveUrl(virtualPath);
                return new HtmlString(htmlTag.ToString(TagRenderMode.SelfClosing));
            }

            htmlTag.Attributes["class"] = ImageOptimizations.MakeCssClassName(virtualPath);
            htmlTag.Attributes["src"] = ImageOptimizations.InlinedTransparentGif;
            return new HtmlString(htmlTag.ToString(TagRenderMode.SelfClosing));
        }
    }
}