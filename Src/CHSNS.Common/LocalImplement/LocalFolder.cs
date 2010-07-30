using System;
using System.IO;
using CHSNS.Store;

namespace CHSNS.LocalImplement
{
    public class LocalFolder : IFolder
    {
        readonly string _rootPath;
        public LocalFolder(string rootPath)
        {
            _rootPath = rootPath;
        }
        #region IFolder Members

        public void Delete(string path)
        {
            Directory.Delete(path);
        }

        public void Delete(string path, bool f)
        {
            Directory.Delete(path, f);
        }

        public void Create(string path)
        {
            string serverPath = System.IO.Path.Combine(_rootPath, path.TrimStart("\\/".ToCharArray()));
            Directory.CreateDirectory(serverPath);
        }

        public bool Exists(string path)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}