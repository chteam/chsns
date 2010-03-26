using System;
using System.Drawing;
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

        public void Save(Stream inputStream, string fileName)
        {
            var s = inputStream; //�������õ���  
            var buffer = new byte[s.Length];
            s.Read(buffer, 0, buffer.Length); //���������ݶ���������  
            using (var fs = new FileStream(
                Context.HttpContext.Server.MapPath(fileName),
                FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(buffer, 0, buffer.Length);
                fs.Flush();
            }
        }

        public void SaveImage(Stream inputStream, string fileName)
        {
            Image img = new Bitmap(inputStream);
            img.Save(Context.HttpContext.Server.MapPath(fileName));
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