using System.Collections.Generic;
using CHSNS.Models;
using CHSNS.Model;
namespace CHSNS.Operator {
	public interface IGroupOperator {
		//System.Data.DataRowCollection TakeIns(int count);
		#region group
        /// <summary>
        /// 得到群信息
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
		Group Get(long groupId);

	    bool Add(Group group, long uId);
		bool Delete(long id);
		bool Update(Group group);
	    PagedList<NotePas> NoteList(long id, int p);
		#endregion
        /// <summary>
        /// 得到用户权限
        /// </summary>
        /// <param name="gId"></param>
        /// <param name="uId"></param>
        /// <returns></returns>
	    GroupUser GetGroupUser(long gId, long uId);
        /// <summary>
        /// 等待加入的人数
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
	    int WaitJoinCount(long groupId);
        /// <summary>
        /// 管理員列表
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
	    List<UserItemPas> GetAdmins(long groupId);
        /// <summary>
        /// 某人的群
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
	    PagedList<Group> GetList(long uId, int page, int pageSize);
		#region groupuser
		bool Join(GroupUser guser);
		bool Level(GroupUser guser);
		bool ToAdmin(GroupUser guser, long operaterId);
		bool ToCommonUser(GroupUser guser, long operaterId);
		#endregion

	}
}
