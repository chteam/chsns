using System;
using System.Collections.Generic;
using CHSNS.Model;
using CHSNS.Models;
using CHSNS.Models.Abstractions;
using CHSNS.Operator;

namespace CHSNS.Service {
    public class GroupService {
        static readonly GroupService Instance = new GroupService();
        private readonly IGroupOperator Group;
        public GroupService() {
            Group = new GroupOperator();
        }

        public static GroupService GetInstance() {
            return Instance;
        }

        public IGroupUser GetGroupUser(long gId, long uId) {
            return Group.GetGroupUser(gId, uId);
        }
        public IGroup Get(long groupId) {
            return Group.Get(groupId);
        }
        public int WaitJoinCount(long groupId) {
            return Group.WaitJoinCount(groupId);
        }
        public List<UserItemPas> GetAdmins(long groupId) {
            return Group.GetAdmins(groupId);
        }
        public PagedList<IGroup> GetList(long uId, int page, int pageSize) {
            return Group.GetList(uId, page, pageSize);
        }
        public bool Add(string name, long uId) {
            var group = new GroupImplement {
                Name = name,
                Type = (byte)GroupType.Common,
                AddTime = DateTime.Now,
                Summary = "",
                CreaterID = uId
            };
            return Group.Add(group, uId);
        }
        public bool Update(long groupId, IGroup group) {
            group.ID = groupId;
            return Group.Update(group);
        }
        public List<UserCountPas> GetGroupUser(long groupId){
            return Group.GetGroupUser(groupId);
        }
    }
}
