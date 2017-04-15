using System;
using System.Collections.Generic;
using CHSNS.Config;
using CHSNS.Model;
using CHSNS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CHSNS.Controllers
{
    using CHSNS.Service;

    [Authorize]
    public partial class AlbumController : BaseController
    {
 
        public AlbumService Album { get; set; }
 
        public PhotoService Photo
        { get; set; }
   
        public UserService UserInfo { get; set; }
        #region Ӧ�á�����б�


        /// <summary>
        /// �ҵ�����б�
        /// </summary>
        public virtual ActionResult Index(int? p, long? uid)
        {
            uid = uid ?? WebUser.UserId;
            var list = Album.Items(uid.Value);
            Title = string.Format("{0}�����",
                                  UserInfo.GetUserName(uid.Value));
            return View(list);
        }
        #endregion

        #region �½����༭
        [HttpGet]
        public virtual ActionResult Edit(long? id)
        {
            if (!id.HasValue){
                Title = "�½����";
                return View();
            }
            Title = "�༭���";
            var model = Album.Get(id.Value);
            ViewData["a"] = model;
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Edit(long? id, Album a)
        {
            if (id.HasValue){
                a.Id = id.Value;
                Album.Update(a);
                return RedirectToAction("Index");
            }
            Album.Add(a, WebUser.UserId);
            return RedirectToAction("Index");
        }

        #endregion

        #region ���
        public virtual ActionResult Details(long id, int? p)
        {
            InitPage(ref p);
            var album = Album.Get(id);
            var photos = Album.GetPhotos(album.Id, WebUser.UserId, p.Value, 12);
            ViewData["album"] = album;
            ViewData["photos"] = photos;
            Title = album.Name;
            return View();
        }

        #endregion
        #region �ϴ�
        [HttpGet]
        public virtual ActionResult Upload(long? id)
        {
            var album = Album.Get(id.Value);
            ViewData["album"] = album;
            Title = "�ϴ�";
            return View();
        }

        public virtual ActionResult UploadPhoto(string name, long id, HttpPostedFileBase file)
        {
            var al = Album.GetCountChange(id,1);
            if (al == null)
                return HttpNotFound("album not found");
            var p = new Photo { Title = name, AlbumId = id, AddTime = DateTime.Now, UserId = WebUser.UserId };
            var f = new ImageUpload(file,
                                    WebContext,
                                    ConfigSerializer.Load<List<string>>("AllowImageExt")
                                    , p.AddTime,
                                    ConfigSerializer.Load<List<ThumbnailPair>>("ThumbnailSize")
                );
            f.Upload();
            p.Summary = f.Ext;
            Photo.Add(p);
            return RedirectToAction("details", new{id});
        }

        #endregion
        #region ͼƬɾ��
        public virtual ActionResult PhotoDel(long id)
        {
            var p = Photo.Get(id);
            var path = Path.Photo(WebUser.UserId, p.AddTime, p.Summary, ThumbType.Middle);

            IOFactory.StoreFile.Delete(path);
            Album.GetCountChange(p.AlbumId.Value, -1);
            Photo.Delete(p.Id);
            return this.RedirectToReferrer();
        }

        #endregion
        #region ����ͼƬΪ��Ƥ
        public virtual ActionResult SetFace(long id)
        {


            var p = Photo.Get(id);
            var path = Path.Photo(WebUser.UserId, p.AddTime, p.Summary, ThumbType.Middle);

            var album = Album.Get(p.AlbumId.Value);
            // db.Album.Where(c => c.ID == p.AlbumID).FirstOrDefault();
            album.FaceUrl = path;
            Album.Update(album);
            return Content("���óɹ�");
        }

        #endregion
    }
}
