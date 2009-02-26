using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CHSNS.Config;

using CHSNS;
using CHSNS.Models;
using System.Web;
namespace CHSNS.Controllers {
	[LoginedFilter]
	public class AlbumController : BaseController {
		#region 应用、相册列表

	
		/// <summary>
		/// 我的相册列表
		/// </summary>
		public ActionResult Index(int? p, long? uid) {
			uid = uid ?? CHUser.UserID;
		    List<Album> list;
            using (var db = DBExt.Instance)
            {
                 list = (from a in db.Album
                            where a.UserID.Equals(uid.Value)
                            select a).ToList();
            }
		    Title = string.Format("{0}的相册",
			                      DBExt.UserInfo.GetUserName(uid.Value));
			return View(list);
		}	
		#endregion
		
		#region 新建，编辑
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Edit(long? id) {
            if (id.HasValue) {
                using (var db = DBExt.Instance)
                {
                    var model = db.Album.Where(c => c.ID.Equals(id)).FirstOrDefault();
                    ViewData["a"] = model;
                    return View(model);
                }
            }
			return View();
		}
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Edit(long? id, Album a) {
            using (var db = DBExt.Instance)
            {
                if (id.HasValue)
                {
                    var al = db.Album.Where(c => c.ID == id.Value).FirstOrDefault();
                    al.Location = a.Location;
                    al.Description = a.Description;
                    al.ShowLevel = a.ShowLevel;
                    al.Name = a.Name;
                    db.SubmitChanges();
                    return RedirectToAction("Index");
                }
                a.Count = 0;
                a.UserID = CHUser.UserID;
                a.AddTime = DateTime.Now;

                db.Album.InsertOnSubmit(a);
                db.SubmitChanges();
            }
		    return RedirectToAction("Index");
		}
		#endregion
		#region 相册
		public ActionResult Details(long id, int? p) {
			InitPage(ref p);
            using (var db = DBExt.Instance)
            {
                var album = (from a in db.Album
                             where a.ID.Equals(id)
                             select a).FirstOrDefault();
                var ps = (from ph in db.Photo
                          where ph.AlbumID == album.ID && ph.UserID == CHUser.UserID
                          select ph);
                ViewData["album"] = album;
                ViewData["photos"] = new PagedList<Photo>(ps, p.Value, 12);
                Title = album.Name;
            }
		    return View();
		}

		#endregion
		#region 上传
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Upload(long? id){
            using (var db = DBExt.Instance)
            {
                var album = (from a in db.Album
                             where a.ID.Equals(id)
                             select a).FirstOrDefault();
                ViewData["album"] = album;
            }
		    Title = "上传";
			return View();
		}
		public ActionResult UploadPhoto(string Name, long id,HttpPostedFileBase file){

            using (var db = DBExt.Instance)
            {
                var al = db.Album.Where(c => c.ID == id).FirstOrDefault();
                Validate404(al);
                al.Count++;
                var p = new Photo {Name = Name, AlbumID = id, AddTime = DateTime.Now, UserID = CHUser.UserID};
                var f = new ImageUpload(file,
                                        HttpContext,
                                        ConfigSerializer.Load<List<string>>("AllowImageExt")
                                        , p.AddTime,
                                        ConfigSerializer.Load<List<ThumbnailPair>>("ThumbnailSize")
                    );
                var ret = f.Upload();
                p.Ext = f.Ext;
                db.Photo.InsertOnSubmit(p);

                db.SubmitChanges();
            }
		    return RedirectToAction("details", new {id = id});
		}

		#endregion
		#region 图片删除
		public ActionResult PhotoDel(long id) {
            using (var db = DBExt.Instance)
            {
                var p = db.Photo.Where(c => c.ID == id).FirstOrDefault();
                var path = Path.Photo(CHUser.UserID, p.AddTime, p.Ext, ThumbType.Middle);
                var pathserver = CHServer.MapPath(path);
                System.IO.File.Delete(pathserver);
                var album = db.Album.Where(c => c.ID == p.AlbumID).FirstOrDefault();
                album.Count--;
                if (album.Count < 0) album.Count = 0;
                db.Photo.DeleteOnSubmit(p);
                db.SubmitChanges();
            }
		    return this.RedirectToReferrer();
		}

		#endregion
		#region 设置图片为封皮
		public ActionResult SetFace(long id){
            using (var db = DBExt.Instance)
            {
                var p = db.Photo.Where(c => c.ID == id).FirstOrDefault();
                var path = Path.Photo(CHUser.UserID, p.AddTime, p.Ext, ThumbType.Middle);
                var album = db.Album.Where(c => c.ID == p.AlbumID).FirstOrDefault();
                album.FaceUrl = path;
                db.SubmitChanges();
            }
		    return Content("设置成功");
		}

		#endregion
	}
}

