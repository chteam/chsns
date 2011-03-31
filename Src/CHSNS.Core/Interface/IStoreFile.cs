using System.IO;

namespace CHSNS.Store{
    public interface IStoreFile{
        bool Exists(string filePath);
        void Create(string filePath);
        void WriteLine(string path, string text);
        void Delete(string path);
        void Save(Stream inputStream, string fileName);
        void SaveImage(Stream inputStream, string fileName);

    }
}