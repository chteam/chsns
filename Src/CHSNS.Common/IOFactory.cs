namespace CHSNS
{
    using Interface;

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