﻿using System;

using CHSNS.Operator;
using CHSNS.SQLServerImplement;
using CHSNS.Models;

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
        public void Add(Photo photo) {
            photo.AddTime = DateTime.Now;
            Photo.Add(photo);
        }

        public Photo Get(long id) {
            return Photo.Get(id);
        }

        public void Delete(long id) {
            Photo.Delete(id);
        }
    }
}
