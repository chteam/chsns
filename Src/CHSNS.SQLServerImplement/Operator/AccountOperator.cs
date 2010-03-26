﻿using System;
using System.Linq;
using CHSNS.Model;
using CHSNS.Operator;
using CHSNS.Models;

namespace CHSNS.SQLServerImplement.Operator
{
    public class AccountOperator : BaseOperator, IAccountOperator {
        public Profile Login(String userName, String password, int logOnScore)
        {
            using (var db = DBExtInstance)
            {
                long userId;
                long.TryParse(userName.Trim(), out userId);
                var userid = (from a in db.Account
                              where (a.UserName == userName || a.UserId == userId)
                                    && a.Password == password
                              select a.UserId).FirstOrDefault();
                if (userid <= 1000) return null;
                var profile = db.Profile.FirstOrDefault(p => p.UserId == userid);
                var retint = profile.Status;
                if (retint <= 0) return null;
                if (profile.LoginTime.Date != DateTime.Now.Date)
                {
                    profile.Score += logOnScore;
                    profile.ShowScore += logOnScore;
                    profile.LoginTime = DateTime.Now;
                    db.SubmitChanges();
                }
                return new Profile
                {
                    Name = profile.Name,
                    UserId = profile.UserId,
                    Status = retint,
                    Applications = profile.Applications
                };
            }

        }

        public bool Create(Account account, string name, int initScore)
        {
			account.Password = account.Password.ToMd5();
            account. Code = DateTime.Now.Ticks;
            using (var db = DBExtInstance)
            {
                db.Account.AddObject(account);
                db.SubmitChanges();
                if (account.UserId < 999) return false;
                db.Profile.AddObject(new Profile
                {
                    UserId = account.UserId,
                    Name = name,
                    ShowScore = initScore,
                    Score = initScore,
                    DelScore = 0,
                    Status = (int)RoleType.General,
                    RegTime = DateTime.Now,
                    LoginTime = DateTime.Now,
                    MagicBox = ""
                });
                db.BasicInformation.AddObject(
                    new BasicInformation
                    {
                        UserId = account.UserId,
                        Name = name
                    });
                db.SubmitChanges();
                return true;
            }
        }
        public bool IsUsernameCanUse(string username) {
            using (var db = DBExtInstance) {
                return db.Account.Where(c => c.UserName == username.Trim()).Count() == 0;
            }
        }


        public void InitCreater() {
            using (var db = DBExtInstance) {
                var p = db.Profile.FirstOrDefault();
                if (p == null) return;
                p.Status = (int)RoleType.Creater;
                db.SubmitChanges();
            }
        }
    }
}