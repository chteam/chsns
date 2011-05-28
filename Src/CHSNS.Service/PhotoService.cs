
namespace CHSNS.Service
{
    using System;
    using System.Linq;
    using CHSNS.Models;
    using System.ComponentModel.Composition;
    [Export]
    public class PhotoService : BaseService<PhotoService>
    {

        public void Add(Photo photo)
        {
            photo.AddTime = DateTime.Now;
            using (var db = DBExtInstance)
            {
                db.Photos.Add(photo);
                db.SaveChanges();
            }
        }

        public Photo Get(long id)
        {
            using (var db = DBExtInstance)
            {
                var p = db.Photos.Where(c => c.Id == id).FirstOrDefault();
                return p;
            }
        }

        public void Delete(long id)
        {
            using (var db = DBExtInstance)
            {
                var p = db.Photos.Where(c => c.Id == id).FirstOrDefault();
                db.Photos.Remove(p);
                db.SaveChanges();
            }
        }
    }
}
