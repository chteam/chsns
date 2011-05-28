using System;
using System.Collections.Generic;
using System.Linq;
using CHSNS.Model;
using CHSNS.Models;
namespace CHSNS.Service
{
    using System.ComponentModel.Composition;
    [Export]
    public class GroupService : BaseService
    {

        public GroupUser GetGroupUser(long gId, long uId)
        {
            using (var db = DbInstance)
            {
                return db.GroupUser.FirstOrDefault(gu => gu.UserId == uId && gu.GroupId == gId);
            }
        }
        public Group Get(long groupId)
        {
            using (var db = DbInstance)
            {
                return db.Group.FirstOrDefault(c => c.Id == groupId);
            }
        }
        public int WaitJoinCount(long groupId)
        {
            var type = (byte)GroupUserStatus.Wait;
            using (var db = DbInstance)
            {
                return db.GroupUser.Where(
                    c => c.GroupId == groupId
                         && c.Status.Equals(type)
                    ).Count();
            }
        }
        public List<UserItemPas> GetAdmins(long groupId)
        {
            byte tc = (byte)GroupUserStatus.Ceater;
            byte ta = (byte)GroupUserStatus.Admin;
            using (var db = DbInstance)
            {
                return (from gu in db.GroupUser
                        join a in db.Profile on gu.UserId equals a.UserId
                        where gu.GroupId == groupId
                              && (gu.Status.Equals(tc) ||
                                  gu.Status.Equals(ta))
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
            using (var db = DbInstance)
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
        public bool Add(string name, long uId)
        {
            var group = new Group
            {
                Name = name,
                Type = (byte)GroupType.Common,
                AddTime = DateTime.Now,
                Summary = "",
                CreaterId = uId
            };

            using (var db = DbInstance)
            {
                db.Group.Add(group);
                db.SaveChanges();
                var gu = new GroupUser
                {
                    GroupId = group.Id,
                    Status = (byte)GroupUserStatus.Ceater,
                    UserId = uId,
                    AddTime = DateTime.Now
                };
                db.GroupUser.Add(gu);
                db.SaveChanges();
            }
            return true;
        }
        public bool Update(long groupId, Group group)
        {
            group.Id = groupId;
            using (var db = DbInstance)
            {
                var g = db.Group.Where(c => c.Id == group.Id).FirstOrDefault();
                if (g == null) return false;
                g.Name = group.Name;
                g.JoinLevel = group.JoinLevel;
                g.ShowLevel = group.ShowLevel;
                g.Summary = group.Summary ?? "";
                db.SaveChanges();
            }
            return true;
        }
        public List<UserCountPas> GetGroupUser(long groupId)
        {
            using (var db = DbInstance)
            {
                var list = (from g in db.GroupUser
                            join u in db.Profile on g.UserId equals u.UserId
                            where g.GroupId == groupId
                            select new UserCountPas
                            {
                                Id = u.UserId,
                                Name = u.Name,
                                Count = g.Status
                            });
                return list.ToList();
            }
        }
    }
}
