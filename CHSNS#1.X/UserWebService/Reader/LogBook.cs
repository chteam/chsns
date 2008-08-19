using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using ChAlumna;
namespace Chsword.Reader {
	/// <summary>
	/// 调用日志显示的页面
	/// </summary>
	public class LogBook : Databases {
		private String _Template;//调用的模板
		private long _ownerid=0;//拥有者的ID，只能为人，此类库程序与从前版本不同
		private long _viewerid = 0;//当前查看者的ID，如无意外 为Session[userid]
		private byte _type;//查询的模式
		private long _groupid = 0;//当前是哪个群，Groupid＝0时为个人日志
		private long _logid = 0;
		string _title;
//		int _ispost;
		
//		public int Ispost {
//			get { return _ispost; }
//		}
string _username;

public string Username {
	get { return _username; }
	set { _username = value; }
}
		
		public string Title {
			get { return _title; }
			set { _title = value; }
		}
		public long Ownerid {
			get { return _ownerid; }
			set { _ownerid = value; }
		}
		public long Viewerid {
			get { return _viewerid; }
			set { _viewerid=value; }
		}
		public long Logid {
			get { return _logid; }
			set { _logid = value; }
		}
		/// <summary>
		/// 当前是哪个群，Groupid＝0时为个人日志
		/// </summary>
		public long Groupid {
			get { return _groupid; }
			set { _groupid = value; }
		}
		public LogBook(string Template) {
			if (!string.IsNullOrEmpty(Template)) {
				_Template = Template;
			}
		}
		public LogBook(string Template,long ownerid) {
			if (!string.IsNullOrEmpty(Template)) {
				_Template = Template;
			}
			_ownerid = ownerid;
		}
		public LogBook(string Template,long ownerid,long viewerid){
			_viewerid=viewerid;
			_ownerid = ownerid;
			if (!string.IsNullOrEmpty(Template)) {
				_Template = Template;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="userid">ID段</param>
		/// <param name="nowpage">当前页码</param>
		/// <param name="c">查询类型</param>
		/// <returns></returns>
		public System.Data.DataTable GetLogBookTable(Int64 nowpage,byte c) {//1 0
			_type = c;
			DoDataBase dd = new DoDataBase();
			SqlParameter[] sp = new SqlParameter[6];
			sp[0] = new SqlParameter("@ownerid", SqlDbType.BigInt);
			sp[0].Value = _ownerid;
			sp[1] = new SqlParameter("@page", SqlDbType.BigInt);
			sp[1].Value = nowpage;
			sp[2] = new SqlParameter("@class", SqlDbType.TinyInt);
			sp[2].Value = c;
			sp[3] = new SqlParameter("@viewerid", SqlDbType.BigInt);
			sp[3].Value = _viewerid;
			sp[4] = new SqlParameter("@groupid", SqlDbType.BigInt);
			sp[4].Value = _groupid;
			sp[5] = new SqlParameter("@logid", SqlDbType.BigInt);
			sp[5].Value = _logid;
			DataTable dt=dd.DoDataTable("NoteList", sp);
			return dt;
		}
		//public string ShowAll(String Items, int NowPage) {
		//    StringBuilder master = new StringBuilder();
		//    master.Append(ChCache.GetTemplateCache(String.Format("{0}Master", _Template)));
		//    master.Replace("$Items$", Items);
		//    //master.Replace("$Count$", GetCount());
		//    //master.Replace("$NowPage$", NowPage.ToString());
		//    master.Replace("$Class$", _type.ToString());
		//    master.Replace("$Ownerid$", _ownerid.ToString());
		//    return master.ToString();
		//}
		public string ShowPage(System.Data.DataTable dt) {
			//Debug.Trace(dt.Rows.Count.ToString());
			if(dt.Rows.Count<1)
				return "";
			//Data.User ur = new Chsword.Data.User();//GetFace用
			StringBuilder all = new StringBuilder("");
			String item = ChCache.GetTemplateCache(_Template);
			StringBuilder temp;
			foreach (DataRow dr in dt.Rows) {
				temp = new StringBuilder(item.ToString());
				if (_type == 2||_type==4) { //有PUSH功能的
					temp.Replace("$Push$",
					             GetPushText(
					             	dr["isPush"],
					             	dr["id"].ToString(),
					             	dr["ispost"].ToString(),
					             	Convert.ToInt32(dr["mylevelingroup"])
					             )
					            );
				}
				temp.Replace("$Id$", dr["id"].ToString());
				temp.Replace("$Userid$", dr["Userid"].ToString());
				temp.Replace("$Username$", dr["Name"].ToString());
				temp.Replace("$Userface$", Path.GetFace(dr["Userid"].ToString(), ImgSize.small));
				
				temp.Replace("$CommentCount$", dr["CommentCount"].ToString());
				temp.Replace("$PushCount$", dr["PushCount"].ToString());
				temp.Replace("$ViewCount$", dr["ViewCount"].ToString());
				//DateTime dtime=DateTime.Parse(dr["AddTime"].ToString());
				temp.Replace("$AddTime$", Convert.ToDateTime(dr["AddTime"]).ToString("MM月dd日 HH:mm"));
				temp.Replace("$Title$", dr["Title"].ToString());
				_title=dr["Title"].ToString();
				
				if(_ownerid==0)
					_ownerid=Convert.ToInt64(dr["userid"]);
				_username=dr["name"].ToString();
				
				if(_type==4){//独立日志时
					if (_groupid==0){
						temp.Replace("$Groupright$", 
							ChCache.GetTemplateCache("GroupRight").Replace(
							String.Format("value=\"{0}\"", dr["ispost"]),
							String.Format("value=\"{0}\" selected=\"selected\"", dr["ispost"])
						));
						temp.Replace("$Back$",//返回群
						             string.Format(ChCache.GetConfig("Note","Noteback"),
						                           dr["Userid"],
						                           dr["Name"]
						                          )
						            );
					}
					else{
						temp.Replace("$Groupright$", "");
						temp.Replace("$Back$",//返回群
						             string.Format(ChCache.GetConfig("Note","Groupback"),
						                           _groupid.ToString()   ,
						                           dr["GroupName"]
						                          )
						            );
					}
				}
				temp.Replace("$Body$", GetSummary(dr["Body"].ToString()));
				if (_type != 1 &&_type != 0 &&_type != 2&&_type!=3){
					temp.Replace("$Edit$", GetEdit(dr["id"].ToString(), Convert.ToInt64(dr["Userid"].ToString())));
					temp.Replace("$Delete$", GetDelete(
						Convert.ToInt64(dr["userid"]), 
						Convert.ToInt32(dr["level"])
						)
						);
				}
				temp.Replace("$Back$","");
				all.Append(temp);
			}
			return all.ToString();
		}

		private string GetCount() {
			if (_type != 1 && _type != 0) {
				DoDataBase dd = new DoDataBase();
				SqlParameter[] sp = new SqlParameter[1]{
					new SqlParameter("@id", SqlDbType.BigInt)
				};
				sp[0].Value = _ownerid;
				return dd.DoParameterSql(String.Format("{0}Count", _Template), sp);
			} else
				return "0";
		}
		string GetSummary(string text) {
			if (_type == 0 || _type == 1) {
				string[] s = text.Split('<');
				return s[s.GetLowerBound(0)];
			} else return text;
		}


		string GetPushText(object IsPush,string Logid,string ispost,int mylevel_in_group) {
			if (_groupid==0){
				return string.Format(ChCache.GetConfig("Note","Push"),
				                     Convert.ToBoolean(IsPush)?ChCache.GetConfig("Note","Pushed"):
				                     string.Format(ChCache.GetConfig("Note","unPush"), Logid)
				                    );
			}else{//有群的时候显示置顶选择
				if(mylevel_in_group>199){//管理员操作列表 可置顶
					if(ispost=="1")
						return ChCache.GetConfig("Note","unTotop");
					else
						return ChCache.GetConfig("Note","Totop");
				}
				else//不可操作
					return"";
			}
		}
		string GetEdit(string id, long ownerid) {
			if (ownerid == _viewerid||ChSession.Status>199) {
				return ChCache.GetConfig("Note","Edit");//, temp);
			} else
				return "";
		}
		/// <summary>
		/// 得到“删除” 这个操作的代码
		/// </summary>
		/// <param name="Logid"></param>
		/// <returns></returns>
		private string GetDelete(long ownerid,int level) {
			if (ownerid == _viewerid||level>199||ChSession.Status>199) {
				return string.Format(ChCache.GetConfig("Note","Delete"), _logid, _groupid);
			}
			else
				return"";
		}
	}
}
