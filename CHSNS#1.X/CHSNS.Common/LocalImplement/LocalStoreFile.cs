using System.IO;
using CHSNS.Store;

namespace CHSNS.LocalImplement{
    internal class LocalStoreFile : IStoreFile{
                IContext Context { get; set; }

                public LocalStoreFile(IContext context) {
            Context = context;
        }
        #region Implementation of IStoreFile

        public bool Exists(string filePath){
            throw new System.NotImplementedException();
        }

        public void Create(string filePath){
           
        }

        public void WriteLine(string path, string text){
            using (var sw = new StreamWriter(path, true)) {
                sw.WriteLine(text);
            }
        }

        public void Delete(string path){
            var pathserver = Context.HttpContext.Server.MapPath(path);
            File.Delete(pathserver);
        }

        #endregion
    }
}