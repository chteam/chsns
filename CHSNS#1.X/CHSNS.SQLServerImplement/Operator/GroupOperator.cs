using System;
using System.Collections.Generic;
using System.Linq;
using CHSNS.Model;
using CHSNS.Abstractions;

namespace CHSNS.Operator {
	public class GroupOperator :BaseOperator, IGroupOperator {
        public IGroup Get(long groupId)
        {
            using (var db = DBExtInstance)
            {
                return db.Group.FirstOrDefault(c => c.ID == groupId);
            }
        }

        public bool Add(IGroup group, long uId)
	    {
            using (var db = DBExtInstance) {
                db.Group.InsertOnSubmit(CastTool.Cast<Group>( group));
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



        public bool Update(IGroup group)
	    {
            using (var db = DBExtInstance){
                var g = db.Group.Where(c => c.ID == group.ID).FirstOrDefault();
                if (g == null) return false;
                g.Name = group.Name;
                g.JoinLevel = group.JoinLevel;
                g.ShowLevel = group.ShowLevel;
                g.Summary = group.Summary ?? "";
                db.SubmitChanges();
            }
            return true;
	    }


        public IGroupUser GetGroupUser(long gId, long uId)
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

        public PagedList<IGroup> GetList(long uId, int page, int pageSize)
        {
            using (var db = DBExtInstance)
            {
                var ret = (from gu in db.GroupUser
                                         join g in db.Group on gu.GroupID equals g.ID
                                         where gu.UserID == uId
                                         select g
                                        ).Cast<IGroup>();
                ret = ret.OrderBy(c => c.ID);
                return ret.Pager(page, pageSize);
            }
        }

        public List<UserCountPas> GetGroupUser(long groupId){
            using (var db = DBExtInstance){
                var list = (from g in db.GroupUser
                            join u in db.Profile on g.UserID equals u.UserID
                            where g.GroupID == groupId
                            select new UserCountPas{
                                                       ID = u.UserID,
                                                       Name = u.Name,
                                                       Count = g.Status
                                                   });
                return list.ToList();
            }
        }

	}
}
