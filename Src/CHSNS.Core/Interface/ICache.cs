
namespace CHSNS.Interface {
    using System;

    public interface ICache {
        void Add(string key, object obj, TimeSpan ts);
        void Add(string key, object obj);
        bool Contains(string key);
        object Get(string key);
        T Get<T>(string key) where T : class;
        void Remove(string key);
        void RemoveAll();
        object this[string key] { get; }

        TimeSpan Timespan { get; set; }
    }
}
