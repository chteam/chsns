namespace CHSNS.Data
{
	using System.Collections;
	using System.Linq;
	using CHSNS.Models;

	using System;
	using CHSNS;
	using System.Collections.Generic;
	public partial class DBExt 
	{
		public void NoteTags_Add(long id, string val) {
			string[] strs = Regular.Trim(val.Split(','));

			var existsTags = (from t in DB.Tags
							  where t.Type == (byte)TagsType.日志
							  && strs.Contains(t.Title)
							  select t).ToList();

			foreach (string s in strs) {
				Tags tags = (from e in existsTags
							 where e.Title == s
							 select e).SingleOrDefault();
				if (tags == null) { //插入了
					tags = new Tags() 
					{
						Count = 0,
						Title = s,
						Type = (byte)TagsType.日志,
						//ReachTime = DateTime.Now 
					};
					//DB.Tags.InsertOnSubmit(tags);
				//	DB.SubmitChanges();
				}
				////tags.Count++;
				//DB.LogTag.InsertOnSubmit(
				//    new LogTag()
				//    {
				//        LogID = id,
				//        TagID = tags.Id,
				//    }
				//    );
			}
			//DB.SubmitChanges();
		}
		//public IList NoteTags(long id) {
		//    //return (from l in DB.LogTag
		//    //        where l.LogID == id && l.TagidTags.Type == (byte)TagsType.日志
		//    //        select
		//    //        new
		//    //        {
		//    //            l.TagidTags.Title
		//    //        }).ToList();
		//}
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
			//this.DB.LogTag.Delete(item => item.LogID == id);

		}
		public IList NoteTags_Top(int count) {
			string cachename=string.Format("NoteTags_Top{0}", count);
			if (CHCache.IsNullorEmpty(cachename)) {
				var list = (from t in DB.Tags
							where t.Type == (byte)TagsType.日志
							orderby t.ID descending
							select new
							{
								Title = t.Title,
								Count = t.Count.ToString().Length
							}).Take(count).ToList();
				CHCache.SetCache(cachename, list, TimeSpan.FromMinutes(20));
			}
			return CHCache.GetCache(cachename) as IList;
		}
		//public IQueryable<NotePas> GetNotebyTag(string title) {
		//    DataBaseExecutor.Execute(
		//        "update tags set ReachTime=getdate(),Count=Count+1 where title=@title", "@title", title);
		//    return (from l in DB.LogTag
		//            where l.TagidTags.Type == (byte)TagsType.日志
		//            && l.TagidTags.Title == title.Trim()
		//            && l.Log.IsPost == (byte)ShowType.完全公开
		//            join b in DB.Blogs on l.Log.UserID equals b.UserID
		//            select new NotePas() {
		//                ID = l.Log.ID,
		//                Title = l.Log.Title,
		//                ViewCount = l.Log.ViewCount,
		//                CommentCount = l.Log.CommentCount,
		//                AddTime = l.Log.AddTime,
		//                WriteName = b.WriteName,
		//                UserID = b.UserID,
		//                Body = l.Log.Body.Substring(0, 50)
		//            });
		//}
	

	}
}
