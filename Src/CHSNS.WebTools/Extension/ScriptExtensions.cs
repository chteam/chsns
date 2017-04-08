using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CHSNS.Helper
{
    public static class ScriptExtensions
    {
        internal static bool IsRelativeToDefaultPath(string file)
        {
            return (((!file.StartsWith("~", StringComparison.Ordinal) && !file.StartsWith("../", StringComparison.Ordinal)) && (!file.StartsWith("/", StringComparison.Ordinal) && !file.StartsWith("http://", StringComparison.OrdinalIgnoreCase))) && !file.StartsWith("https://", StringComparison.OrdinalIgnoreCase));
        }

        public static IHtmlContent Script(this HtmlHelper helper, string releaseFile)
        {
            return helper.Script(releaseFile, releaseFile);
        }

        public static IHtmlContent Script(this HtmlHelper helper, string releaseFile, string debugFile)
        {
            string src;
            if (string.IsNullOrEmpty(releaseFile))
            {
                throw new ArgumentException("releaseFile", "releaseFile");
            }
            if (string.IsNullOrEmpty(debugFile))
            {
                throw new ArgumentException("debugFile","debugFile");
            }
            string file = helper.ViewContext.HttpContext.IsDebuggingEnabled ? debugFile : releaseFile;
            if (IsRelativeToDefaultPath(file))
            {
                src = "~/Scripts/" + file;
            }
            else
            {
                src = file;
            }
            var scriptTag = new TagBuilder("script");
            scriptTag.MergeAttribute("type", "text/javascript");
            scriptTag.MergeAttribute("src", UrlHelper.GenerateContentUrl(src, helper.ViewContext.HttpContext));
            return IHtmlContent.Create(scriptTag.ToString(TagRenderMode.Normal));
        }
    }


}
