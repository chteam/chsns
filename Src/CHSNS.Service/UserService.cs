﻿using System;
using CHSNS.Model;

using CHSNS.Operator;
using CHSNS.Models;

namespace CHSNS.Service {
    public class UserService {
        static readonly UserService Instance = new UserService();
        private readonly IUserOperator User;
        private readonly IEventOperator Event;
        public UserService() {
            User = new UserOperator();
            Event = new EventOperator();
        }

        public static UserService GetInstance() {
            return Instance;
        }

        public UserPas UserInformation(long userid) {
            return User.UserInformation(userid);
        }

        public int Relation(long ownerId, long viewerId) {
            return User.Relation(ownerId, viewerId);
        }

        #region BasicInfo
        public BasicInformation GetBaseInfo(long userId) {
            return User.GetBaseInfo(userId);
        }
        public void SaveBaseInfo(BasicInformation b, IContext context) {
            if (b.UserId == 0) b.UserId = context.User.UserId;
            User.SaveBaseInfo(b);
        }

        #endregion

        #region Magicbox
        public string GetMagicBox(long userId) {
            return User.GetMagicBox(userId);
        }
        public void SaveMagicBox(string magicbox, long uid) {
            User.SaveMagicBox(magicbox, uid);
        }
        public void MagicBoxBackup() {
            User.MagicBoxBackup();
        }



        #endregion
        #region face
        public void DeleteFace(long userid, string path) {
            //IOFactory.Folder.Delete(Path.FaceMapPath(userid), true);
        }
        #endregion

        public Profile GetUser(long userid) {
            return GetUser(userid, c => new Profile{
                Name = c.Name
            });
        }

        public Profile GetUser<T>(long userid, System.Linq.Expressions.Expression<Func<Profile, T>> x) {
            return User.GetUser(userid, x);
        }
        #region profile
        public void SaveText(long uid, string text, IContext context) {
            User.SaveText(uid, text);
            Event.Add(new Event{
                OwnerId = context.User.UserId,
                TemplateName = "ProText",
                AddTime = DateTime.Now,
                ShowLevel = 0,
                Json = Dictionary.CreateFromArgs("name", context.User.NickName,
                                                 "text", text).ToJsonString()
            });
        }

        #endregion


        public string GetUserName(long uid) {
            return User.GetUserName(uid);
        }
        /// <summary>
        /// 修改头像
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="url">头像地址，（全）</param>
        public void ChangeFace(long userId, string url) {
            User.ChangeFace(userId, url);
        }
    }
}