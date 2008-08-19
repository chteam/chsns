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
		#region 属性
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
		#region IItems 成员

		public string Add() {//Join方法
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
					return "您已经成功加入该群";
				case 25:
					return "对不起,每人只能加入一个大学班级,如有特殊情况请联系管理员解决";
				case 1:
				case 2:
					return "已经提交申请,请等待管理员审核.";
				case 3:
					return "群已满,请联系管理员对群进行扩容";
				default:
					return "非法提交";
			}
		}

		public string Remove() {//离开群
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
					return "您是管理员,在群为空之前,您不能退出";
				case 0:
					return "要退出的成员不在群中";//不是本人的群
				case 5:
					ChSession.Status=5;
					return "操作成功";
				case 1:
					return "操作成功";
				case -2:
					return "您的操作不合法,请阅读相关操作手册";
				default:
					return "操作成功";//成功
			}
		}

		public string Update() {//订阅
			base.GetObjectbyId2(_groupid, "@Groupid", _userid, "@Userid", "GroupUser_Takein");
			return "订阅成功";
		}

		public string Update2() {//取消订阅
			base.GetObjectbyId2(_groupid, "@Groupid", _userid, "@Userid", "GroupUser_Takeout");
			return "取消订阅成功";
		}

		#endregion
		/// <summary>
		/// 申请成为管理员
		/// </summary>
		/// <returns></returns>
		public string ApplyMaster() {
			int i = 0;
			int.TryParse(base.GetObjectbyId2(_groupid, "@Groupid", _userid, "@Userid", "GroupUser_ApplyMaster").ToString(), out i);
			switch (i) {
				case 1:
					return "已经向群主提交申请,请等待审核.";
				case -1:
					return "您已经提交过申请.";
				default:
					return "非法提交";
			}
		}
		public string AllowMember(){
			if (Operate(GroupUserType.AllowMember))
				return "已经将此用户加为成员";
			else
				return "未知错误";

		}
		public string AllowMaster() {
			if (Operate(GroupUserType.AllowMaster))
				return "已经将此用户提升为管理员";
			else
				return "未知错误";

		}
		public string DisallowMember() {
			if (Operate(GroupUserType.DisallowMember))
				return "已经忽略此用户请求";
			else
				return "未知错误";

		}
		public string DisallowMaster() {
			if (Operate(GroupUserType.DisallowMaster))
				return "已经忽略此用户请求";
			else
				return "未知错误";

		}
		public string TurnCreater() {
			if (Operate(GroupUserType.TurnCreater))
				return "已经将群主转让";
			else
				return "未知错误";
		}
		public string TurnMember() {
			if (Operate(GroupUserType.TurnMember))
				return "已经将此用户列为普通成员";
			else
				return "未知错误";
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
