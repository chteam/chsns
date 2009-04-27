using System.IO;
using CHSNS.Store;

namespace CHSNS.LocalImplement {
    internal class LocalFolder : IFolder {
        IContext Context { get; set; }

        public LocalFolder(IContext context) {
            Context = context;
        }

        public void Delete(string path) {
            Directory.Delete(path);
        }

        public void Delete(string path, bool f) {
            Directory.Delete(path, f);
        }

        public void Create(string path) {
            var serverPath = Context.HttpContext.Server.MapPath(path);
            Directory.CreateDirectory(serverPath);
        }

        public bool Exists(string path) {
            throw new System.NotImplementedException();
        }
    }
}