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
							where b.UserID == CHSNSUser.Current.UserID
							select 1).Count();
				return blog == 1;
			}
		}
		public Blogs GetBlog(long userid) {
			return (from b in DB.Blogs
					where b.UserID == userid
					select b).SingleOrDefault<Blogs>();
		}
		public IList GetPosts(long userid) {
			return (from b in DB.LogTable
					where b.UserID == userid
					&& b.IsPost == (byte)ShowType.完全公开
					&& b.GroupId==0
					select new
					{
						b.Title,
						b.Body,
						b.AddTime,
						Id = b.ID,
						b.CommentCount,
						b.ViewCount
					})
					.Take(10)
					.ToList();
		}
	}
}