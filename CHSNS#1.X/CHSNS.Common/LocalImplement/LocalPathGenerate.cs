using System;

namespace CHSNS.LocalImplement {
    public class LocalPathGenerate : IPathGenerate {
        public static LocalPathGenerate Intance { get;private set; }
        static LocalPathGenerate() {
            Intance = new LocalPathGenerate();
        }

        public string NewPhoto(long userId, string fileExt) {
            return string.Format("/uploadFiles/{0}/{1}.{2}", userId, Guid.NewGuid(), fileExt);
        }

        public string ThumbPhoto(string path, ThumbType thumbType)
        {
            var x = path.LastIndexOf(".");
            return path.Insert(x - 1, thumbType.ToString()).ToLower();
        }

        public string UploadPath(long userId)
        {
            return string.Format("/uploadFiles/{0}/", userId);
        }
    }
}