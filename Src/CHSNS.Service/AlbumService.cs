using System.Collections.Generic;

using CHSNS.Operator;
using CHSNS.SQLServerImplement;
using CHSNS.Models;

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

        public List<Album> Items(long uId) {
            return Album.Items(uId);
        }

        public Album Get(long id) {
            return Album.Get(id);
        }

        public void Add(Album album, long uId) {
            Album.Add(album, uId);
        }

        public void Update(Album album) {
            Album.Update(album);
        }
        public List<Photo> GetPhotos(long id, long uId, int page, int pageSize) {
            return Album.GetPhotos(id, uId, page, pageSize);
        }
        public Album GetCountChange(long id, int num) {
            return Album.GetCountChange(id, num);
        }
    }
}
