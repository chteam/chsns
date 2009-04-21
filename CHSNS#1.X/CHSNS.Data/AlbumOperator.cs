﻿using System;
using System.Collections.Generic;
using System.Linq;
using CHSNS.Models;
using CHSNS.Operator;

namespace CHSNS.SQLServerImplement {
    public class AlbumOperator:BaseOperator,IAlbumOperator {
        #region IAlbumOperator 成员

        public List<Album> Items(long uId) {
            using (var db = DBExtInstance) {
                return (from a in db.Album
                        where a.UserID.Equals(uId)
                        select a).ToList();
            }
        }

        public Album Get(long id){
            using (var db = DBExtInstance){
                return db.Album.FirstOrDefault(c => c.ID.Equals(id));
            }
        }

        public void Add(Album album, long uId){
            using (var db = DBExtInstance){
                album.Count = 0;
                album.UserID = uId;
                album.AddTime = DateTime.Now;
                db.Album.InsertOnSubmit(album);
                db.SubmitChanges();
            }
        }

        public void Update(Album album){
            using (var db = DBExtInstance){
                var al = db.Album.FirstOrDefault(c => c.ID == album.ID);
                al.Location = album.Location;
                al.Description = album.Description;
                al.ShowLevel = album.ShowLevel;
                al.Name = album.Name;
                db.SubmitChanges();
            }
        }

        public List<Photo> GetPhotos(long id, long uId,int page, int pageSize) {
            using (var db = DBExtInstance){
                return  (from ph in db.Photo
                          where ph.AlbumID == id && ph.UserID ==uId
                          select ph).Pager(page,pageSize);
            }
        }

        public Album GetCountChange(long id, int num){
            using (var db = DBExtInstance){
                var a = db.Album.FirstOrDefault(c => c.ID.Equals(id));
                if (num != 0){
                    a.Count += num;
                    if (a.Count < 0) a.Count = 0;
                    db.SubmitChanges();
                }
                return a;
            }
        }

        #endregion
    }
}