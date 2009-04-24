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

        public void Save(Stream inputStream, string filename)
        {
            var s = inputStream; //这是你获得的流  
            var buffer = new byte[s.Length];
            s.Read(buffer, 0, buffer.Length); //将流的内容读到缓冲区  
            using (var fs = new FileStream(
                Context.HttpContext.Server.MapPath(filename),
                FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(buffer, 0, buffer.Length);
                fs.Flush();
            }
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