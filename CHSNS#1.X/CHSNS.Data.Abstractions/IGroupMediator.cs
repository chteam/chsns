using System;
using CHSNS.Models;
using System.Linq;
using CHSNS.ModelPas;
namespace CHSNS.Data {
	public interface IGroupMediator {
		System.Data.DataRowCollection TakeIns(int count);
		#region group
		Group Info(long ID);
		bool Add(Group group);
		bool Delete(long ID);
		bool Update(Group group);
		IQueryable<NotePas> NoteList(long ID);
		#endregion
		#region groupuser
		bool Join(GroupUser guser);
		bool Level(GroupUser guser);
		bool ToAdmin(GroupUser guser, long operaterID);
		bool ToCommonUser(GroupUser guser, long operaterID);
		#endregion

	}
}
