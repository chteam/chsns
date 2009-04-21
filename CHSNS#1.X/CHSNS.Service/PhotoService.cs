using CHSNS.Models.Abstractions;
using CHSNS.Operator;
using CHSNS.SQLServerImplement;

namespace CHSNS.Service {
    public class PhotoService {
                static readonly PhotoService _instance = new PhotoService();
                private readonly IPhotoOperator Photo;
        public PhotoService() {
                    Photo = new PhotoOperator();
        }

        public static PhotoService GetInstance(){
            return _instance;
        }
        public void Add(IPhoto photo) {
            Photo.Add(photo);
        }

        public IPhoto Get(long id) {
            return Photo.Get(id);
        }

        public void Delete(long id) {
            Photo.Delete(id);
        }
    }
}
