namespace CHSNS.Store{
    public interface IFolder{
        void Delete(string path);
        void Delete(string path,bool f);
        void Create(string path);
        bool Exists(string path);
    }
}