using System;

namespace CHSNS.LocalImplement {
    public class LocalPathGenerate : IPathGenerate {
        public static LocalPathGenerate Intance { get;private set; }
        static LocalPathGenerate() {
            Intance = new LocalPathGenerate();
        }

        public string NewPhoto(long userId, string fileExt) {
            return string.Format("/uploadFiles/{0}/{1}{2}", userId, Guid.NewGuid(), fileExt);
        }

        public string ThumbPhoto(string path, ThumbType thumbType)
        {
            var x = path.LastIndexOf(".");
            return x > 0 ? path.Insert(x - 1, thumbType.ToString()).ToLower() : "";
        }

        public string ThumbUrl(string url, ThumbType thumbType,IContext context)
        {
            return string.IsNullOrEmpty(url) ? "" :
                System.IO.Path.Combine(context.Site.Upload.Domain, ThumbPhoto(url, thumbType));
        }

        public string UploadPath(long userId)
        {
            return string.Format("/uploadFiles/{0}/", userId);
        }
    }
}