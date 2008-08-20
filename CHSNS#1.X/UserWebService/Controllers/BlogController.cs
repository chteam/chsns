namespace ChAlumna.Controllers
{
	using System;
	using ChAlumna.Models;
	using Castle.MonoRail.Framework;
	using CHSNS.Data;
	[Filter(ExecuteEnum.BeforeAction, typeof(LoginedFilter))]
	[Layout("blogmaster")]
	public class BlogController : BaseController
	{
		[SkipFilter]
		public void index() {

			long userid = this.QueryLong("userid");
			DBExt mb = new DBExt(Session);
			var blog = mb.GetBlog(userid);
			ViewData["userid"] = userid;
			ViewData["blog"] = blog;
			RenderView("index");
		}
		public void edit() {
			DBExt mb = new DBExt(Session);
			var blog = mb.GetBlog(ChUser.Current.Userid);
			ViewData["blog"] = blog;
			RenderView("edit");
		}
		[AccessibleThrough(Verb.Post)]
		public void Update([DataBind("blog")]Blogs blog) {
			if (string.IsNullOrEmpty(blog.Title)) {
				TempData["msg"] = "标题不能为空";
				RedirectToReferrer();
				return;
			}
			if (string.IsNullOrEmpty(blog.WriteName)) {
				TempData["msg"] = "笔名不能为空";
				RedirectToReferrer();
				return;
			}
			try {
				DBExt mb = new DBExt(Session);
				var isexists = mb.GetBlog(ChUser.Current.Userid);
				blog.userid = ChUser.Current.Userid;
				if (isexists == null) {
					blog.CreateTime = DateTime.Now;
					mb.DB.Blogs.InsertOnSubmit(blog);

				} else {
					isexists.Title = blog.Title;
					isexists.SubTitle = blog.SubTitle;
					isexists.CommentEmail = blog.CommentEmail;
					isexists.WriteName = blog.WriteName;
					isexists.Publish = blog.Publish;
					isexists.IsWebServices = blog.IsWebServices;
					isexists.MetaKey = blog.MetaKey;
				}
				mb.DB.SubmitChanges();
				
			} catch (Exception e) {
				TempData["msg"] = e.Message;
			}
			RedirectToReferrer();
		}
	}
}

