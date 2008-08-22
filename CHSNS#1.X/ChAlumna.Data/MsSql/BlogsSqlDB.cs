namespace CHSNS.Data
{
	using System.Linq;
	using CHSNS.Models;
	using System.Collections;
	using CHSNS;
	public partial class DBExt
	{
		public bool IsBlogExists {
			get {
				var blog = (from b in DB.Blogs
							where b.userid == CHSNSUser.Current.Userid
							select 1).Count();
				return blog == 1;
			}
		}
		public Blogs GetBlog(long userid) {
			return (from b in DB.Blogs
					where b.userid == userid
					select b).SingleOrDefault<Blogs>();
		}
		public IList GetPosts(long userid) {
			return (from b in DB.Note
					where b.userid == userid
					&& b.IsPost == (byte)ShowType.完全公开
					&& b.GroupId==0
					select new
					{
						b.title,
						b.body,
						b.AddTime,
						b.id,
						b.CommentCount,
						b.ViewCount
					})
					.Take(10)
					.ToList();
		}
	}
}