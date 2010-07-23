
namespace CHSNS.Service
{
    using System;
    using System.Linq;
    using CHSNS.Models;
    using CHSNS.SQLServerImplement;
    public class PhotoService : BaseService<PhotoService>
    {

        public void Add(Photo photo)
        {
            photo.AddTime = DateTime.Now;
            using (var db = DBExtInstance)
            {
                db.Photo.AddObject(photo);
                db.SubmitChanges();
            }
        }

        public Photo Get(long id)
        {
            using (var db = DBExtInstance)
            {
                var p = db.Photo.Where(c => c.Id == id).FirstOrDefault();
                return p;
            }
        }

        public void Delete(long id)
        {
            using (var db = DBExtInstance)
            {
                var p = db.Photo.Where(c => c.Id == id).FirstOrDefault();
                db.DeleteObject(p);
                db.SaveChanges();
            }
        }
    }
}
