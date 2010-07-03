using System;
using System.IO;
using CHSNS.Store;

namespace CHSNS.LocalImplement
{
    internal class LocalFolder : IFolder
    {
        public LocalFolder(IContext context)
        {
            Context = context;
        }

        private IContext Context { get; set; }

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
            string serverPath = Context.HttpContext.Server.MapPath(path);
            Directory.CreateDirectory(serverPath);
        }

        public bool Exists(string path)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}