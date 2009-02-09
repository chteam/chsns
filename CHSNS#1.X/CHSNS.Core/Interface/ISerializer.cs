using System;
namespace CHSNS {
    public interface ISerializer {
        void ClearCache(string key);
        T Load<T>(string key) where T : class;
        T Load<T>(string key, bool IsUseCache) where T : class;
        void Save<T>(T obj, string key) where T : class;
    }
}
