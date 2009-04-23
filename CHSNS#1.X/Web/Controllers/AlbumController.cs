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
        #region 应用、相册列表


        /// <summary>
        /// 我的相册列表
        /// </summary>
        public ActionResult Index(int? p, long? uid)
        {
            uid = uid ?? CHUser.UserID;
            var list = DBExt.Album.Items(uid.Value);
            Title = string.Format("{0}的相册",
                                  DBExt.UserInfo.GetUserName(uid.Value));
            return View(list);
        }
        #endregion

        #region 新建，编辑
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(long? id){
            if (!id.HasValue){
                Title = "新建相册";
                return View();
            }
            Title = "编辑相册";
            var model = DBExt.Album.Get(id.Value);
            ViewData["a"] = model;
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(long? id, AlbumImplement a) {
            if (id.HasValue){
                a.ID = id.Value;
                DBExt.Album.Update(a);
                return RedirectToAction("Index");
            }
            DBExt.Album.Add(a, CHUser.UserID);
            return RedirectToAction("Index");
        }

        #endregion
        #region 相册
        public ActionResult Details(long id, int? p){
            InitPage(ref p);
            var album = DBExt.Album.Get(id);
            var photos = DBExt.Album.GetPhotos(album.ID, CHUser.UserID, p.Value, 12);
            ViewData["album"] = album;
            ViewData["photos"] = photos;
            Title = album.Name;
            return View();
        }

        #endregion
        #region 上传
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Upload(long? id){
            var album = DBExt.Album.Get(id.Value);
            ViewData["album"] = album;
            Title = "上传";
            return View();
        }

        public ActionResult UploadPhoto(string Name, long id, HttpPostedFileBase file){
            var al = DBExt.Album.GetCountChange(id,1);
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
            DBExt.Photo.Add(p);
            return RedirectToAction("details", new{id});
        }

        #endregion
        #region 图片删除
        public ActionResult PhotoDel(long id){
            var p = DBExt.Photo.Get(id);
            var path = Path.Photo(CHUser.UserID, p.AddTime, p.Ext, ThumbType.Middle);

            IOFactory.StoreFile.Delete(path);
            var album = DBExt.Album.GetCountChange(p.AlbumID.Value, -1);
            DBExt.Photo.Delete(p.ID);
            return this.RedirectToReferrer();
        }

        #endregion
		#region 设置图片为封皮
        public ActionResult SetFace(long id){


            var p = DBExt.Photo.Get(id);
            var path = Path.Photo(CHUser.UserID, p.AddTime, p.Ext, ThumbType.Middle);

            var album = DBExt.Album.Get(p.AlbumID.Value);
            // db.Album.Where(c => c.ID == p.AlbumID).FirstOrDefault();
            album.FaceUrl = path;
            DBExt.Album.Update(album);
            return Content("设置成功");
        }

        #endregion
	}
}

