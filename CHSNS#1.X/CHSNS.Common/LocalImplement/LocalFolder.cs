using System.IO;
using System.Security.AccessControl;
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
            
            System.IO.Directory.CreateDirectory(path);
        }

        public bool Exists(string path) {
            throw new System.NotImplementedException();
        }
    }
}