namespace CHSNS.Data
{
	using System.Collections;
	using System.Linq;
	using ChAlumna.Models;
	using LinqToSqlExtensions;
	using System;
	using ChAlumna;
	public partial class DBExt 
	{
		public void NoteTags_Add(long id, string val) {
			string[] strs = Regular.Trim(val.Split(','));

			var existsTags = (from t in DB.Tags
							  where t.type == (byte)TagsType.日志
							  && strs.Contains(t.title)
							  select t).ToList();

			foreach (string s in strs) {
				Tags tags = (from e in existsTags
							 where e.title == s
							 select e).SingleOrDefault();
				if (tags == null) { //插入了
					tags = new Tags() 
					{
						Count = 0,
						title = s,
						type = (byte)TagsType.日志,
						ReachTime = DateTime.Now 
					};
					DB.Tags.InsertOnSubmit(tags);
					DB.SubmitChanges();
				}
				//tags.Count++;
				DB.LogTag.InsertOnSubmit(
					new LogTag()
					{
						logid = id,
						tagid = tags.id,
					}
					);
			}
			DB.SubmitChanges();
		}
		public IList NoteTags(long id) {
			return (from l in DB.LogTag
					where l.logid == id && l.Tags.type == (byte)TagsType.日志
					select
					new
					{
						l.Tags.title
					}).ToList();
		}
		public void NoteTags_Change(long id, string val) {
			//string[] strs = Regular.Trim(val.Split(','));
			////已经存在的标题
			//var existsTags = (from l in DB.LogTag
			//                  where l.Tags.type == (byte)TagsType.日志
			//                  && l.logid==id
			//                  select t).ToList();

			////要删除的标签
			//var willDel = (from t in DB.LogTag
			//               where t.logid == id && t.Tags.type == (byte)TagsType.日志
			//               && !strs.Contains(t.Tags.title)
			//               select t
			//                  ).ToList();
			//DB.LogTag.(willDel);

			//DB.SubmitChanges();

		}
		public void NoteTags_Delete(long id) {
			this.DB.LogTag.Delete(item => item.logid == id);

		}
		public IList NoteTags_Top(int count) {
			string cachename=string.Format("NoteTags_Top{0}", count);
			if (ChCache.IsNullorEmpty(cachename)) {
				var list = (from t in DB.Tags
							where t.type == (byte)TagsType.日志
							orderby t.id descending
							select new
							{
								Title = t.title,
								Count = t.Count.ToString().Length
							}).Take(count).ToList();
				ChCache.SetCache(cachename, list, TimeSpan.FromMinutes(20));
			}
			return ChCache.GetCache(cachename) as IList;
		}
		public IList GetNotebyTag(string title) {

//			DataBaseExecutor me = new DataBaseExecutor();
			Dictionary d = new Dictionary();
			d.Add("@title", title);
			DBE.Execute(
				"update tags set ReachTime=getdate(),Count=Count+1 where title=@title", d);

			return (from l in DB.LogTag
					where l.Tags.type == (byte)TagsType.日志
					&& l.Tags.title == title.Trim()
					&& l.Note.IsPost == (byte)ShowType.完全公开
					join b in DB.Blogs on l.Note.userid equals b.userid
					select new
					{
						l.Note.id,
						l.Note.title,
						l.Note.ViewCount,
						l.Note.CommentCount,
						l.Note.AddTime,
						b.WriteName,
						b.userid,
						body = l.Note.body.Substring(0, 50)
					})
					.ToList();
		}

	}
}
