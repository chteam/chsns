namespace CHSNS.Service {
    public interface ICURDService<T> {
        void Create(T content);
        void Update(T content);
        void Remove(params long[] uid);
        PagedList<T> List(long? uid, int p, int ep);
    }
}
