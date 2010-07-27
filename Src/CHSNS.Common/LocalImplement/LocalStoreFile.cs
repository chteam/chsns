using System.Drawing;
using System.IO;
using CHSNS.Store;

namespace CHSNS.LocalImplement
{
    public  class LocalStoreFile : IStoreFile
    {
        string _rootPath;
        public LocalStoreFile(string rootPath)
        {
            _rootPath = rootPath;
        }

        public bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }

        public void Create(string filePath)
        {
        }

        public void Save(Stream inputStream, string fileName)
        {
            Stream s = inputStream; //这是你获得的流  
            var buffer = new byte[s.Length];
            s.Read(buffer, 0, buffer.Length); //将流的内容读到缓冲区  
            using (var fs = new FileStream(
            System.IO.Path.Combine(_rootPath, fileName.TrimStart("\\/".ToCharArray())
            ),
                FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(buffer, 0, buffer.Length);
                fs.Flush();
            }
        }

        public void SaveImage(Stream inputStream, string fileName)
        {
            Image img = new Bitmap(inputStream);
            img.Save(System.IO.Path.Combine(_rootPath, fileName.TrimStart("\\/".ToCharArray())));
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
            string pathserver = System.IO.Path.Combine(_rootPath, path.TrimStart("\\/".ToCharArray()));
            File.Delete(pathserver);
        }

    }
}