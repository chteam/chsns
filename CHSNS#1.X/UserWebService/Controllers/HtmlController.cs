

	using System.Text;
	using System;
	using System.Linq;
	using CHSNS.Data;
	using CHSNS.Config;
	using CHSNS;
	using System.Web.Mvc;
using System.Data;
namespace CHSNS.Controllers {
	
	//[Helper(typeof(PersonalHelper))]
	//[DefaultAction("Index")]
	public class HtmlController : BaseBlockController
	{
		[MvcContrib.Filters.PostOnly]
		public void index() { }
		[MvcContrib.Filters.PostOnly]
		public ActionResult ProfileEdit() {
			ViewData.Add("template", this.QueryString("template"));
			//this.RenderView("html", "ProfileEdit");
			return View();
		}
		[MvcContrib.Filters.PostOnly]
		public ActionResult PostList() {
			string[] plist = {
				"Groupid",
				"EveryPage",
				"nowpage",
				"template"
			};
			foreach (string str in plist) {
				ViewData.Add(str, Request.Form[str]);
			}
			return View();
		}
		[MvcContrib.Filters.PostOnly]
		public ActionResult PhotoList() {
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
			return View();
		}
		[MvcContrib.Filters.PostOnly]
		public ActionResult ChangeShowLevel() {
			Profile p = new Profile();
			DataRow dr = p.ShowLevelList();
			if (dr != null)
				ViewData.Add("source", dr);
			return View();
		}
		[MvcContrib.Filters.PostOnly]
		public ActionResult GroupManageChild(string template, long groupid) {
			Group g=new Group();
			ViewData.Add("groupid", groupid);
			switch (template.ToLower()) {
				case "setting":
					ViewData.Add("source", g.GroupSetting(groupid));
					break;
				case "member":
					DataRowCollection drc=g.GroupMember(groupid,1);
					int right = 0;
					if (drc[0].Table.Select(string.Format("userid={0}", ChUser.Current.Userid)).Length > 0) {
						right = Convert.ToInt32(drc[0]["level"]);
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
			//RenderView("html", "Group" + template);
			return View("Group" + template);

		}

		#region search
		[MvcContrib.Filters.PostOnly]
		public void SearchClass() { 
		
		}
		#endregion

		[MvcContrib.Filters.PostOnly]
		public ActionResult UserList(string template, int page, byte type) {
			//IDataBase idb = new DBExt(Session);
			ViewData["userSource"] = DBExt.UserListRows(ChUser.Current.Userid, page,type);

			//RenderView("html", string.Format("UserList-{0}", template));
			return View(string.Format("UserList-{0}", template));
		}
		[MvcContrib.Filters.PostOnly]
		public ActionResult RssList(int count) {
			//IDataBase idb = new DBExt(Session);
			ViewData["userSource"] = DBExt.RssList(count);

		//	RenderView("html","Rss-List");
			return View("Rss-List");
		}

#region reply
		[MvcContrib.Filters.PostOnly]
		public ActionResult Reply(long logid, string body, long Replyid, bool isReply, long Ownerid, byte type) {
			CHSNS.Models.Comment cmt = new CHSNS.Models.Comment()
			{
				body = ChServer.HtmlEncode(body).Replace("\n", "<br />"),
				addtime = DateTime.Now,
				senderid = ChUser.Current.Userid,
				IsReply = isReply,
				Logid = logid,
				type = type
			};
			bool IsonMyPage;
		
			#region �Ƿ����Լ�ҳ���Լ�˭��ҳ�� ��Owner
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
			#region �Ի�
			if (isReply && IsonMyPage && type == 0) {
				//INSERT INTO Comment
				// (Logid, ownerid, senderid, body,isreply)
				//VALUES    (@Logid, @senderid, @senderid, @body,@isreply)
				CHSNS.Models.Comment cmt1 = new CHSNS.Models.Comment()
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
				 }).ToList();//�ո�Insert���Ǹ�Comment

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
						"[{0}�ظ�֪ͨ]re: {1}",
						SiteConfig.Current.BaseConfig.Title,
						item.title
						),
						"",//Template.TemplateEngine.ToString(dict, "mail/replyback.vm"),
						cemail.email,
						cemail.name
						);
				}
			}
			//RenderView("Comment_Item");
			return View("Comment_Item");
		}
#endregion
	}
}
