using CHSNS.LocalImplement;
using CHSNS.Store;

namespace CHSNS
{
    /// <summary>
    /// 
    /// </summary>
    public class IOFactory
    {
        public static IStoreFile StoreFile { get; private set; }

        public static IFolder Folder { get; private set; }

        public static void Register(IStoreFile file, IFolder folder)
        {
            StoreFile = file;
            Folder = folder;
        }
    }
}