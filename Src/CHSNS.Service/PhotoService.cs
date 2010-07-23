using System;

using CHSNS.Operator;
using CHSNS.SQLServerImplement;
using CHSNS.Models;

namespace CHSNS.Service
{
    public class PhotoService : BaseService<PhotoService>
    {
        private readonly PhotoOperator _photo;
        public PhotoService()
        {
            _photo = new PhotoOperator();
        }

        public void Add(Photo photo)
        {
            photo.AddTime = DateTime.Now;
            _photo.Add(photo);
        }

        public Photo Get(long id)
        {
            return _photo.Get(id);
        }

        public void Delete(long id)
        {
            _photo.Delete(id);
        }
    }
}
