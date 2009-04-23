using CHSNS.Store;

namespace CHSNS {


    /// <summary>
    /// 
    /// </summary>
    public class IOFactory : IIOFactory{
        IContext Context { get; set; }

        public IOFactory(IContext context){
            Context = context;
        }
        private IStoreFile _storeFile;
        public IStoreFile StoreFile {
            get {
                if (_storeFile == null)
                    _storeFile = new LocalImplement.LocalStoreFile(Context);
                return _storeFile;
            }
        }
        private IFolder _folder;
        public IFolder Folder {
            get {
                if (_folder == null)
                    _folder = new LocalImplement.LocalFolder(Context);
                return _folder;
            }
        }
    }
}