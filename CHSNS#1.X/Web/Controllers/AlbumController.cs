using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CHSNS.Config;
using CHSNS.Model;
using System.Web;

namespace CHSNS.Controllers
{
    [LoginedFilter]
    public class AlbumController : BaseController
    {
        #region Ӧ�á�����б�


        /// <summary>
        /// �ҵ�����б�
        /// </summary>
        public ActionResult Index(int? p, long? uid)
        {
            uid = uid ?? CHUser.UserID;
            var list = DbExt.Album.Items(uid.Value);
            Title = string.Format("{0}�����",
                                  DbExt.UserInfo.GetUserName(uid.Value));
            return View(list);
        }
        #endregion

        #region �½����༭
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(long? id){
            if (!id.HasValue){
                Title = "�½����";
                return View();
            }
            Title = "�༭���";
            var model = DbExt.Album.Get(id.Value);
            ViewData["a"] = model;
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(long? id, AlbumImplement a) {
            if (id.HasValue){
                a.ID = id.Value;
                DbExt.Album.Update(a);
                return RedirectToAction("Index");
            }
            DbExt.Album.Add(a, CHUser.UserID);
            return RedirectToAction("Index");
        }

        #endregion
        #region ���
        public ActionResult Details(long id, int? p){
            InitPage(ref p);
            var album = DbExt.Album.Get(id);
            var photos = DbExt.Album.GetPhotos(album.ID, CHUser.UserID, p.Value, 12);
            ViewData["album"] = album;
            ViewData["photos"] = photos;
            Title = album.Name;
            return View();
        }

        #endregion
        #region �ϴ�
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Upload(long? id){
            var album = DbExt.Album.Get(id.Value);
            ViewData["album"] = album;
            Title = "�ϴ�";
            return View();
        }

        public ActionResult UploadPhoto(string Name, long id, HttpPostedFileBase file){
            var al = DbExt.Album.GetCountChange(id,1);
            Validate404(al);
            var p = new PhotoImplement { Name = Name, AlbumID = id, AddTime = DateTime.Now, UserID = CHUser.UserID };
            var f = new ImageUpload(file,
                                    CHContext,
                                    ConfigSerializer.Load<List<string>>("AllowImageExt")
                                    , p.AddTime,
                                    ConfigSerializer.Load<List<ThumbnailPair>>("ThumbnailSize")
                );
            f.Upload();
            p.Ext = f.Ext;
            DbExt.Photo.Add(p);
            return RedirectToAction("details", new{id});
        }

        #endregion
        #region ͼƬɾ��
        public ActionResult PhotoDel(long id){
            var p = DbExt.Photo.Get(id);
            var path = Path.Photo(CHUser.UserID, p.AddTime, p.Ext, ThumbType.Middle);

            IOFactory.StoreFile.Delete(path);
            var album = DbExt.Album.GetCountChange(p.AlbumID.Value, -1);
            DbExt.Photo.Delete(p.ID);
            return this.RedirectToReferrer();
        }

        #endregion
		#region ����ͼƬΪ��Ƥ
        public ActionResult SetFace(long id){


            var p = DbExt.Photo.Get(id);
            var path = Path.Photo(CHUser.UserID, p.AddTime, p.Ext, ThumbType.Middle);

            var album = DbExt.Album.Get(p.AlbumID.Value);
            // db.Album.Where(c => c.ID == p.AlbumID).FirstOrDefault();
            album.FaceUrl = path;
            DbExt.Album.Update(album);
            return Content("���óɹ�");
        }

        #endregion
	}
}

