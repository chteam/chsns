using System.Collections.Generic;
using System.Data;
using CHSNS.Models;

namespace CHSNS.Data {
	public class GroupMediator :BaseMediator, CHSNS.Data.IGroupMediator {
		public GroupMediator(DBExt id) : base(id) { }
		/// <summary>
		/// 群订阅的信息
		/// </summary>
		/// <param name="count">返回多少条</param>
		/// <returns></returns>
		public DataRowCollection TakeIns(int count){
			return DataBaseExecutor.GetRows("RssList",
				"@userid", CHSNSUser.Current.UserID,
				"@page", 1,
				"@everypage", count,
				"@GroupClass", 0);
		}


		#region IGroupMediator 成员


		public Group Info(long ID) {
			throw new System.NotImplementedException();
		}

		public bool Add(Group group) {
			throw new System.NotImplementedException();
		}

		public bool Delete(long ID) {
			throw new System.NotImplementedException();
		}

		public bool Update(Group group) {
			throw new System.NotImplementedException();
		}

		public System.Linq.IQueryable<CHSNS.ModelPas.NotePas> NoteList(long ID) {
			throw new System.NotImplementedException();
		}

		public bool Join(GroupUser guser) {
			throw new System.NotImplementedException();
		}

		public bool Level(GroupUser guser) {
			throw new System.NotImplementedException();
		}

		public bool ToAdmin(GroupUser guser, long operaterID) {
			throw new System.NotImplementedException();
		}

		public bool ToCommonUser(GroupUser guser, long operaterID) {
			throw new System.NotImplementedException();
		}

		#endregion
	}
}
