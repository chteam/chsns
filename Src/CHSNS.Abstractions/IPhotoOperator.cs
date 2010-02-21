using CHSNS.Models;
namespace CHSNS.Operator {
    public interface IPhotoOperator {
        void Add(Photo photo);
        Photo Get(long id);
        void Delete(long id);
    }
}