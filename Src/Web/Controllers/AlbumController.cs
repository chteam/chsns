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
                a.Id = id.Value;
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
            var photos = DbExt.Album.GetPhotos(album.Id, CHUser.UserID, p.Value, 12);
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

        public ActionResult UploadPhoto(string name,  long id, HttpPostedFileBase file){
            var al = DbExt.Album.GetCountChange(id,1);
            Validate404(al);
            var p = new PhotoImplement { Title = name, AlbumId = id, AddTime = DateTime.Now, UserId = CHUser.UserID };
            var f = new ImageUpload(file,
                                    CHContext,
                                    ConfigSerializer.Load<List<string>>("AllowImageExt")
                                    , p.AddTime,
                                    ConfigSerializer.Load<List<ThumbnailPair>>("ThumbnailSize")
                );
            f.Upload();
            p.Summary = f.Ext;
            DbExt.Photo.Add(p);
            return RedirectToAction("details", new{id});
        }

        #endregion
        #region ͼƬɾ��
        public ActionResult PhotoDel(long id){
            var p = DbExt.Photo.Get(id);
            var path = Path.Photo(CHUser.UserID, p.AddTime, p.Summary, ThumbType.Middle);

            IOFactory.StoreFile.Delete(path);
            DbExt.Album.GetCountChange(p.AlbumId.Value, -1);
            DbExt.Photo.Delete(p.Id);
            return this.RedirectToReferrer();
        }

        #endregion
		#region ����ͼƬΪ��Ƥ
        public ActionResult SetFace(long id){


            var p = DbExt.Photo.Get(id);
            var path = Path.Photo(CHUser.UserID, p.AddTime, p.Summary, ThumbType.Middle);

            var album = DbExt.Album.Get(p.AlbumId.Value);
            // db.Album.Where(c => c.ID == p.AlbumID).FirstOrDefault();
            album.FaceUrl = path;
            DbExt.Album.Update(album);
            return Content("���óɹ�");
        }

        #endregion
	}
}

