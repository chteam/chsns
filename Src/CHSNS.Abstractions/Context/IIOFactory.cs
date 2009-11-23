using CHSNS.Store;

namespace CHSNS{
    public interface IIOFactory {
        IStoreFile StoreFile { get; }
        IFolder Folder { get; }
    }
}