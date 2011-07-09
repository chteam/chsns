namespace CHSNS.Common.LocalImplement
{
    using System.ComponentModel.Composition;
    using System.Drawing;
    using System.IO;
    using CHSNS.Interface;

    [Export]
    public class LocalStoreFile : IStoreFile
    {
        private readonly string _rootPath;

        public LocalStoreFile(string rootPath)
        {
            _rootPath = rootPath;
        }

        #region IStoreFile Members

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
                Path.Combine(_rootPath, fileName.TrimStart("\\/".ToCharArray())
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
            img.Save(Path.Combine(_rootPath, fileName.TrimStart("\\/".ToCharArray())));
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
            string pathserver = Path.Combine(_rootPath, path.TrimStart("\\/".ToCharArray()));
            File.Delete(pathserver);
        }

        #endregion
    }
}