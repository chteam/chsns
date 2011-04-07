using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CHSNS.Config;
using CHSNS.Model;
using System.Web;
using CHSNS.Models;

namespace CHSNS.Controllers
{
    [Authorize]
    public partial class AlbumController : BaseController
    {
        #region Ӧ�á�����б�


        /// <summary>
        /// �ҵ�����б�
        /// </summary>
        public virtual ActionResult Index(int? p, long? uid)
        {
            uid = uid ?? WebUser.UserId;
            var list = Services.Album.Items(uid.Value);
            Title = string.Format("{0}�����",
                                  Services.UserInfo.GetUserName(uid.Value));
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
            var model = Services.Album.Get(id.Value);
            ViewData["a"] = model;
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Edit(long? id, Album a)
        {
            if (id.HasValue){
                a.Id = id.Value;
                Services.Album.Update(a);
                return RedirectToAction("Index");
            }
            Services.Album.Add(a, WebUser.UserId);
            return RedirectToAction("Index");
        }

        #endregion

        #region ���
        public virtual ActionResult Details(long id, int? p)
        {
            InitPage(ref p);
            var album = Services.Album.Get(id);
            var photos = Services.Album.GetPhotos(album.Id, WebUser.UserId, p.Value, 12);
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
            var album = Services.Album.Get(id.Value);
            ViewData["album"] = album;
            Title = "�ϴ�";
            return View();
        }

        public virtual ActionResult UploadPhoto(string name, long id, HttpPostedFileBase file)
        {
            var al = Services.Album.GetCountChange(id,1);
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
            Services.Photo.Add(p);
            return RedirectToAction("details", new{id});
        }

        #endregion
        #region ͼƬɾ��
        public virtual ActionResult PhotoDel(long id)
        {
            var p = Services.Photo.Get(id);
            var path = Path.Photo(WebUser.UserId, p.AddTime, p.Summary, ThumbType.Middle);

            IOFactory.StoreFile.Delete(path);
            Services.Album.GetCountChange(p.AlbumId.Value, -1);
            Services.Photo.Delete(p.Id);
            return this.RedirectToReferrer();
        }

        #endregion
        #region ����ͼƬΪ��Ƥ
        public virtual ActionResult SetFace(long id)
        {


            var p = Services.Photo.Get(id);
            var path = Path.Photo(WebUser.UserId, p.AddTime, p.Summary, ThumbType.Middle);

            var album = Services.Album.Get(p.AlbumId.Value);
            // db.Album.Where(c => c.ID == p.AlbumID).FirstOrDefault();
            album.FaceUrl = path;
            Services.Album.Update(album);
            return Content("���óɹ�");
        }

        #endregion
    }
}

