using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Chsword;

namespace CHSNS.Reader {
	public class SuperNoteList : Chsword.Reader.Databases,Chsword.Interface.IPageSet {
		#region 私有成员
		long _userid;
		byte _type;
		string _username=null;
		string _template;
		long _syscategory=0;

		public long SysCategory {
			get { return _syscategory; }
			set { _syscategory = value; }
		}
		public string Template {
			get { return _template; }
			set { _template = value; }
		}
		public string Username {
			get { return _username; }
			set {
				if (_username == null)
					_username = value;
			}
		}
		public byte Type {
			get { return _type; }
			set { _type = value; }
		}
		public long Userid {
			get { return _userid; }
			set { _userid = value; }
		}
		int _nowpage = 1;
		int _everypage = 20;
		#endregion
		#region IPageSet 成员
		public int Nowpage {
			get { return _nowpage; }
			set { _nowpage = value; }
		}
		public int Everypage {
			get { return _everypage; }
			set { _everypage = value; }
		}
		#endregion
		public StringBuilder CreateUserSuperNote() {
			StringBuilder sb =new StringBuilder(CHCache.GetTemplateCache(Template));
			sb.Replace("$SuperNoteList$", GetSuperListString());
			sb.Replace("$Username$", Username);
			sb.Replace("$Count$", GetSuperListCount());
			sb.Replace("$Ownerid$", Userid.ToString());
			sb.Replace("$Showlevel$",CHCache.GetTemplateCache("ShowLevel").Replace("$Id$","f_showlevel"));
			if (Type == 0) {//supernotepage
				sb.Replace("$systemcategory$", DataSetCache.SuperCategory_List());
				sb.Replace("$systemcategorylist$", SuperCategorylist());
			}
			if (Type == 1) {//supernoterandompage
				sb.Replace("$Newlist$",GetNewListString());
				sb.Replace("$systemcategorylist$", SuperCategorylist());
			}
			sb.Replace("$Newlist$","");
			return sb;
		}

		private string SuperCategorylist() {
			StringBuilder sbout = new StringBuilder();
			foreach (DataRow dr in DataSetCache.SuperCategory_DataTable().Rows) {
				sbout.AppendFormat(CHCache.GetConfig("Note", "Super_systemcategory"),
					dr["id"], dr["name"],dr["count"]);
			}
			return sbout.ToString();
		}
		#region 读取数据库
		string getTitle(object o){
			if(string.IsNullOrEmpty(o.ToString())){
				return CHCache.GetConfig("Note","SuperNone_NoTitle");
			}
			return o.ToString();	
		}
		string getPic(object o){
			if(string.IsNullOrEmpty(o.ToString())){
				return CHCache.GetConfig("Note","SuperNone_NoPic");
			}
			return o.ToString();
		}
		string getTime(object o){
			return Convert.ToDateTime(o).ToString("MM-dd HH:mm");
		}
		public String GetNewListString(){
			StringBuilder sbin = new StringBuilder();
			foreach (DataRow dr in GetSuperListTable(2).Rows) {
				sbin.AppendFormat(CHCache.GetConfig("Note","Super_New"),
					getTitle(dr["title"]),
					dr["userid"],
					dr["id"]
			);
			}
			return sbin.ToString();
		}
		public String GetSuperListString() {
			StringBuilder sbin = new StringBuilder();
			foreach (DataRow dr in GetSuperListTable().Rows) {
				DataRow[] drq =DataSetCache.SuperCategory_DataTable().Select("id="+dr["systemcategory"].ToString());
				sbin.AppendFormat(CHCache.GetTemplateCache("SuperNoteItem"),
					dr["id"],
					dr["viewcount"],
					dr["url"],
					"",
					getTime(dr["addtime"]),
					getTitle(dr["title"]),
					getPic(dr["faceurl"]),
					(!Template.ToLower().Equals("supernoterandompage")&&(CHUser.UserID.Equals(dr["userid"])||CHUser.Status>199))?
					String.Format(CHCache.GetConfig("Note","SuperNone_Delete"),dr["id"]):"",
					(Type==1)?string.Format(CHCache.GetConfig("UserLink"),dr["userid"],dr["name"]):"",
					drq.Length>0?drq[0]["name"]:""
			);
				this.Username = dr["name"].ToString();
			}
			if (string.IsNullOrEmpty(Username)) {
				if (Userid == CHUser.UserID) {
					Username = CHUser.Username;
				} else {
					//Identity identity = new Identity();
					//Username = identity.GetUserName(Userid);
				}
			}
			return sbin.ToString();
		}
		DataTable GetSuperListTable(byte type) {
			SqlParameter[] p = new SqlParameter[7] { 
				new SqlParameter("@ownerid", System.Data.SqlDbType.BigInt),
				new SqlParameter("@page", System.Data.SqlDbType.Int),
				new SqlParameter("@everyPage", System.Data.SqlDbType.Int),
				new SqlParameter("@type", System.Data.SqlDbType.TinyInt),
				new SqlParameter("@viewerid", System.Data.SqlDbType.BigInt),
				new SqlParameter("@viewerStatus", System.Data.SqlDbType.TinyInt),
				new SqlParameter("@systemcategory", System.Data.SqlDbType.BigInt)
			};
			p[0].Value = Userid;
			p[1].Value = Nowpage;
			p[2].Value = Everypage;
			p[3].Value = type;
			p[4].Value = CHUser.UserID;
			p[5].Value= CHUser.Status;
			p[6].Value = ChParameter.canNull(SysCategory);
			DoDataBase dd = new DoDataBase();
			return dd.DoDataSet("SuperNote_List", p).Tables[0];
		}
		public DataTable GetSuperListTable() {
			return GetSuperListTable(Type);
		}
		public string GetSuperListCount() {
			SqlParameter[] p = new SqlParameter[2] { 
				new SqlParameter("@Userid", System.Data.SqlDbType.BigInt),
				new SqlParameter("@type", System.Data.SqlDbType.TinyInt)
			};
			p[0].Value = Userid;
			p[1].Value = Type;
			DoDataBase dd = new DoDataBase();
			return dd.DoDataSet("SuperNote_Count", p).Tables[0].Rows[0][0].ToString();

		}
		#endregion
	}
}
