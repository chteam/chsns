namespace ChAlumna.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using System.Linq;
	using Chsword;
	using Castle.MonoRail.Framework;
	using ChAlumna.Models;
	using ChAlumna.Config;
	using CHSNS;
	[Filter(ExecuteEnum.BeforeAction, typeof(LoginedFilter))]
	public class GroupController : BaseController
	{
		public void index() {
			long Groupid = QueryLong("id");
			//ViewData.Add("Groupid", Groupid);
			ViewData.Add("nowpage", QueryNum("p") == 0 ? 1 : QueryNum("p"));

			Group g = (from gr in DB.Group
					 where gr.id == Groupid
					 && gr.IsTrue==true
					   select gr).FirstOrDefault();
			GroupUser u = (from gu in DB.GroupUser
					 where gu.userid == ChUser.Current.Userid
					 && gu.Groupid == Groupid
						   select gu).FirstOrDefault();
			if (g == null)
				return;
			var ret=8;//不允许任何操作
			ret = g.ShowLevel;
			if (u != null && u.IsTrue) {
				ret = 0;
			}
			if (ChUser.Current.isAdmin) {
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
						 join a in DB.Account on gu.userid equals a.userid
						 where gu.Groupid == Groupid
							&& gu.IsTrue == true
							 && gu.Level > 199
							 && gu.IsTrue == true
						 orderby gu.Level descending
						 select new
						 {
							 name = a.name,
							 userid = gu.userid,
							 level = gu.Level
						 }).ToList());
			//ViewData.Add("group", groupmodel);
			if (u != null )
			if (u.Level > 199 || ChUser.Current.isAdmin) {
				ViewData.Add("ApplyMember", ApplyCount(Groupid, 0));
				ViewData.Add("ApplyMaster", ApplyCount(Groupid, 1));
			}
		}
		public void ClassList() {

			Dictionary dict = new Dictionary();
			dict.Add("@userid", ChUser.Current.Userid);
			ViewData.Add("rows",DataBaseExecutor.GetRows(
				"GetRelationClass", dict));
		}
		public void List() {

			if (QueryNum("class") != 1) {
				ViewData.Add("Tabs", QueryNum("tabs"));
			} else {
				if (SiteConfig.Currect.BaseConfig.IsMustField && ChUser.Current.Status < UserStatusType.IsApplyToField) {
					Redirect("/ClassList.aspx");
				}
				Chsword.Reader.GroupList gl = new Chsword.Reader.GroupList();
				gl.Groupclass = 1;
				gl.Type = 2;
				gl.Userid = ChSession.Userid;
				if (QueryString("mode") == "auto")
					gl.Autotoclass = true;
				ViewData.Add("Items", gl.ShowPage(gl.GetGroupList()));
				RenderView("MyClass");
			}
		}
		public void CreateClass() {
			Dictionary dict=new Dictionary();
			dict.Add("@userid",ChUser.Current.Userid);
			DataRowCollection rows = DataBaseExecutor.GetRows(
				"SchoolInfo", dict);
			if (rows.Count != 0) {
				ViewData.Add("University", rows[0]["University"]);
				ViewData.Add("Xueyuan", rows[0]["XueYuan"]);
				ViewData.Add("Grade", rows[0]["Grade"]);
			}
		}

		public void Manage() {
			long Groupid = QueryLong("id");
			ViewData.Add("Groupid", Groupid);
			int i;
			switch (QueryString("mode")) {
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
			p[1].Value = ChUser.Current.Userid;
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
	}
}
