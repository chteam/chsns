using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using CHSNS;
namespace Chsword.Reader {
	public class UserList : Databases {
		private String _Template;
		long _Viewerid=0;
		long _Ownerid=0;
		private Int64 _id;
		private byte _type;
		//DataRow _UserDataRow=null;
		public UserList(){}
		#region Userid
		public long Viewerid {
			get {return _Viewerid; }
			set { _Viewerid = value; }
		}
		public long Ownerid {
			get { return _Ownerid; }
			set { _Ownerid = value; }
		}
		#endregion
		public String Template {
			get { return _Template; }
			set { _Template = value; }
		}
		public UserList(String Template,Int64 id) {
			if (!string.IsNullOrEmpty(Template)) {
				_Template = Template;
			}
			_id = id;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="userid">ID段</param>
		/// <param name="nowpage">当前页码</param>
		/// <param name="c">查询类型</param>
		/// <returns></returns>
		public System.Data.DataTable GetUserTable(Int64 nowpage,byte c) {
			_type = c;
			DoDataBase dd = new DoDataBase();
			SqlParameter[] sp = new SqlParameter[3];
			sp[0] = new SqlParameter("@userid", SqlDbType.BigInt);
			sp[0].Value = _id;
			sp[1] = new SqlParameter("@page", SqlDbType.BigInt);
			sp[1].Value = nowpage;
			sp[2] = new SqlParameter("@class", SqlDbType.TinyInt);
			sp[2].Value = c;
			return dd.DoDataSet("UserList", sp).Tables[0];
		}
		public string ShowPage(System.Data.DataTable dt) {
			//Data.User ur = new Chsword.Data.User();//GetFace用
			if(dt.Rows.Count<1){
				if(_type==0){
					if((Viewerid+Ownerid)>0&&Viewerid==Ownerid){
						return CHCache.GetConfig("Friend","None_Friend");
					}else{
						return CHCache.GetConfig("Friend","None_Friend_Other");
					}
				}
			}
			StringBuilder all = new StringBuilder("");
			String item;
			item = CHCache.GetTemplateCache(_Template);
			if (_type == 0 && _Ownerid != _Viewerid) {
				item = CHCache.GetTemplateCache("userlist");
			}
		
			StringBuilder temp;
			foreach (DataRow dr in dt.Rows){
				temp = new StringBuilder(item.ToString());
				if(dr.Table.Columns.Contains("id"))
					temp.Replace("$Id$", dr["id"].ToString());
				temp.Replace("$Userid$", dr["Userid"].ToString());
				temp.Replace("$Username$", dr["Name"].ToString());
				temp.Replace("$enUsername$",ChServer.UrlEncode(dr["Name"]));
				temp.Replace("$Userface$", Path.GetFace(dr["Userid"].ToString(),ImgSizeType.Middle));
				if(_type==0){
					temp.Replace("$isonline$", Online.OnlineString(dr["Userid"]));
				}
				if (dt.Columns.Contains("Grade")) {
					temp.Replace("$Grade$", dr["Grade"].ToString());
				}
				if (dt.Columns.Contains("Universityid")) {
					temp.Replace("$University$", dr["University"].ToString());
					temp.Replace("$enUniversity$", ChServer.UrlEncode(dr["University"]));
					temp.Replace("$uid$", dr["Universityid"].ToString());
				}
				if (dt.Columns.Contains("Qinshi")) {
					temp.Replace("$Qinshi$", dr["Qinshi"].ToString());
					temp.Replace("$enQinshi$", ChServer.UrlEncode(dr["Qinshi"]));
					temp.Replace("$qid$", dr["Qinshiid"].ToString());
				}
				if (dt.Columns.Contains("XueYuan")) {
					temp.Replace("$Xueyuan$", dr["XueYuan"].ToString());
					temp.Replace("$enXueyuan$", ChServer.UrlEncode(dr["XueYuan"]));
					temp.Replace("$xid$", dr["Xueyuanid"].ToString());
				}
				all.Append(temp);
			}
			return all.ToString();
		}
		//private string GetCount() {
		//    DoDataBase dd = new DoDataBase();

		//    SqlParameter[] sp = new SqlParameter[1];
		//    sp[0] = new SqlParameter("@id", SqlDbType.BigInt);
		//    sp[0].Value = _id;
		//    return dd.DoParameterSql(String.Format("{0}Count", _Template), sp);
		//}

		//public string ShowAll(String Items, int NowPage) {
		//    StringBuilder master = new StringBuilder();
		//    master.Append(CHCache.GetTemplateCache(String.Format("{0}Master", _Template)));
		//    master.Replace("$Items$", Items);
		//    if ( _type != 2 && Template!="UserList")
		//        master.Replace("$Count$", GetCount());
		//    master.Replace("$NowPage$", NowPage.ToString());
		//    try{
		//        master.Replace("$Username$",UserDataRow["name"].ToString());
		//    }catch{
		//        return "无此用户";
		//    }
		//    return master.ToString();
		//}
		
		//DataRow UserDataRow{
		//    get{
		//        if(_UserDataRow==null){
		//            SqlParameter[] sqlParameter = new SqlParameter[2];
		//            sqlParameter[0] = new SqlParameter("@OwnerId", SqlDbType.BigInt);
		//            sqlParameter[0].Value = Ownerid==0?ChSession.Userid:Ownerid;
		//            sqlParameter[1] = new SqlParameter("@ViewerId", SqlDbType.BigInt);
		//            sqlParameter[1].Value = Viewerid==0?ChSession.Userid:Viewerid;
		//            DoDataBase base2 = new DoDataBase();
		//            DataTable dt = base2.DoDataSet("UserRelation", sqlParameter).Tables[0];
		//            if(dt.Rows.Count>0)
		//                _UserDataRow=dt.Rows[0];
		//            else
		//                throw new Exception("无此用户");
		//        }
		//        return _UserDataRow;
				
		//    }
		//}
	}
}
