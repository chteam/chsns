using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CHSNS.Config;
using CHSNS.Filter;
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
		public ActionResult Index(int? p, long? userid) {
			var list = (from a in DBExt.DB.Album
						where a.UserID.Equals(userid ?? CHUser.UserID)
						select a);
			return View(list);
		}	
		#endregion
		#region 新建，编辑
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Edit(long? id) {
			if (id.HasValue) {
				var model = DBExt.DB.Album.Where(c => c.ID.Equals(id)).FirstOrDefault();
				return View(model);
			}
			return View();
		}
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Edit(long? id, Album a) {
			if (id.HasValue) {
				var al = DBExt.DB.Album.Where(c => c.ID == id.Value).FirstOrDefault();
				al.Location = a.Location;
				al.Description = a.Description;
				al.ShowLevel = a.ShowLevel;
				al.Name = a.Name;
				DBExt.DB.SubmitChanges();
				return RedirectToAction("Index");
			} else {
				a.Count = 0;
				a.UserID = CHUser.UserID;
				a.AddTime = System.DateTime.Now;
				
				DBExt.DB.Album.InsertOnSubmit(a);
				DBExt.DB.SubmitChanges();
				return RedirectToAction("Index");
			}
		}
		#endregion
		#region 相册
		public ActionResult Details(long id, int? p) {
			InitPage(ref p);
			var album = (from a in DBExt.DB.Album
						 where a.ID.Equals(id)
						 select a).FirstOrDefault();
			var ps = (from ph in DBExt.DB.Photo
					  where ph.AlbumID == album.ID && ph.UserID == CHUser.UserID
					  select ph);
			ViewData["album"] = album;
			ViewData["photos"] = new PagedList<Photo>(ps, p.Value, 12);
			Title = album.Name;
			return View();
		}

		#endregion
		#region 上传
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Upload(long? id){
			var album = (from a in DBExt.DB.Album
						 where a.ID.Equals(id)
						 select a).FirstOrDefault();
			ViewData["album"] = album;
			Title = "上传";
			return View();
		}
		public ActionResult UploadPhoto(string Name, long id){

			HttpPostedFileBase file = Request.Files["file"];
			var al = DBExt.DB.Album.Where(c => c.ID == id).FirstOrDefault();
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
			DBExt.DB.Photo.InsertOnSubmit(p);

			DBExt.DB.SubmitChanges();
			return RedirectToAction("details", new {id = id});
		}

		#endregion
	}
}

