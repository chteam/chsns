using System;
using System.Collections.Generic;
using CHSNS.Model;

using CHSNS.Operator;
using CHSNS.Models;

namespace CHSNS.Service {
    public class GroupService {
        static readonly GroupService Instance = new GroupService();
        private readonly IGroupOperator _group;
        public GroupService() {
            _group = new GroupOperator();
        }

        public static GroupService GetInstance() {
            return Instance;
        }

        public GroupUser GetGroupUser(long gId, long uId) {
            return _group.GetGroupUser(gId, uId);
        }
        public Group Get(long groupId) {
            return _group.Get(groupId);
        }
        public int WaitJoinCount(long groupId) {
            return _group.WaitJoinCount(groupId);
        }
        public List<UserItemPas> GetAdmins(long groupId) {
            return _group.GetAdmins(groupId);
        }
        public PagedList<Group> GetList(long uId, int page, int pageSize) {
            return _group.GetList(uId, page, pageSize);
        }
        public bool Add(string name, long uId) {
            var group = new Group{
                Name = name,
                Type = (byte)GroupType.Common,
                AddTime = DateTime.Now,
                Summary = "",
                CreaterId = uId
            };
            return _group.Add(group, uId);
        }
        public bool Update(long groupId, Group group) {
            group.Id = groupId;
            return _group.Update(group);
        }
        public List<UserCountPas> GetGroupUser(long groupId){
            return _group.GetGroupUser(groupId);
        }
    }
}
