namespace CHSNS.Store{
    public interface IStoreFile{
        bool Exists(string filePath);
        void Create(string filePath);
        void WriteLine(string path, string text);
        void Delete(string path);
    }
}