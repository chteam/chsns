using System.Linq;
using System.Web.Mvc;
using CHSNS.Filter;
using CHSNS;
using CHSNS.Models;
namespace CHSNS.Controllers {
	[LoginedFilter]
	public class AlbumController : BaseController {
		/// <summary>
		/// 我的相册列表
		/// </summary>
		public ActionResult Index(int? p, long? userid) {
			var list = (from a in DBExt.DB.Album
						where a.UserID.Equals(userid ?? CHUser.UserID)
						select a);
			return View(list);
		}
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
			return View();
		}
		#endregion

		public ActionResult Details(long id, int? p) {
			var list = (from a in DBExt.DB.Album
			            where a.ID.Equals(id)
			            select a).FirstOrDefault();
			return View(list);
		}

		//随机出
		public void random() {
			//Chsword.Reader.Albums al = new Chsword.Reader.Albums();
			//ViewData.Add("items", al.GetAlbumRandomTable().Rows);
			//View();
		}
		/// <summary>
		/// 某人的相册列表
		/// </summary>
		public void list() {
			// index = ;
			//Chsword.Reader.Albums al = new Chsword.Reader.Albums();
			//al.Viewerid = CHSNSUser.Current.UserID;
			//al.Ownerid = this.QueryLong("userid") == 0 ? CHSNSUser.Current.UserID : this.QueryLong("userid");
			//ViewData.Add("albums", al);
			//ViewData.Add("tabs", this.QueryNum("tabs"));

			//ViewData.Add("rows", al.GetAlbums().Rows);
			//View();
		}

		public ActionResult List(long? uid)
		{
			return View();
		}
	}
}

