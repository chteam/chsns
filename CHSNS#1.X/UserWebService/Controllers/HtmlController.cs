
namespace ChAlumna.Controllers
{
	using Castle.MonoRail.Framework;
	using System.Text;
	using System;
	using System.Linq;
	using CHSNS.Data;
	using ChAlumna.Config;
	using CHSNS;
	[Helper(typeof(PersonalHelper))]
	[DefaultAction("Index")]
	public class HtmlController : BaseBlockController
	{
		[AccessibleThrough(Verb.Post)]
		public void index() { }
		[AccessibleThrough(Verb.Post)]
		public void ProfileEdit() {
			ViewData.Add("template", Params["template"]);
			this.RenderView("html", "ProfileEdit");
		}
		[AccessibleThrough(Verb.Post)]
		public void PostList() {
			string[] plist = {
				"Groupid",
				"EveryPage",
				"nowpage",
				"template"
			};
			foreach (string str in plist) {
				ViewData.Add(str, Request.Form[str]);
			}
		}
		[AccessibleThrough(Verb.Post)]
		public void PhotoList() {
			string[] plist = {
				"Ownerid",
				"Albumid",
				"nowpage",
				"everypage",
				"template"
			};
			foreach (string str in plist) {
				ViewData.Add(str, Request.Form[str]);
			}
		}
		[AccessibleThrough(Verb.Post)]
		public void ChangeShowLevel() {
			Profile p = new Profile();
			System.Data.DataRow dr = p.ShowLevelList();
			if (dr != null)
				ViewData.Add("source", dr);
		}
		[AccessibleThrough(Verb.Post)]
		public void GroupManageChild(string template, long groupid) {
			Group g=new Group();
			ViewData.Add("groupid", groupid);
			switch (template.ToLower()) {
				case "setting":
					ViewData.Add("source", g.GroupSetting(groupid));
					break;
				case "member":
					System.Data.DataRowCollection drc=g.GroupMember(groupid,1);
					int right = 0;
					if (drc[0].Table.Select(string.Format("userid={0}", ChUser.Current.Userid)).Length > 0) {
						right = System.Convert.ToInt32(drc[0]["level"]);
					}
					if (ChUser.Current.isAdmin)
						right = 255;
					ViewData.Add("source", drc);
					ViewData.Add("right", right);
					if (right == 255)
						ViewData.Add("ApplyMasters",
							g.GroupMember(groupid, 3)
					);
					if (right > 199)
						ViewData.Add("ApplyMembers",
							g.GroupMember(groupid, 2)
					);
					ViewData.Add("Memberlist",
						g.GroupMember(groupid, 0, 1, 20)
					);
					break;
				default:

					break;
			}
		//	throw new Exception("Group" + template);
			RenderView("html", "Group" + template);

		}

		#region search
		[AccessibleThrough(Verb.Post)]
		public void SearchClass() { 
		
		}
		#endregion

		[AccessibleThrough(Verb.Post)]
		public void UserList(string template, int page, byte type) {
			//IDataBase idb = new DBExt(Session);
			ViewData["userSource"] = DBExt.UserListRows(ChUser.Current.Userid, page,type);

			RenderView("html", string.Format("UserList-{0}", template));
		}
		[AccessibleThrough(Verb.Post)]
		public void RssList(int count) {
			//IDataBase idb = new DBExt(Session);
			ViewData["userSource"] = DBExt.RssList(count);

			RenderView("html","Rss-List");
		}

#region reply
		[AccessibleThrough(Verb.Post)]
		public void Reply(long logid, string body, long Replyid, bool isReply, long Ownerid, byte type) {
			ChAlumna.Models.Comment cmt = new ChAlumna.Models.Comment()
			{
				body = ChServer.HtmlEncode(body).Replace("\n", "<br />"),
				addtime = DateTime.Now,
				senderid = ChUser.Current.Userid,
				IsReply = isReply,
				Logid = logid,
				type = type
			};
			bool IsonMyPage;
		
			#region 是否在自己页上以及谁是页面 的Owner
			if (isReply && (Replyid != 0)) {
				if (cmt.senderid == Ownerid) {
					cmt.ownerid = Replyid;
					IsonMyPage = true;
				} else {
					cmt.ownerid = Ownerid;
					IsonMyPage = false;
				}
			} else {
				cmt.ownerid = Ownerid;
				IsonMyPage = true;
			}
			#endregion
			#region 自回
			if (isReply && IsonMyPage && type == 0) {
				//INSERT INTO Comment
				// (Logid, ownerid, senderid, body,isreply)
				//VALUES    (@Logid, @senderid, @senderid, @body,@isreply)
				ChAlumna.Models.Comment cmt1 = new ChAlumna.Models.Comment()
				{
					body = ChServer.HtmlEncode(body).Replace("\n", "<br />"),
					addtime = DateTime.Now,
					senderid = ChUser.Current.Userid,
					ownerid = ChUser.Current.Userid,
					IsReply = isReply,
					Logid = logid,
					type = 0
				};
				DB.Comment.InsertOnSubmit(cmt1);
			}
			#endregion
			//INSERT INTO Comment
			//                      (Logid, ownerid, senderid, body,isreply,[type])
			//VALUES    (@Logid, @ownerid, @senderid, @body,@isreply,@type)
			DB.Comment.InsertOnSubmit(cmt);
			DB.SubmitChanges();
			#region Sql
			/*
			 * 	SELECT     Account.UserId,[Name], Comment.addtime, --University,
	Comment.body, Comment.id,Comment.IsDel,Comment.Ownerid
			 */			
			#endregion

			var comment=(from c in DB.Comment
				 join a in DB.Account on c.senderid equals a.userid
				 where c.trueid == cmt.trueid
				 select new
				 {
					 a.name,
					 c.addtime,
					 c.body,
					 c.id,
					 c.IsDel,
					 c.ownerid,
					 c.senderid,
					 a.email
				 }).ToList();//刚刚Insert的那个Comment

			ViewData["CommentRows"] = comment;
			ViewData["CommentType"] = cmt.type;

			var own = (from c in DB.Note
					   where (c.id == cmt.Logid)
					   select new
					   {
						   c.istellme
					   }).SingleOrDefault();
			if (own!=null && own.istellme == 1) {

				var cemail = comment.SingleOrDefault();
				if (cemail != null) {
					var item = (from l in DB.Note
								where l.id == cmt.Logid
								select new
								{
									l.title,
									cmt.body,
									name = ChUser.Current.Username,
									cmt.Logid,
									userid = ChUser.Current.Userid,
									l.GroupId
								}).SingleOrDefault();
					Dictionary dict = new Dictionary();
					dict.Add("item", item);
					Email.SystemSend(
						string.Format(
						"[{0}回复通知]re: {1}",
						SiteConfig.Currect.BaseConfig.Title,
						item.title
						),
						Template.TemplateEngine.ToString(dict, "mail/replyback.vm"),
						cemail.email,
						cemail.name
						);
				}
			}
			RenderView("Comment_Item");
		}
#endregion
	}
}

