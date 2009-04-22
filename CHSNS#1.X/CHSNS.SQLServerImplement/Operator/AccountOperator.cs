﻿using System;
using System.Linq;
using CHSNS.Model;

namespace CHSNS.Operator
{
    public class AccountOperator :BaseOperator ,IAccountOperator
    {
      
        /// <summary>
        /// 注销
        /// </summary>
        public void Logout(IContext context)
        {
            context.Cookies.Clear();
            context.User.Clear();
        }
        public int Login(String userName, String password, Boolean autoLogin, Boolean isPasswordMd5,IContext context)
        {
            if (string.IsNullOrEmpty(userName.Trim())) throw new Exception("用户名不能为空");

            var md5Pwd = isPasswordMd5 ? password.Trim().ToMd5() : password.Trim();
            long userId;
            long.TryParse(userName.Trim(), out userId);
            long userid;
            Profile profile;
            int retint = -999;
            using (var db = DBExtInstance)
            {
                userid = (from a in db.Account
                          where (a.Username == userName || a.UserID == userId)
                                && a.Password == md5Pwd
                          select a.UserID).FirstOrDefault();
                if (userid <= 1000) return retint;
                profile = db.Profile.FirstOrDefault(p => p.UserID == userid);
                retint = profile.Status;
                if (retint <= 0) return -1;
                long score = (profile.LoginTime.Date != DateTime.Now.Date) ? 2 : 0;

                #region    更新

                profile.Score += score;
                profile.ShowScore += score;
                profile.LoginTime = DateTime.Now;
                db.SubmitChanges();
                //                        DataBaseExecutor.Execute(
                //                            @"UPDATE [profile] 
                //SET Score =Score+@s,
                //ShowScore =ShowScore+@s, 
                //LoginTime = getdate() 
                //where userid=@UserID",
                //                            "@UserID", userid, "@s", source);

                #endregion
            }
            context.User.Clear();
            context.User.UserID = userid;
            context.User.Username = profile.Name;
            context.User.InitStatus(retint);

            context.Cookies.Apps = profile.Applications ?? "";
            if (!autoLogin) return retint;
            context.Cookies.UserID = context.User.UserID;
            context.Cookies.UserPassword = md5Pwd;
            context.Cookies.IsAutoLogin = true;
            context.Cookies.Expires = DateTime.Now.AddDays(365);

            //else
            //	CHCookies.Expires = DateTime.Now.AddDays(-1);

            return retint;

            //	throw new Exception(retint.ToString());

        }

        public bool Create(AccountPas account, string name)
        {
			var canuse = IsUsernameCanUse(account.Username);
            if (!canuse)
                return false;
        	var ac = new Account {
        	                     	Username = account.Username,
        	                     	Password = account.Password.ToMd5(),
									Code = DateTime.Now.Ticks
        	                     };
            using (var db = DBExtInstance)
            {
                db.Account.InsertOnSubmit(ac);
                db.SubmitChanges();
                if (ac.UserID < 999) return false;
                const int initscore = 50;
                db.Profile.InsertOnSubmit(new Profile
                    {
                        UserID = ac.UserID,
                        Name = name,
                        ShowScore = initscore,
                        Score = initscore,
                        DelScore = 0,
                        Status = (int)RoleType.General,
                        RegTime = DateTime.Now,
                        LoginTime = DateTime.Now,
                        MagicBox = ""
                    });
                db.BasicInformation
                    .InsertOnSubmit(
                    new BasicInformation
                    {
                        UserID = ac.UserID,
                        Name = name
                    });
                db.SubmitChanges();
                return true;
            }
        }
        public bool IsUsernameCanUse(string username)
        {
            if (username.Trim().Length < 4)
                return false;
            using (var db = DBExtInstance)
            {
                return db.Account.Where(c => c.Username == username.Trim()).Count() == 0;
            }
        }


        public void InitCreater()
        {
            using (var db = DBExtInstance)
            {
                var p = db.Profile.FirstOrDefault();
                if (p == null) return;
                p.Status = (int)RoleType.Creater;

                db.SubmitChanges();
            }
        }
    }
}
