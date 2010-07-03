using System.Drawing;
using System.IO;
using CHSNS.Store;

namespace CHSNS.LocalImplement
{
    internal class LocalStoreFile : IStoreFile
    {
        public LocalStoreFile(IContext context)
        {
            Context = context;
        }

        #region Implementation of IStoreFile

        public bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }

        public void Create(string filePath)
        {
        }

        public void Save(Stream inputStream, string fileName)
        {
            Stream s = inputStream; //�������õ���  
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

        public void WriteLine(string path, string text)
        {
            using (var sw = new StreamWriter(path, true))
            {
                sw.WriteLine(text);
            }
        }


        public void Delete(string path)
        {
            string pathserver = Context.HttpContext.Server.MapPath(path);
            File.Delete(pathserver);
        }

        #endregion

        private IContext Context { get; set; }
    }
}