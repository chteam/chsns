
namespace CHSNS.Service {
    using System.Collections.Generic;
    using System.Linq;
    using CHSNS.Models;
    using System;
    using System.ComponentModel.Composition;
    [Export]
    public class AlbumService : BaseService
    {
        public List<Album> Items(long uId) {
            using (var db = DbInstance)
            {
                return (from a in db.Album
                        where a.UserId.Equals(uId)
                        select a).ToList();
            }
        }

        public Album Get(long id) {
            using (var db = DbInstance)
            {
                return db.Album.FirstOrDefault(c => c.Id.Equals(id));
            }
        }

        public void Add(Album album, long uId) {
            album.UserId = uId;
            album.AddTime = DateTime.Now;
            using (var db = DbInstance)
            {
                db.Album.Add(album);
                db.SaveChanges();
            }
        }

        public void Update(Album album) {
            using (var db = DbInstance)
            {
                var al = db.Album.FirstOrDefault(c => c.Id == album.Id);
                al.Location = album.Location;
                al.Description = album.Description;
                al.ShowLevel = album.ShowLevel;
                al.Name = album.Name;
                db.SaveChanges();
            }
        }
        public List<Photo> GetPhotos(long id, long uId, int page, int pageSize) {
            using (var db = DbInstance)
            {
                return (from ph in db.Photos
                        where ph.AlbumId == id && ph.UserId == uId
                        orderby ph.AddTime descending
                        select ph).Pager(page, pageSize);
            }
        }
        /// <summary>
        /// 获取相册并更改其中图片数量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public Album GetCountChange(long id, int num) {
            using (var db = DbInstance)
            {
                var album = db.Album.FirstOrDefault(c => c.Id.Equals(id));
                if (num != 0)
                {
                    album.Count += num;
                    if (album.Count < 0) album.Count = 0;
                    db.SaveChanges();
                }
                return album;
            }
        }
    }
}
