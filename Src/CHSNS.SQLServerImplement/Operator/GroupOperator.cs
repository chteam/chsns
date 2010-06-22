using System;
using System.Collections.Generic;
using System.Linq;
using CHSNS.Model;

using CHSNS.SQLServerImplement;
using CHSNS.Models;

namespace CHSNS.Operator {
	public class GroupOperator :BaseOperator {
        public Group Get(long groupId)
        {
            using (var db = DBExtInstance)
            {
                return db.Group.FirstOrDefault(c => c.Id == groupId);
            }
        }

        public bool Add(Group group, long uId)
	    {
            using (var db = DBExtInstance) {
                db.Group.AddObject(group);
                db.SubmitChanges();
                var gu = new GroupUser {
                    GroupId = group.Id,
                    Status = (byte)GroupUserStatus.Ceater,
                    UserId = uId,
                    AddTime = DateTime.Now
                };
                db.GroupUser.AddObject(gu);
                db.SubmitChanges();
            }
	        return true;
	    }



        public bool Update(Group group)
	    {
            using (var db = DBExtInstance){
                var g = db.Group.Where(c => c.Id == group.Id).FirstOrDefault();
                if (g == null) return false;
                g.Name = group.Name;
                g.JoinLevel = group.JoinLevel;
                g.ShowLevel = group.ShowLevel;
                g.Summary = group.Summary ?? "";
                db.SubmitChanges();
            }
            return true;
	    }


        public GroupUser GetGroupUser(long gId, long uId)
        {
            using (var db = DBExtInstance)
            {
                return db.GroupUser.FirstOrDefault(gu => gu.UserId == uId && gu.GroupId == gId);
            }
        }

	    public int WaitJoinCount(long groupId)
	    {
            using (var db = DBExtInstance)
            {
                return db.GroupUser.Where(
                    c => c.GroupId == groupId
                         && c.Status.Equals(GroupUserStatus.Wait)
                    ).Count();
            }
	    }

        public List<UserItemPas> GetAdmins(long groupId)
        {
            using (var db = DBExtInstance)
            {
                return (from gu in db.GroupUser
                        join a in db.Profile on gu.UserId equals a.UserId
                        where gu.GroupId == groupId
                              && (gu.Status.Equals(GroupUserStatus.Ceater) ||
                                  gu.Status.Equals(GroupUserStatus.Admin))
                        orderby gu.Status descending
                        select new UserItemPas
                                   {
                                       Name = a.Name,
                                       Id = a.UserId
                                   }).ToList();
            }
        }

        public PagedList<Group> GetList(long uId, int page, int pageSize)
        {
            using (var db = DBExtInstance)
            {
                var ret = (from gu in db.GroupUser
                                         join g in db.Group on gu.GroupId equals g.Id
                                         where gu.UserId == uId
                                         select g
                                        ).Cast<Group>();
                ret = ret.OrderBy(c => c.Id);
                return ret.Pager(page, pageSize);
            }
        }

        public List<UserCountPas> GetGroupUser(long groupId){
            using (var db = DBExtInstance){
                var list = (from g in db.GroupUser
                            join u in db.Profile on g.UserId equals u.UserId
                            where g.GroupId == groupId
                            select new UserCountPas{
                                                       Id = u.UserId,
                                                       Name = u.Name,
                                                       Count = g.Status
                                                   });
                return list.ToList();
            }
        }

	}
}
