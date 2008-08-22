using System;
using System.Data;
using System.Web;
using System.Text;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using Chsword.Datamodel;
using Chsword.Execute;
using Chsword;
using CHSNS.Reader;
using CHSNS.Models;
using CHSNS.Data;
using CHSNS;
namespace CHSNS {
	/// <summary>
	/// NoteBook 的摘要说明
	/// </summary>
	[WebService(Namespace = "http://5field.com/", Description = "记事本中内容列表")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService()]
	public class NoteBook : WebService {
		//[WebMethod(EnableSession=true)]
		#region 浏览日志部分代码
		/// <summary>
		/// 显示浏览日志中的年月列表
		/// </summary>
		/// <param name="userid">要查看的用户的ID</param>
		/// <returns></returns>
		[WebMethod(Description="显示浏览日志中的年月列表",EnableSession=true)]
		public string GetHistoryPage(long userid) {
			StringBuilder sbout = new StringBuilder(ChCache.GetTemplateCache("NoteBookHistory"));
			#region 档案列表
			DataTable dt = HistoryTable(userid);
			foreach (DataRow dr in dt.Rows) {
				sbout.Replace("$Historylist$",
				              string.Format("<li><a href=\"javascript:CurrentList({0},{1})\">{0}年{1}月 ({2})</a></li>$Historylist$",
				                            dr["year"].ToString(), dr["month"].ToString().PadLeft(2,' '), dr["Counter"].ToString()));
			}
			sbout.Replace("$Historylist$", "");
			#endregion
			#region 档案Summary列表
			if (dt.Rows.Count > 0) {
				int year = Convert.ToInt32(dt.Rows[0]["year"]);
				int month = Convert.ToInt32(dt.Rows[0]["month"]);
				sbout.Replace("$Summarylistname$", String.Format("{0}年{1}月", year, month));
				DataTable st = SummaryTable(userid, year, month);
				foreach (DataRow dr in st.Rows) {
					sbout.Replace("$Summarylist$",
					              string.Format(ChCache.GetTemplateCache("Note"),
					                            Convert.ToDateTime(dr["AddTime"]).ToString("MM月dd日"),
					                            Convert.ToDateTime(dr["AddTime"]).ToString("yyyy-MM-dd HH:mm"),
					                            dr["id"].ToString(),
					                            dr["title"].ToString(),
					                            Regular.NoHtml(dr["body"].ToString()),
					                            dr["ViewCount"].ToString(),
					                            dr["CommentCount"].ToString(), dr["PushCount"].ToString()
					                           ));
				}
				sbout.Replace("$Summarylist$", "");
			} else {
				if(userid==CHUser.UserID){
					sbout.Replace("$Summarylist$", ChCache.GetConfig("Note","None_MyNote"));
				}
				else{
					sbout.Replace("$Summarylist$", ChCache.GetConfig("Note","None_MyNote_Other"));
				}
			}
			sbout.Replace("$Summarylistname$", "");
			#endregion
			return sbout.ToString();
		}
		DataTable HistoryTable(long userid) {
			SqlParameter[] sp = new SqlParameter[1] {
				new SqlParameter("@UserId", SqlDbType.BigInt)
			};
			sp[0].Value = userid;
			DoDataBase db = new DoDataBase();
			return db.DoDataSet("NoteList_Month", sp).Tables[0];
		}
		[WebMethod(Description="显示具体年月的日志记录")]
		public DataTable SummaryTable(long userid,int year,int month) {
			SqlParameter[] sp = new SqlParameter[3] {
				new SqlParameter("@UserId", SqlDbType.BigInt),
				new SqlParameter("@year", SqlDbType.Int),
				new SqlParameter("@month", SqlDbType.TinyInt)
			};
			sp[0].Value = userid;
			sp[1].Value = year;
			sp[2].Value = month;
			DoDataBase db = new DoDataBase();
			return db.DoDataSet("NoteSummary_Month", sp).Tables[0];
		}
		#endregion
		#region 评论及评论分页部分代码
		[WebMethod(Description = "显示日志评论,带分页")]
		public string GetCommentPage(long userid) {
			StringBuilder sbout = new StringBuilder(ChCache.GetTemplateCache("NoteBookComment"));
			DataTable dt = CommentTable(userid,1,10);
			foreach (DataRow dr in dt.Rows) {
				sbout.Replace("$Commentlist$",
				              string.Format(ChCache.GetTemplateCache("NoteBookCommentItem"),

				                            Convert.ToDateTime(dr["AddTime"]).ToString("MM-dd HH:mm"),
				                            dr["senderid"].ToString(),
				                            dr["name"].ToString(),
				                            dr["body"].ToString(),
				                            dr["title"].ToString(),
				                            dr["logid"].ToString()
				                           ));
			}
			sbout.Replace("$Commentlist$", "");
			sbout.Replace("$Count$", CommentCount(userid).ToString());
			return sbout.ToString();
		}

