namespace CHSNS.Operator {
    public interface ICURDOperator<T> {
        void Create(T content);
        void Update(T content);
        void Remove(long uid, params long[] uids);
        PagedList<T> List(long uid, int p, int ep);
    }
}
