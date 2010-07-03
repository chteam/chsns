using CHSNS.LocalImplement;
using CHSNS.Store;

namespace CHSNS
{
    /// <summary>
    /// 
    /// </summary>
    public class IOFactory : IIOFactory
    {
        private IFolder _folder;
        private IStoreFile _storeFile;

        public IOFactory(IContext context)
        {
            Context = context;
        }

        private IContext Context { get; set; }

        #region IIOFactory Members

        public IStoreFile StoreFile
        {
            get { return _storeFile ?? (_storeFile = new LocalStoreFile(Context)); }
        }

        public IFolder Folder
        {
            get { return _folder ?? (_folder = new LocalFolder(Context)); }
        }

        #endregion
    }
}