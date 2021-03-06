﻿
namespace CHSNS.Service
{
    using System;
    using System.Linq;
    using CHSNS.Models;
    using System.ComponentModel.Composition;
    [Export]
    public class PhotoService : BaseService
    {

        public void Add(Photo photo)
        {
            photo.AddTime = DateTime.Now;
            using (var db = DbInstance)
            {
                db.Photos.Add(photo);
                db.SaveChanges();
            }
        }

        public Photo Get(long id)
        {
            using (var db = DbInstance)
            {
                var p = db.Photos.Where(c => c.Id == id).FirstOrDefault();
                return p;
            }
        }

        public void Delete(long id)
        {
            using (var db = DbInstance)
            {
                var p = db.Photos.Where(c => c.Id == id).FirstOrDefault();
                db.Photos.Remove(p);
                db.SaveChanges();
            }
        }
    }
}