		[WebMethod(Description = "得到评论列表")]
		public DataTable CommentTable(long userid, int nowpage, int everypage) {
			SqlParameter[] sp = new SqlParameter[3] {
				new SqlParameter("@UserId", SqlDbType.BigInt)				,
				new SqlParameter("@page", SqlDbType.BigInt)				,
				new SqlParameter("@everypage", SqlDbType.BigInt)
			};
			sp[0].Value = userid;
			sp[1].Value = nowpage;
			sp[2].Value = everypage;
			DoDataBase db = new DoDataBase();
			return db.DoDataSet("Note_Comment", sp).Tables[0];
		}
		long CommentCount(long userid) {
			SqlParameter[] sp = new SqlParameter[2] {
				new SqlParameter("@UserId", SqlDbType.BigInt)				,
				new SqlParameter("@type", SqlDbType.BigInt)
			};
			sp[0].Value = userid;
			sp[1].Value = 1;
			DoDataBase db = new DoDataBase();
			return Convert.ToInt64(db.DoDataSet("Note_Comment", sp).Tables[0].Rows[0]["counter"]);
		}

		#endregion
		#region 最新日志
		[WebMethod(EnableSession=true)]
		public DataTable LastNoteTable(){
			Chsword.Reader.LogBook ul = new Chsword.Reader.LogBook("LogBook", 0, CHUser.UserID);
			return 	ul.GetLogBookTable(1,0);
		}
		#endregion
		#region 推荐日志
		[WebMethod(EnableSession=true)]
		public DataTable PushNoteTable(){
			Chsword.Reader.LogBook ul = new Chsword.Reader.LogBook("LogBook", 0, CHUser.UserID);
			return 	ul.GetLogBookTable(1,1);
		}
		#endregion
		
		#region 群置顶操作
		[WebMethod(Description="将帖子置顶",EnableSession=true)]
		public bool Note_Top(long logid,long groupid) {
			return Note_top_executer(logid,groupid,CHUser.UserID,1);
		}
		[WebMethod(Description="取消帖子置顶",EnableSession=true)]
		public bool Note_unTop(long logid,long groupid) {
			return Note_top_executer(logid,groupid,CHUser.UserID,0);
		}
		bool Note_top_executer(long logid,long groupid,long userid,byte ispost){
			SqlParameter[] sp = new SqlParameter[4] {
				new SqlParameter("@logid", SqlDbType.BigInt),
				new SqlParameter("@groupid", SqlDbType.BigInt),
				new SqlParameter("@executerid", SqlDbType.BigInt),
				new SqlParameter("@ispost", SqlDbType.TinyInt)
			};
			sp[0].Value = logid;
			sp[1].Value = groupid;
			sp[2].Value = userid;
			sp[3].Value = ispost;
			DoDataBase db = new DoDataBase();
			return (db.DoParameterSql("Note_top", sp)!="0");
		}
		#endregion
		
		#region 发表及编辑日志或帖子
		[WebMethod(Description = "发表日志", EnableSession = true)]
		public long Note_Add(long groupid, string title, string body, byte showlevel, bool istellme, string tags) {
			Note n = new Note();
			n.GroupId = groupid;
			n.title = title;
			n.body = body;
			n.IsPost = showlevel;
			n.istellme = (byte)(istellme ? 1 : 0);

			DBExt idb = new DBExt(new Dictionary());
			idb.Note_Add(n);

			idb.NoteTags_Add(n.id, tags);

			return n.id;
		}
		[WebMethod(Description="编辑日志",EnableSession=true)]
		public void Note_Edit(long groupid,long logid,string body ,byte showlevel,bool istellme,string tags) {
			Note n = new Note();
			n.GroupId = groupid;
			n.id = logid;
			n.body = body;
			n.IsPost = showlevel;
			n.istellme = (byte)(istellme ? 1 : 0);
			DBExt idb = new DBExt(new Dictionary());
			idb.Note_Edit(n);
			idb.NoteTags_Change(n.id, tags);
		}
		[WebMethod(Description = "删除日志", EnableSession = true)]
		public void Note_Delete(long logid,long groupid) {
			DBExt idb = new DBExt(new Dictionary());
			idb.NoteTags_Delete(logid);
			idb.Note_Remove(logid, groupid);
		}
		[WebMethod(Description = "推荐日志", EnableSession = true)]
		public string Note_Push(long logid) {
			DBExt idb = new DBExt(new Dictionary());
			int b = idb.Note_Push(logid);
			switch (b) {
				case 1:
					return string.Empty;
				case 2:
					return Debug.TraceBack("非发布日志不能推荐.");
				case 3:
					return Debug.TraceBack("您已经推荐过了.");
				default:
					return Debug.TraceBack("Update2 unknow error.");
			}
		}
		#endregion

