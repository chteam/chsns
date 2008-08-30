
using System;
using System.Web.Mvc;
using CHSNS.Data;
using CHSNS.Extension;
using CHSNS.Filter;
using CHSNS.Models;
namespace CHSNS.Controllers
{
	public class BlogController : BaseController
	{
		protected override void OnResultExecuting(ResultExecutingContext filterContext) {
			if (filterContext.Result is ViewResult) {
				ViewResult vr = filterContext.Result as ViewResult;
				if (string.IsNullOrEmpty(vr.MasterName))
					vr.MasterName = "BlogMaster";
			}
		}
		public ActionResult index() {

			long userid = this.QueryLong("userid");
			//DBExt mb = new DBExt(Session);
			var blog = DBExt.GetBlog(userid);
			ViewData["userid"] = userid;
			ViewData["blog"] = blog;
			//RenderView("index");
			return View();
		}
		[LoginedFilter]
		public ActionResult edit() {
			//DBExt mb = new DBExt(Session);
			var blog = DBExt.GetBlog(CHSNSUser.Current.UserID);
			ViewData["blog"] = blog;
			//RenderView("edit");
			return View();
		}
		[AcceptVerbs("Post")]
		[LoginedFilter]
		public ActionResult Update() {
			Blogs blog=null;
			UpdateModel(blog, Request.Form.AllKeys, "blog.");
			if (string.IsNullOrEmpty(blog.Title)) {
				TempData["msg"] = "标题不能为空";
				return this.RedirectToReferrer();

			}
			if (string.IsNullOrEmpty(blog.WriteName)) {
				TempData["msg"] = "笔名不能为空";
				return this.RedirectToReferrer();

			}
			try {
			//	DBExt mb = new DBExt(Session);
				var isexists = DBExt.GetBlog(CHSNSUser.Current.UserID);
				blog.UserID = CHSNSUser.Current.UserID;
				if (isexists == null) {
					blog.CreateTime = DateTime.Now;
					DBExt.DB.Blogs.InsertOnSubmit(blog);

				} else {
					isexists.Title = blog.Title;
					isexists.SubTitle = blog.SubTitle;
					isexists.CommentEmail = blog.CommentEmail;
					isexists.WriteName = blog.WriteName;
					isexists.Publish = blog.Publish;
					isexists.IsWebServices = blog.IsWebServices;
					isexists.MetaKey = blog.MetaKey;
				}
				DBExt.DB.SubmitChanges();
				
			} catch (Exception e) {
				TempData["msg"] = e.Message;
			}
			return this.RedirectToReferrer();
		}
	}
}

