using System;
using System.Collections.Generic;
using System.Linq;
using CHSNS.Model;
using CHSNS.Models;

namespace CHSNS.Operator {
	public class GroupOperator :BaseOperator, IGroupOperator {
        public Group Get(long groupId)
        {
            using (var db = DBExtInstance)
            {
                return db.Group.FirstOrDefault(c => c.ID == groupId);
            }
        }

	    public bool Add(Group group, long uId)
	    {
            using (var db = DBExtInstance) {
                db.Group.InsertOnSubmit(group);
                db.SubmitChanges();
                var gu = new GroupUser {
                    GroupID = group.ID,
                    Status = (byte)GroupUserStatus.Ceater,
                    UserID = uId,
                    AddTime = DateTime.Now
                };
                db.GroupUser.InsertOnSubmit(gu);
                db.SubmitChanges();
            }
	        return true;
	    }

	    public bool Delete(long id)
	    {
	        throw new NotImplementedException();
	    }

	    public bool Update(Group group)
	    {
	        throw new NotImplementedException();
	    }

	    public PagedList<NotePas> NoteList(long id, int p)
	    {
	        throw new NotImplementedException();
	    }

        public GroupUser GetGroupUser(long gId, long uId)
        {
            using (var db = DBExtInstance)
            {
                return db.GroupUser.FirstOrDefault(gu => gu.UserID == uId && gu.GroupID == gId);
            }
        }

	    public int WaitJoinCount(long groupId)
	    {
            using (var db = DBExtInstance)
            {
                return db.GroupUser.Where(
                    c => c.GroupID == groupId
                         && c.Status.Equals(GroupUserStatus.Wait)
                    ).Count();
            }
	    }

        public List<UserItemPas> GetAdmins(long groupId)
        {
            using (var db = DBExtInstance)
            {
                return (from gu in db.GroupUser
                        join a in db.Profile on gu.UserID equals a.UserID
                        where gu.GroupID == groupId
                              && (gu.Status.Equals(GroupUserStatus.Ceater) ||
                                  gu.Status.Equals(GroupUserStatus.Admin))
                        orderby gu.Status descending
                        select new UserItemPas
                                   {
                                       Name = a.Name,
                                       ID = a.UserID
                                   }).ToList();
            }
        }

        public PagedList<Group> GetList(long uId, int page, int pageSize)
        {
            using (var db = DBExtInstance)
            {
                var ret = (from gu in db.GroupUser
                                         join g in db.Group on gu.GroupID equals g.ID
                                         where gu.UserID == uId
                                         select g
                                        );
                ret = ret.OrderBy(c => c.ID);
                return ret.Pager(page, pageSize);
            }
        }

	    public bool Join(GroupUser guser)
	    {
	        throw new NotImplementedException();
	    }

	    public bool Level(GroupUser guser)
	    {
	        throw new NotImplementedException();
	    }

	    public bool ToAdmin(GroupUser guser, long operaterId)
	    {
	        throw new NotImplementedException();
	    }

	    public bool ToCommonUser(GroupUser guser, long operaterId)
	    {
	        throw new NotImplementedException();
	    }
	}
}
