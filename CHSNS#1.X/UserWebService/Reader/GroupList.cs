using System;
using System.Collections.Generic;
using System.Text;
using Chsword.Interface;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using CHSNS;

namespace Chsword.Reader {
	public class GroupList:Databases, IShowPage , IPageSet,IServerResponseable {
		long _userid;
		byte _groupclass = 0;
		int _nowpage = 1;
		int _everypage = 20;
		byte _type = 0;
		bool _autotoclass=false;
		
		public bool Autotoclass {
			get { return _autotoclass; }
			set { _autotoclass = value; }
		}
		public byte Type {//0�Ƿ����ҵ�Ⱥ�б�,1�Ƿ�������Ⱥ����б�
			get { return _type; }
			set { _type = value; }
		}
		public long Userid {
			get { return _userid; }
			set { _userid = value; }
		}
		public byte Groupclass {
			get { return _groupclass; }
			set { _groupclass = value; }
		}
		public int Nowpage {
			get { return _nowpage; }
			set { _nowpage = value; }
		}
		public int Everypage {
			get { return _everypage; }
			set { _everypage = value; }
		}
		public System.Data.DataTable GetGroupList() {
			SqlParameter[] _sp;//���������ݿ�Ĵ洢���̲���
			_sp = new SqlParameter[5];
			_sp[0] = new SqlParameter("@userid", SqlDbType.BigInt);
			_sp[0].Value = Userid;
			_sp[1] = new SqlParameter("@page", SqlDbType.BigInt);
			_sp[1].Value = Nowpage;
			_sp[2] = new SqlParameter("@everypage", SqlDbType.BigInt);
			_sp[2].Value = Everypage;
			_sp[3] = new SqlParameter("@GroupClass", SqlDbType.TinyInt);
			_sp[3].Value = Groupclass;
			_sp[4] = new SqlParameter("@type", SqlDbType.TinyInt);
			_sp[4].Value = Type;
			DoDataBase dd = new DoDataBase();
			return dd.DoDataSet("GroupList", _sp).Tables[0];
		}
		private string GetCount() {
			if (_type == 0) {
				DoDataBase dd = new DoDataBase();
				SqlParameter[] sp = new SqlParameter[3];
				sp[0] = new SqlParameter("@userid", SqlDbType.BigInt);
				sp[0].Value = Userid;
				sp[1] = new SqlParameter("@GroupClass", SqlDbType.TinyInt);
				sp[1].Value = Groupclass;
				sp[2] = new SqlParameter("@type", SqlDbType.TinyInt);
				sp[2].Value = Type;
				return dd.DoParameterSql("GroupListCount", sp);
			} else
				return "0";
		}

		#region IShowPage ��Ա

		public string ShowPage(System.Data.DataTable dt) {
			//		Data.User ur = new Chsword.Data.User();//GroupFace��
			if(_nowpage<=1){
				if(_type==0)//�ҵ�Ⱥ�б�
					if(dt.Rows.Count<1)
					return CHCache.GetConfig("Group","None_MyGrouplist");
			}
			StringBuilder all = new StringBuilder("");
			if (_groupclass == 1) {
				String item = CHCache.GetTemplateCache("MyClass");
				StringBuilder temp;
				foreach (DataRow dr in dt.Rows) {
					if (dt.Rows.Count == 1 && Autotoclass && CHSNSUser.Current.Status >= UserStatusType.User && true.Equals(dr["istrue"])) {
						HttpContext.Current.Response.Redirect(string.Format("/group.aspx?id={0}&", dr["id"].ToString()));
					}
					temp = new StringBuilder(item.ToString());
					string t1;
					if (!true.Equals(dr["istrue"])) {
						if (dr["level"].ToString().Equals("255")) { //�Ҵ�����һ��Ⱥ
							t1 = CHCache.GetConfig("Group", "Class_CreateWait");
						} else { //�����������һ��Ⱥ
							t1 = CHCache.GetConfig("Group", "Class_JoinWait");
						}
					} else {//��û�����Ҳû����
						t1 = "";
					}
					temp.Replace("$Edit$",
						string.Format(
						t1,
						dr["id"].ToString(),
						dr["Groupname"].ToString()
						)
						);
					//���˵����ӻ��˵Ļظ�ʱ
					temp.Replace("$Groupname$", dr["Groupname"].ToString());
					if(dr.Table.Columns.Contains("id")){
						temp.Replace("$Groupid$", dr["id"].ToString());
					}
					temp.Replace("$University$", dr["University"].ToString());
					temp.Replace("$Xueyuan$", dr["Xueyuan"].ToString());
					if(Type==2)
						temp.Replace("$Grade$", dr["Grade"].ToString());
					
					temp.Replace("$Usercount$", dr["count"].ToString());
					all.Append(temp);
				}
			} else {
				String item = CHCache.GetTemplateCache("GroupItem");
				StringBuilder temp;
				for (int i = 0; i < dt.Rows.Count; i++) {
					temp = new StringBuilder(item.ToString());
					//���˵����ӻ��˵Ļظ�ʱ
					temp.Replace("$GroupName$", dt.Rows[i]["GroupName"].ToString());
					//
					temp.Replace("$GroupFace$", Path.GetGroupImg(dt.Rows[i]["groupid"].ToString()));
					//
					temp.Replace("$Count$", dt.Rows[i]["count"].ToString());
					if (0 == _type) {
						if (long.Parse(dt.Rows[i]["level"].ToString()) >= 12)
							temp.Replace("$Edit$", "<li><a href=\"/ManageGroup.aspx?id=$Groupid$&\">�����Ⱥ</a></li>$Edit$");
						temp.Replace("$Edit$", "<li><a href=\"javascript:OutGroup($Groupid$);\">�˳�Ⱥ</a></li>$Edit$");
					}
					temp.Replace("$Edit$", "");
					temp.Replace("$Groupid$", dt.Rows[i]["Groupid"].ToString());
					all.Append(temp);
				}
			}
			return all.ToString();
		}

		#endregion

		#region IServerResponseable ��Ա

		public ServerResponse GetServerResponse() {
			ServerResponse sr = new ServerResponse();
			sr.Count = GetCount();
			sr.ResponseText = ShowPage(GetGroupList());
			return sr;
		}

		#endregion
	}
}
