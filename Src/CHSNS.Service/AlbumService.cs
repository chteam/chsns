using System.Collections.Generic;
using CHSNS.Abstractions;
using CHSNS.Operator;
using CHSNS.SQLServerImplement;

namespace CHSNS.Service {
    public class AlbumService {
        static readonly AlbumService Instance = new AlbumService();
        private readonly IAlbumOperator Album;
        public AlbumService() {
            Album = new AlbumOperator();
        }

        public static AlbumService GetInstance() {
            return Instance;
        }

        public List<IAlbum> Items(long uId) {
            return Album.Items(uId);
        }

        public IAlbum Get(long id) {
            return Album.Get(id);
        }

        public void Add(IAlbum album, long uId) {
            Album.Add(album, uId);
        }

        public void Update(IAlbum album) {
            Album.Update(album);
        }
        public List<IPhoto> GetPhotos(long id, long uId, int page, int pageSize) {
            return Album.GetPhotos(id, uId, page, pageSize);
        }
        public IAlbum GetCountChange(long id, int num) {
            return Album.GetCountChange(id, num);
        }
    }
}
