using System;

namespace CHSNS.LocalImplement{
    public class LocalPathGenerate : IPathGenerate{
        public string NewPhoto(long userId, string fileExt){
            return string.Format("/uploadFiles/{0}/{1}.{2}", userId, Guid.NewGuid(), fileExt);
        }
    }
}