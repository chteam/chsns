using System;
using System.Data;
using System.Data.SqlClient;

using Chsword.Datamodel;
using Chsword.Interface;
using CHSNS;

namespace Chsword.Execute {
	public class GroupExecuter : IItems {
		private GroupModel _Items;
		public GroupExecuter(GroupModel gm) {
			_Items = gm;
		}

		#region IItems ��Ա
		/// <summary>
		/// ����Ⱥ
		/// </summary>
		/// <returns></returns>
		public string Add() {
			SqlParameter[] sp = new SqlParameter[6]{
				new SqlParameter("@GroupName", SqlDbType.NVarChar, 50),
				new SqlParameter("@CreateUserid", SqlDbType.BigInt),
				new SqlParameter("@GroupClass", SqlDbType.TinyInt),
				new SqlParameter("@Score", SqlDbType.BigInt),
				new SqlParameter("@userstatus",SqlDbType.BigInt),
				new SqlParameter("@categroy",SqlDbType.BigInt)
			};
			sp[0].Value = _Items.Groupname;
			sp[1].Value = _Items.CreateUserid;
			sp[2].Value = _Items.GroupClass;
			sp[3].Value = _Items.GroupClass == 0 ? 50 : 0;//�ѵ��Ļ���,Ⱥ50,��û��
			sp[4].Value = CHUser.Status;
			sp[5].Value = _Items.Category;
			DoDataBase dd = new DoDataBase();
			long i = long.Parse(dd.DoParameterSql("Group_Add", sp));
			switch (i) {
				case -1:
					return CHCache.GetConfig("Prompt","score_not_enough");
				case 0:
					return CHCache.GetConfig("Prompt","name_exists");
				case -9:
					return CHCache.GetConfig("Prompt","only_one_usiversity_class");
				default:
					return i.ToString();
			}
		}

		public string Remove() {//��ɢȺ
			throw new Exception("The method or operation is not implemented.");
		}

		public string Update() {
			throw new Exception("The method or operation is not implemented.");
		}

		public string Update2() {
			throw new Exception("The method or operation is not implemented.");
		}

		#endregion
	}
}
