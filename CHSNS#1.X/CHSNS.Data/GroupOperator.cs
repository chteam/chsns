using System.Data;
using CHSNS.Models;

namespace CHSNS.Operator {
	public class GroupOperator :BaseOperator, IGroupOperator {
		public GroupOperator(IDBManager id) : base(id) { }
		#region IGroupOperator 成员


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

		public PagedList<Model.NotePas> NoteList(long ID,int p) {
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
