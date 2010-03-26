﻿using System;
//
using CHSNS.Model;
using CHSNS.Models;

namespace CHSNS.Operator {
    public interface IUserOperator {
        void DeleteFace(long userid);
        BasicInformation GetBaseInfo(long userId);
        string GetMagicBox(long userId);
        Profile GetUser(long userid);
        Profile GetUser<T>(long userid, System.Linq.Expressions.Expression<Func<Profile, T>> x);
        void MagicBoxBackup();
        int Relation(long ownerId, long viewerId);
        void SaveBaseInfo(BasicInformation bi);
        void SaveMagicBox(string magicbox, long uid);
        void SaveText(long userid, string text);
        Model.UserPas UserInformation(long userid);
        string GetUserName(long uid);

        /// <summary>
        /// 更改头像
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="url">这</param>
        void ChangeFace(long userId, string url);
    }
}