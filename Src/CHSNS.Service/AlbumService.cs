using System.Collections.Generic;

using CHSNS.Operator;
using CHSNS.SQLServerImplement;
using CHSNS.Models;
using System;

namespace CHSNS.Service {
    public class AlbumService {
        static readonly AlbumService Instance = new AlbumService();
        private readonly AlbumOperator _album;
        public AlbumService() {
            _album = new AlbumOperator();
        }

        public static AlbumService GetInstance() {
            return Instance;
        }

        public List<Album> Items(long uId) {
            return _album.Items(uId);
        }

        public Album Get(long id) {
            return _album.Get(id);
        }

        public void Add(Album album, long uId) {
            album.UserId = uId;
            album.AddTime = DateTime.Now;
            _album.Add(album);
        }

        public void Update(Album album) {
            _album.Update(album);
        }
        public List<Photo> GetPhotos(long id, long uId, int page, int pageSize) {
            return _album.GetPhotos(id, uId, page, pageSize);
        }
        public Album GetCountChange(long id, int num) {
            return _album.GetCountChange(id, num);
        }
    }
}
