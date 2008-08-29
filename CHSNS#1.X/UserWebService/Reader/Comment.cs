using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using CHSNS;

namespace Chsword.Reader {
	public class Comment : Databases {
		#region private
		long _nowpage=1;
		long _everypage=10;
		int _type = 0;//类型0为回复1为日志2相册,3为SuperNote
		long _Logid = 0;
		long _Viewerid = 0;//senderid
		long _Ownerid = 0;
		string _CountElement = "";//显示COUNT的ID标签
		DataTable _CommonRows =null;
		#endregion
		#region public
		public long Logid {
			get { return _Logid; }
			set { _Logid = value; }
		}
		public long Ownerid {
			get { return _Ownerid; }
			set { _Ownerid = value; }
		}
		public int Type {
			get { return _type; }
			set { _type = value; }
		}
		public long Viewerid {
			get { return _Viewerid; }
			set { _Viewerid = value; }
		}
		public string CountElement {
			get { return _CountElement; }
			set { _CountElement = value; }
		}
		public DataTable CommonRows {
			get { return _CommonRows; }
			set { _CommonRows = value; }
		}
		public long Nowpage {
			get { return _nowpage; }
			set { _nowpage = value; }
		}
		public long Everypage {
			get { return _everypage; }
			set { _everypage = value; }
		}
		#endregion
		//bool _IsReply = true;//留言为true 日志的回复为false
		#region get Reply list
		public void GetReplyList() {
			SqlParameter[] sp = new SqlParameter[5]{
				new SqlParameter("@ownerid", SqlDbType.BigInt),
				new SqlParameter("@page", SqlDbType.BigInt),
				new SqlParameter("@everyPage", SqlDbType.BigInt),
				new SqlParameter("@type", SqlDbType.TinyInt),
				new SqlParameter("@logid", SqlDbType.BigInt)
			};
			sp[0].Value = Ownerid;
			sp[1].Value = Nowpage;
			sp[2].Value = Everypage;
			sp[3].Value = Type;
			sp[4].Value = Logid;
			DoDataBase db = new DoDataBase();
			CommonRows = db.DoDataSet("CommentSelect", sp).Tables[0];
		}
		#endregion
		
		public string ShowPage() {
			//Data.User ur = new Chsword.Data.User();
			StringBuilder all = new StringBuilder("");
			StringBuilder temp;
			string _Ownerid;
			foreach (DataRow dr in  CommonRows.Rows) {
				temp = new StringBuilder(CHCache.GetTemplateCache("ReplyList"));
				_Ownerid = dr["Ownerid"].ToString();
				bool isViewer = (dr["Userid"].ToString().Equals(_Viewerid.ToString()));
				if (!isViewer) {
					temp.Replace("$Reply$", CHCache.GetConfig("Comment","ReplyList_ReplyButton"));
				}
				//本人的帖子或本人的回复时
				if ((this.Ownerid == this.Viewerid|| this.Viewerid.Equals(dr["Ownerid"]))
				    && !this.Viewerid.Equals(dr["Userid"]) && !true.Equals(dr["issee"])) {
					temp.Replace("$Ctrl$", CHCache.GetConfig("Comment", "ReplyList_SeeButton"));
				}

				if (dr["IsDel"].Equals(false))
					if (_Viewerid.ToString() == _Ownerid || isViewer) {
					temp.Replace("$Ctrl$", CHCache.GetConfig("Comment","ReplyList_RemoveButton"));
					if (!isViewer) {
						temp.Replace("$Div$", CHCache.GetConfig("Div"));
					}
				}
				temp.Replace("$Reply$", "");
				temp.Replace("$Div$", "");
				temp.Replace("$Ctrl$", "");
				temp.Replace("$Userid$", dr["Userid"].ToString());
				temp.Replace("$Id$",dr["id"].ToString());

				temp.Replace("$Username$", dr["Name"].ToString());
				temp.Replace("$Userface$", Path.GetFace(dr["Userid"].ToString(),ImgSizeType.Small));
				
				temp.Replace("$Time$", Convert.ToDateTime(dr["addtime"]).ToString("MM-dd HH:mm"));
				if (dr["IsDel"].Equals(false))
					temp.Replace("$Body$", ShowHtml(dr["Body"].ToString()));
				else
					temp.Replace("$Body$", "已经删除。");
				if (_type == 0) {
					temp.Replace("$Class$", "list");
					//temp.Replace("$University$", String.Format("({0})", dt.Rows[i]["University"].ToString()));
				} else {
					if(CommonRows.Columns.Contains("RowNo")){
						if (Convert.ToInt32(dr["RowNo"]) % 2 == 0) {
							temp.Replace("$Class$", "even");
						} else {
							temp.Replace("$Class$", "odd");
						}
					}
				}
				temp.Replace("$University$", "");
				if (_type == 1) {
					if(CommonRows.Columns.Contains("RowNo"))
						temp.Replace("$Sort$", String.Format("{0}楼", dr["RowNo"].ToString()));
				} else {
					temp.Replace("$Sort$", "");
				}
				all.Append(temp);
			}
			return all.ToString();
		}
		private string GetCount() {
			DoDataBase dd = new DoDataBase();
			SqlParameter[] sp = new SqlParameter[2];
			sp[0] = new SqlParameter("@id", SqlDbType.BigInt);
			sp[0].Value = _Ownerid;
			sp[1] = new SqlParameter("@type", SqlDbType.TinyInt );
			sp[1].Value = _type;
			return dd.DoParameterSql("CommentCount", sp);
		}

		public string ShowAll(String Items, int NowPage) {
			StringBuilder master = new StringBuilder();
			master.Append(CHCache.GetTemplateCache("ReplyListMaster"));
			master.Replace("$Items$", Items);
			master.Replace("$Count$", GetCount());
			master.Replace("$NowPage$", _nowpage.ToString());
			master.Replace("$EveryPage$", _everypage.ToString());
			if (Type!=1){
				master.Replace("$CountId$", _CountElement);
			}else{
				master.Replace("$CountId$", "");
			}
			
			master.Replace("$ZhuShi$", string.IsNullOrEmpty(_CountElement) ? "//" : "");
			master.Replace("$Ownerid$", HttpContext.Current.Session["userid"].ToString());
			return master.ToString();
		}
	}
}

