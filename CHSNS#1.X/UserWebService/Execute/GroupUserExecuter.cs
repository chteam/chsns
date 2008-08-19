using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Chsword;
using ChAlumna;
namespace Chsword.Execute {
	class GroupUserExecuter : Reader.Databases, Interface.IItems {
		long _groupid;
		long _userid;
		long _executerid;
		#region ����
		public long Executerid {
			get {
				return _executerid;
			}
			set {
				_executerid = value;
			}
		}
		public long Groupid {
			get { return _groupid; }
			set { _groupid = value; }
		}

		public long Userid {
			get { return _userid; }
			set { _userid = value; }
		}
		#endregion
		#region IItems ��Ա

		public string Add() {//Join����
			int i = 0;
			SqlParameter[] sp = new SqlParameter[2]{
				new SqlParameter("@Groupid", SqlDbType.BigInt),
				new SqlParameter( "@Userid", SqlDbType.BigInt)
			};
			sp[0].Value = _groupid;
			sp[1].Value = _userid;
			DoDataBase db = new DoDataBase();
			int.TryParse(db.DoParameterSql("GroupUser_Add", sp), out i);
			switch (i) {
				case 9:
					return "���Ѿ��ɹ������Ⱥ";
				case 25:
					return "�Բ���,ÿ��ֻ�ܼ���һ����ѧ�༶,���������������ϵ����Ա���";
				case 1:
				case 2:
					return "�Ѿ��ύ����,��ȴ�����Ա���.";
				case 3:
					return "Ⱥ����,����ϵ����Ա��Ⱥ��������";
				default:
					return "�Ƿ��ύ";
			}
		}

		public string Remove() {//�뿪Ⱥ
			SqlParameter[] p = new SqlParameter[3] { 
				new SqlParameter("@Userid", SqlDbType.BigInt),
				new SqlParameter("@Groupid", SqlDbType.BigInt),
				new SqlParameter("@executerid", SqlDbType.BigInt)
			};
			p[0].Value = _userid;
			p[1].Value = _groupid;
			p[2].Value = _executerid;
			DoDataBase dd = new DoDataBase();
			long i = long.Parse(dd.DoParameterSql("GroupUser_Remove", p));
			switch (i) {
				case -1:
					return "���ǹ���Ա,��ȺΪ��֮ǰ,�������˳�";
				case 0:
					return "Ҫ�˳��ĳ�Ա����Ⱥ��";//���Ǳ��˵�Ⱥ
				case 5:
					ChSession.Status=5;
					return "�����ɹ�";
				case 1:
					return "�����ɹ�";
				case -2:
					return "���Ĳ������Ϸ�,���Ķ���ز����ֲ�";
				default:
					return "�����ɹ�";//�ɹ�
			}
		}

		public string Update() {//����
			base.GetObjectbyId2(_groupid, "@Groupid", _userid, "@Userid", "GroupUser_Takein");
			return "���ĳɹ�";
		}

		public string Update2() {//ȡ������
			base.GetObjectbyId2(_groupid, "@Groupid", _userid, "@Userid", "GroupUser_Takeout");
			return "ȡ�����ĳɹ�";
		}

		#endregion
		/// <summary>
		/// �����Ϊ����Ա
		/// </summary>
		/// <returns></returns>
		public string ApplyMaster() {
			int i = 0;
			int.TryParse(base.GetObjectbyId2(_groupid, "@Groupid", _userid, "@Userid", "GroupUser_ApplyMaster").ToString(), out i);
			switch (i) {
				case 1:
					return "�Ѿ���Ⱥ���ύ����,��ȴ����.";
				case -1:
					return "���Ѿ��ύ������.";
				default:
					return "�Ƿ��ύ";
			}
		}
		public string AllowMember(){
			if (Operate(GroupUserType.AllowMember))
				return "�Ѿ������û���Ϊ��Ա";
			else
				return "δ֪����";

		}
		public string AllowMaster() {
			if (Operate(GroupUserType.AllowMaster))
				return "�Ѿ������û�����Ϊ����Ա";
			else
				return "δ֪����";

		}
		public string DisallowMember() {
			if (Operate(GroupUserType.DisallowMember))
				return "�Ѿ����Դ��û�����";
			else
				return "δ֪����";

		}
		public string DisallowMaster() {
			if (Operate(GroupUserType.DisallowMaster))
				return "�Ѿ����Դ��û�����";
			else
				return "δ֪����";

		}
		public string TurnCreater() {
			if (Operate(GroupUserType.TurnCreater))
				return "�Ѿ���Ⱥ��ת��";
			else
				return "δ֪����";
		}
		public string TurnMember() {
			if (Operate(GroupUserType.TurnMember))
				return "�Ѿ������û���Ϊ��ͨ��Ա";
			else
				return "δ֪����";
		}
		bool Operate(GroupUserType t) {
			int i = 99;
			switch (t) {
				case GroupUserType.AllowMember:
					i = 0; break;
				case GroupUserType.DisallowMember:
					i = 1; break;
				case GroupUserType.AllowMaster:
					i = 2; break;
				case GroupUserType.DisallowMaster:
					i = 3; break;
				case GroupUserType.TurnCreater:
					i = 4; break;
				case GroupUserType.TurnMember:
					i = 5; break;
				default: i = 99; break;
			}
			SqlParameter[] p = new SqlParameter[5] { 
				new SqlParameter("@Groupid", SqlDbType.BigInt),
				new SqlParameter("@Userid", SqlDbType.BigInt),
				new SqlParameter("@executerid", SqlDbType.BigInt),
				new SqlParameter("@type", SqlDbType.TinyInt),
				new SqlParameter("@isAdmin",SqlDbType.Bit)
			};
			p[0].Value = _groupid;
			p[1].Value = _userid;
			p[2].Value = _executerid;
			p[3].Value = i;
			p[4].Value= ChSession.isAdmin;
			DoDataBase dd = new DoDataBase();
			return int.Parse(dd.DoParameterSql("GroupUser_Option", p)) == 1 ? true : false;
		}
	}
}