		#region SuperNote
		[WebMethod(Description = "删除日志", EnableSession = true)]
		public bool SuperNote_Remove(long id) {
			SqlParameter[] p = new SqlParameter[3] { 
				new SqlParameter("@id", SqlDbType.BigInt),
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@viewerstatus", SqlDbType.TinyInt)
			};
			p[0].Value = id;
			p[1].Value = CHUser.UserID;
			p[2].Value = CHUser.Status;
			DoDataBase dd = new DoDataBase();
			dd.ExecuteSql("SuperNote_Remove", p);
			return true;
		}
		[WebMethod(Description = "查看日志", EnableSession = true)]
		public string SuperNote_See(long id,byte type) {
			if(CHUser.UserID==0){
				return "";
			}
			SqlParameter[] p = new SqlParameter[2] { 
				new SqlParameter("@id", SqlDbType.BigInt),
				new SqlParameter("@type", SqlDbType.TinyInt)
			};
			p[0].Value = id;
			p[1].Value = type;
			DoDataBase dd = new DoDataBase();
			dd.DoDataSet("SuperNote_Update", p);
			if (type != 1) {
				return "";
			}
			SuperNoteList list = new SuperNoteList();
			list.Everypage = 10;
			list.Nowpage = 1;
			return list.GetNewListString();
		}
		[WebMethod(Description = "发表日志", EnableSession = true)]
		public bool SuperNote_Add(string url, string title,byte showlevel,long systemcategory) {
			if (!url.ToLower().StartsWith("http://"))
				return false;
			object faceurl;
			string[] picandtit = Media.GetMediaPic(url);
			if (picandtit.Length == 0) {
				faceurl = System.DBNull.Value;
			} else {
				faceurl = picandtit[0];
			}
			SqlParameter[] p = new SqlParameter[8] {
				new SqlParameter("@url", SqlDbType.NVarChar,500),
				new SqlParameter("@description", SqlDbType.NVarChar,50),
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@faceurl", SqlDbType.NVarChar,500),
				new SqlParameter("@title", SqlDbType.NVarChar,50),
				new SqlParameter("@showlevel", SqlDbType.TinyInt),
				new SqlParameter("@systemcategory", SqlDbType.BigInt),
				new SqlParameter("@category", SqlDbType.BigInt)
			};
			p[0].Value = url;
			p[1].Value = System.DBNull.Value;
			p[2].Value = CHUser.UserID;
			p[3].Value = faceurl;
			p[4].Value = title;
			p[5].Value =showlevel;
			p[6].Value = ChParameter.canNull(systemcategory);
			p[7].Value = DBNull.Value;
			DoDataBase dd = new DoDataBase();
			dd.ExecuteSql("SuperNote_Add", p);
			return true;
		}
		[WebMethod(EnableSession = true)]
		public DataTable SuperNote_List(int page,long userid) {
			SuperNoteList snl = new SuperNoteList();
			snl.Everypage = 10;
			snl.Nowpage = page;
			snl.Userid = userid == 0 ? CHUser.UserID : userid;
			return snl.GetSuperListTable();
		}
		[WebMethod(EnableSession = true)]
		public String SuperNote_ListString(int page,long userid) {
			SuperNoteList snl = new SuperNoteList();
			snl.Everypage = 10;
			snl.Nowpage = page;
			snl.Userid = userid == 0 ? CHUser.UserID : userid;
			snl.Template="supernotepage";
			return snl.GetSuperListString();
		}
		[WebMethod(EnableSession = true)]
		public String SuperNoteRandom_Category(long category) {
			SuperNoteList snl=new SuperNoteList();
			snl.Everypage=10;
			snl.Nowpage=1;
			snl.Template = "supernoterandompage";
			snl.Type=1;
			snl.Userid = CHUser.UserID;
			snl.SysCategory = category;
			return snl.GetSuperListString();
		}
		#endregion
	}
}
