using System.Data;
using CHSNS.Models;

namespace CHSNS.Service {
	public class GroupService :BaseService, IGroupService {
		public GroupService(IDBManager id) : base(id) { }
		/// <summary>
		/// 群订阅的信息
		/// </summary>
		/// <param name="count">返回多少条</param>
		/// <returns></returns>
		public DataRowCollection TakeIns(int count){
			return DataBaseExecutor.GetRows("RssList",
				"@userid", DBExt.Context.User.UserID,
				"@page", 1,
				"@everypage", count,
				"@GroupClass", 0);
		}


		#region IGroupService 成员


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

		public System.Linq.IQueryable<Model.NotePas> NoteList(long ID) {
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
