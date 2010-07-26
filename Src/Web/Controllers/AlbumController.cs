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
            uid = uid ?? CHUser.UserId;
            var list = DataExt.Album.Items(uid.Value);
            Title = string.Format("{0}�����",
                                  DataExt.UserInfo.GetUserName(uid.Value));
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
            var model = DataExt.Album.Get(id.Value);
            ViewData["a"] = model;
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Edit(long? id, Album a)
        {
            if (id.HasValue){
                a.Id = id.Value;
                DataExt.Album.Update(a);
                return RedirectToAction("Index");
            }
            DataExt.Album.Add(a, CHUser.UserId);
            return RedirectToAction("Index");
        }

        #endregion
        #region ���
        public virtual ActionResult Details(long id, int? p)
        {
            InitPage(ref p);
            var album = DataExt.Album.Get(id);
            var photos = DataExt.Album.GetPhotos(album.Id, CHUser.UserId, p.Value, 12);
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
            var album = DataExt.Album.Get(id.Value);
            ViewData["album"] = album;
            Title = "�ϴ�";
            return View();
        }

        public virtual ActionResult UploadPhoto(string name, long id, HttpPostedFileBase file)
        {
            var al = DataExt.Album.GetCountChange(id,1);
            if (al == null)
                return HttpNotFound("album not found");
            var p = new Photo { Title = name, AlbumId = id, AddTime = DateTime.Now, UserId = CHUser.UserId };
            var f = new ImageUpload(file,
                                    CHContext,
                                    ConfigSerializer.Load<List<string>>("AllowImageExt")
                                    , p.AddTime,
                                    ConfigSerializer.Load<List<ThumbnailPair>>("ThumbnailSize")
                );
            f.Upload();
            p.Summary = f.Ext;
            DataExt.Photo.Add(p);
            return RedirectToAction("details", new{id});
        }

        #endregion
        #region ͼƬɾ��
        public virtual ActionResult PhotoDel(long id)
        {
            var p = DataExt.Photo.Get(id);
            var path = Path.Photo(CHUser.UserId, p.AddTime, p.Summary, ThumbType.Middle);

            IOFactory.StoreFile.Delete(path);
            DataExt.Album.GetCountChange(p.AlbumId.Value, -1);
            DataExt.Photo.Delete(p.Id);
            return this.RedirectToReferrer();
        }

        #endregion
		#region ����ͼƬΪ��Ƥ
        public virtual ActionResult SetFace(long id)
        {


            var p = DataExt.Photo.Get(id);
            var path = Path.Photo(CHUser.UserId, p.AddTime, p.Summary, ThumbType.Middle);

            var album = DataExt.Album.Get(p.AlbumId.Value);
            // db.Album.Where(c => c.ID == p.AlbumID).FirstOrDefault();
            album.FaceUrl = path;
            DataExt.Album.Update(album);
            return Content("���óɹ�");
        }

        #endregion
	}
}

