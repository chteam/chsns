
namespace Chsword.Reader{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Data;
	using System.Data.SqlClient;
	using Chsword.Interface;
	using CHSNS;
	public class Message : Databases,IPageSet,IServerResponseable {
		//long _userid;
		int _Nowpage;
		int _Everypage;
		long _Userid;
		PageType _type;

		#region IServerResponseable 成员

		public ServerResponse GetServerResponse() {
			StringBuilder sbout = new StringBuilder(CHCache.GetTemplateCache("MessageList"));
			DataTable dt = GetTable();
			//StringBuilder item = new StringBuilder(GetTemplate("MessageListItems"));
			foreach (DataRow dr in dt.Rows) {
				sbout.Replace("$MessageListItem$", CHCache.GetTemplateCache("MessageListItem"));
				sbout.Replace("$Isread.gif$", dr["issee"].Equals(true) ? "read.gif" : "unread.gif");
				sbout.Replace("$Isread$", dr["issee"].Equals(true) ? "已读" : "未读");
				sbout.Replace("$Messageid$", dr["id"].ToString());
				sbout.Replace("$Userid$", dr["userid"].ToString());
				sbout.Replace("$Username$", dr["name"].ToString());
				sbout.Replace("$Title$", dr["Title"].ToString());
				sbout.Replace("$Addtime$", Convert.ToDateTime(dr["Sendtime"]).ToString("MM-dd HH:mm"));
			}
			if (dt.Rows.Count == 0)
				sbout.Replace("$MessageListItem$", "列表为空");
			
			
			if (_type==PageType.Inbox){
				sbout.Replace("$cnMan$", "发条人");
				sbout.Replace("$isSend$", "Inbox");
			}else{
				sbout.Replace("$cnMan$", "收条人");
				sbout.Replace("$isSend$", "Send");
			}
			sbout.Replace("$MessageListItem$", string.Empty);
			ServerResponse sr = new ServerResponse();
			sr.ResponseText = sbout.ToString();
			sr.Count = GetCount().Rows[0]["Counter"].ToString();
			return sr;
		}

		#endregion

		DataTable GetCount() {
			switch (_type) {
				case PageType.Inbox:
				case PageType.Sent:
					SqlParameter[] sp = new SqlParameter[2] { 
						new SqlParameter("@UserId", SqlDbType.BigInt),
						new SqlParameter("@type", SqlDbType.TinyInt),
					};
					sp[0].Value = _Userid;
					sp[1].Value = GetResponseType();
					DoDataBase db = new DoDataBase();
					return db.DoDataSet("Message_Count", sp).Tables[0];
				default:
					throw new Exception(Debug.TraceBack("非法类型传入"));
			}
		}
		DataTable GetTable() {
			switch (_type) {
				case PageType.Inbox:
				case PageType.Sent:
					SqlParameter[] sp = new SqlParameter[4] { 
						new SqlParameter("@UserId", SqlDbType.BigInt),
						new SqlParameter("@page", SqlDbType.BigInt),
						new SqlParameter("@everypage", SqlDbType.BigInt),
						new SqlParameter("@type", SqlDbType.TinyInt),
					};
					sp[0].Value = _Userid;
					sp[1].Value = _Nowpage;
					sp[2].Value = _Everypage;
					sp[3].Value = GetResponseType();
					DoDataBase db = new DoDataBase();
					return db.DoDataSet("Message_List", sp).Tables[0];
				default:
					throw new Exception(Debug.TraceBack("非法类型传入"));
			}

		}

		#region IPageSet 成员
		public int Everypage {
			get {
				return _Everypage;
			}
			set {
				_Everypage = value;
			}
		}


		public bool Isinboxer {
			get {
				return _isinboxer;
			}
			set {
				_isinboxer = value;
			}
		}
		public long Messageid {
			get {
				return _messageid;
			}
			set {
				_messageid = value;
			}
		}
		public int Nowpage {
			get {
				return _Nowpage;
			}
			set {
				_Nowpage = value;
			}
		}
		public PageType Type {
			get {
				return _type;
			}
			set {
				_type = value;
			}
		}
		public long Userid {
			get {
				return _Userid;
			}
			set {
				_Userid = value;
			}
		}
		#endregion
		int GetResponseType() {
			if (_type == PageType.Inbox) return 0;
			else return 1;
		}

		long _messageid;
		bool _isinboxer;
		public Datamodel.MessageModel GetSingle() {
			SqlParameter[] sp = new SqlParameter[3]{ 
				new SqlParameter("@messageid", SqlDbType.BigInt),
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@type", SqlDbType.TinyInt)
			};
			sp[0].Value = _messageid;
			sp[1].Value = _Userid;
			sp[2].Value = _isinboxer ? 0 : 1;//是不是收件箱中读
			DoDataBase db = new DoDataBase();
			DataTable dt = db.DoDataSet("Message_Read", sp).Tables[0];
			if (dt.Rows.Count < 1) throw new Exception(Debug.TraceBack("Message.GetSingle中意外的输出"));
			Datamodel.MessageModel mm = new Chsword.Datamodel.MessageModel();
			mm.Messageid = Convert.ToInt64(dt.Rows[0]["id"]);
			mm.Toid = Convert.ToInt64(dt.Rows[0]["Userid"]);
			mm.Name = dt.Rows[0]["Name"].ToString();
			mm.Title = dt.Rows[0]["Title"].ToString();
			mm.Body = dt.Rows[0]["Body"].ToString();
			mm.Sendtime = Convert.ToDateTime(dt.Rows[0]["SendTime"]);
			mm.Ishtml = Convert.ToBoolean(dt.Rows[0]["IsHtml"]);
			//Message.ToId AS userid, [User].Name, 
			//Message.Title, Message.Body, Message.SendTime,Message.IsHtml
			return mm;
		}
	}
}
