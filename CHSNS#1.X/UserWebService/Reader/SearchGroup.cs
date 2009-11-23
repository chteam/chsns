using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Chsword.Reader {
	class SearchGroup : GroupList {
		string _groupname;
		public DataTable GetSearchTable() {
			SqlParameter[] _sp;//传道到数据库的存储过程参数
			_sp = new SqlParameter[4];
			_sp[0] = new SqlParameter("@GroupName", SqlDbType.NVarChar,50);
			_sp[0].Value = Groupname;
			_sp[1] = new SqlParameter("@page", SqlDbType.BigInt);
			_sp[1].Value = Nowpage;
			_sp[2] = new SqlParameter("@everypage", SqlDbType.BigInt);
			_sp[2].Value = Everypage;
			_sp[3] = new SqlParameter("@GroupClass", SqlDbType.TinyInt);
			_sp[3].Value = Groupclass;
			DoDataBase dd = new DoDataBase();
			return dd.DoDataSet("SearchGroup", _sp).Tables[0];
		}
		private string GetSearchCount() {
			SqlParameter[] _sp;//传道到数据库的存储过程参数
			_sp = new SqlParameter[2];
			_sp[0] = new SqlParameter("@GroupName", SqlDbType.NVarChar, 50);
			_sp[0].Value = Groupname;
			_sp[1] = new SqlParameter("@GroupClass", SqlDbType.TinyInt);
			_sp[1].Value = Groupclass;
			DoDataBase dd = new DoDataBase();
			return dd.DoParameterSql("SearchGroupCount", _sp);
		}

		public ServerResponse GetMember() {
			Type = 1;
			ServerResponse sr = new ServerResponse();
			sr.Count = GetSearchCount();
			sr.ResponseText = ShowPage(GetSearchTable());
			return sr;
		}
		public string Groupname {
			get {
				return _groupname;
			}
			set {
				_groupname = value;
			}
		}



	}
}
