using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Chsword.Reader {
	public class Search : Reader.UserList {
		Dictionary<string, object> _dict;
		string _mode;
		int _nowpage = 1;
		int _everypage = 10;
		public string Mode {
			get { return _mode; }
			set { _mode = value; }
		}
		//分页处理
		public int Nowpage {
			get { return _nowpage; }
			set { _nowpage = value; }
		}
		public int Everypage {
			get { return _everypage; }
			set { _everypage = value; }
		}
		//===================================构造函数
		public Search(Dictionary<string, object> dict, string mode) {
			_dict = dict;
			_mode = mode;
		}
		public Search(string mode) {
			_mode = mode;
		}

		//===============================从客户端获取数据
		public ServerResponse GetMember(){
			ServerResponse sr = new ServerResponse();
			sr.Count = GetSearchCount();
			sr.ResponseText = ShowPage(GetSearchTable());
			return sr;
		}
		//===============================读取数据
		public DataTable GetSearchTable() {
			DoDataBase dd = new DoDataBase();
			return dd.DoDataSet("search", GetParameter()).Tables[0];
		}
		private string GetSearchCount() {
			DoDataBase dd = new DoDataBase();
			return dd.DoParameterSql("SearchCount", GetParameter());
		}
		SqlParameter[] GetParameter() {
			SqlParameter[] _sp = new SqlParameter[20]{
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@page", SqlDbType.BigInt),
				new SqlParameter("@everypage", SqlDbType.BigInt),
				new SqlParameter("@mode", SqlDbType.NVarChar, 255),
				new SqlParameter("@name", SqlDbType.NVarChar, 12),
				new SqlParameter("@University", SqlDbType.NVarChar, 50),
				new SqlParameter("@email", SqlDbType.NVarChar, 50),
				new SqlParameter("@HighSchool", SqlDbType.NVarChar, 50)
					,new SqlParameter("@Grade",SqlDbType.SmallInt)
					,new SqlParameter("@LoveLike", SqlDbType.NVarChar, 50)
					,new SqlParameter("@LoveBook", SqlDbType.NVarChar, 50)
					,new SqlParameter("@LoveMusic", SqlDbType.NVarChar, 50)
					,new SqlParameter("@LoveMovie", SqlDbType.NVarChar, 50)
					,new SqlParameter("@LoveSports", SqlDbType.NVarChar, 50)
					,new SqlParameter("@LoveGame", SqlDbType.NVarChar, 50)
					,new SqlParameter("@LoveComic", SqlDbType.NVarChar, 50)
					,new SqlParameter("@JoinSociety", SqlDbType.NVarChar, 50)
				,new SqlParameter("@uid", SqlDbType.BigInt)
				,new SqlParameter("@xid", SqlDbType.BigInt)
				,new SqlParameter("@qid", SqlDbType.BigInt)
			};
			_sp[0].Value = getDict("userid");// Formatlong();
			_sp[1].Value = _nowpage;
			_sp[2].Value = _everypage;
			_sp[3].Value = _mode;
			_sp[4].Value = getDict("username");
			_sp[5].Value = getDict("university");//) ;// string.IsNullOrEmpty(? null : _User.University;
			_sp[6].Value = getDict("email");
			_sp[7].Value = getDict("highschool");
			_sp[8].Value = getDict("grade");
			_sp[9].Value = getDict("lovelike");
			_sp[10].Value = getDict("lovebook");
			_sp[11].Value = getDict("lovemusic");
			_sp[12].Value = getDict("lovemovie");
			_sp[13].Value = getDict("lovesports");
			_sp[14].Value = getDict("lovegame");
			_sp[15].Value = getDict("lovecomic");
			_sp[16].Value = getDict("joinsociety");
			_sp[17].Value = getDict("uid");
			_sp[18].Value = getDict("xid");
			_sp[19].Value = getDict("qid");
			return _sp;
		}
		object Formatlong(long init) {
			if (init == 0) {
				return System.DBNull.Value;
			}
			return init;
		}
		object getDict(string str) {
			if (_dict.ContainsKey(str)) {
				return Formatstr(_dict[str]);
			}
			return System.DBNull.Value;
		}
		object Formatstr(object str){
			if(string.IsNullOrEmpty(str.ToString()))
				return System.DBNull.Value;
			return str;
		}
	}
}
