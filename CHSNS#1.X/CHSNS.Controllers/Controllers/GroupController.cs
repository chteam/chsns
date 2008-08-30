	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using System.Linq;
	using CHSNS.Extension;
	using CHSNS.Filter;
	using Chsword;
	
	using CHSNS.Models;
	using CHSNS.Config;
	using CHSNS;
using System.Web.Mvc;
	namespace CHSNS.Controllers
{

	[LoginedFilter]
	public class GroupController : BaseController
	{
		public void index() {
			long Groupid = this.QueryLong("id");
			//ViewData.Add("Groupid", Groupid);
			ViewData.Add("nowpage", this.QueryNum("p") == 0 ? 1 : this.QueryNum("p"));

			Models.Group g = (from gr in DB.Group
					 where gr.ID == Groupid
					 && gr.IsTrue==true
					   select gr).FirstOrDefault();
			GroupUser u = (from gu in DB.GroupUser
					 where gu.UserID == CHSNSUser.Current.UserID
					 && gu.GroupID == Groupid
						   select gu).FirstOrDefault();
			if (g == null)
				return;
			var ret=8;//不允许任何操作
			ret = g.ShowLevel;
			if (u != null && u.IsTrue) {
				ret = 0;
			}
			if (CHSNSUser.Current.isAdmin) {
				ret = 0;
			}
			ViewData["right"] = ret;
			ViewData["group"] = g;
			ViewData["user"] = u;
			//var userlevel = 0;
			//if (ChUser.Current.isAdmin) {
			//    ret = 0;
			//    userlevel = 255;
			//} else {
			//    userlevel = u.Level
			//}

			//endlinq

			ViewData.Add("adminRows",
						(from gu in DB.GroupUser
						 join a in DB.Account on gu.UserID equals a.UserID
						 where gu.GroupID == Groupid
							&& gu.IsTrue == true
							 && gu.Level > 199
							 && gu.IsTrue == true
						 orderby gu.Level descending
						 select new
						 {
							 name = a.Name,
							 userid = gu.UserID,
							 level = gu.Level
						 }).ToList());
			//ViewData.Add("group", groupmodel);
			if (u != null )
			if (u.Level > 199 || CHSNSUser.Current.isAdmin) {
				ViewData.Add("ApplyMember", ApplyCount(Groupid, 0));
				ViewData.Add("ApplyMaster", ApplyCount(Groupid, 1));
			}
		}
		public void ClassList() {

			Dictionary dict = new Dictionary();
			dict.Add("@userid", CHSNSUser.Current.UserID);
			ViewData.Add("rows",DataBaseExecutor.GetRows(
				"GetRelationClass", dict));
		}
		public ActionResult List() {

			if (this.QueryNum("class") != 1) {
				ViewData.Add("Tabs", this.QueryNum("tabs"));
				return View();
			} else {
				if (SiteConfig.Current.BaseConfig.IsMustField && CHSNSUser.Current.Status < UserStatusType.IsApplyToField) {
					return Redirect("/ClassList.aspx");
				}
				Chsword.Reader.GroupList gl = new Chsword.Reader.GroupList();
				gl.Groupclass = 1;
				gl.Type = 2;
				gl.Userid = CHUser.UserID;
				if (this.QueryString("mode") == "auto")
					gl.Autotoclass = true;
				ViewData.Add("Items", gl.ShowPage(gl.GetGroupList()));
				//RenderView("MyClass");
				return View("MyClass");
			}
		}
		public void CreateClass() {
			Dictionary dict=new Dictionary();
			dict.Add("@userid",CHSNSUser.Current.UserID);
			DataRowCollection rows = DataBaseExecutor.GetRows(
				"SchoolInfo", dict);
			if (rows.Count != 0) {
				ViewData.Add("University", rows[0]["University"]);
				ViewData.Add("Xueyuan", rows[0]["XueYuan"]);
				ViewData.Add("Grade", rows[0]["Grade"]);
			}
		}
		public void Manage() {
			long Groupid = this.QueryLong("id");
			ViewData.Add("Groupid", Groupid);
			int i;
			switch (this.QueryString("mode")) {
				case "member":
					i = 1;
					break;
				case "photo":
					i = 2;
					break;
				case "disallow":
					i = 3;
					break;
				default://setting
					i = 0;
					break;
			}
			ViewData.Add("Tabs", i);

			SqlParameter[] p = new SqlParameter[] {
					new SqlParameter("@id", SqlDbType.BigInt),
					new SqlParameter("@userid", SqlDbType.BigInt)
				};
			p[0].Value = Groupid;
			p[1].Value = CHSNSUser.Current.UserID;
			DoDataBase dd = new DoDataBase();
			ViewData.Add("group", dd.DoDataSet("GroupSetting_Select", p).Tables[0].Rows);


		}
		int ApplyCount(long groupid, int type) {//0为加入的成员，1为申请管理员的人
			SqlParameter[] p = new SqlParameter[] {
					new SqlParameter("@groupid", SqlDbType.BigInt),
					new SqlParameter("@type", SqlDbType.TinyInt)
				};
			p[0].Value = groupid;
			p[1].Value = type;
			DoDataBase d = new DoDataBase();
			return int.Parse(d.DoParameterSql("GroupUser_ApplyCount", p));
		}

		public ActionResult ShowGroupList(string template,long Ownerid,
			int groupclass,int Npage,int Epage,int type) {
			return View(template, DataBaseExecutor.GetRows("GroupList",
				"@userid", Ownerid
				, "@page", Npage
				, "@everypage", Epage
				, "@GroupClass", groupclass
				, "@type", type
				));
		}
	}
}
