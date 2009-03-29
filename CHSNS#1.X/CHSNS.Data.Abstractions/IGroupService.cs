using CHSNS.Models;
using CHSNS.Model;
namespace CHSNS.Service {
	public interface IGroupService {
		//System.Data.DataRowCollection TakeIns(int count);
		#region group
		Group Info(long ID);
		bool Add(Group group);
		bool Delete(long ID);
		bool Update(Group group);
	    PagedList<NotePas> NoteList(long ID, int p);
		#endregion
		#region groupuser
		bool Join(GroupUser guser);
		bool Level(GroupUser guser);
		bool ToAdmin(GroupUser guser, long operaterID);
		bool ToCommonUser(GroupUser guser, long operaterID);
		#endregion

	}
}
