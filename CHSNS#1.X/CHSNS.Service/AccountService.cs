using System;
using CHSNS.Model;
using CHSNS.Operator;

namespace CHSNS.Service
{
    public class AccountService
    {
        static readonly AccountService _instance = new AccountService();
        private readonly IAccountOperator Account;
        public AccountService(){
            Account = new AccountOperator();
        }

        public static AccountService GetInstance(){
            return _instance;
        }

        /// <summary>
        /// 注销
        /// </summary>
        public void Logout(IContext context)
        {
            Account.Logout(context);
        }
        public int Login(String Username, String Password, Boolean IsAutoLogin, Boolean IsPasswordMd5,IContext context)
        {
            return Account.Login(Username, Password, IsAutoLogin, IsPasswordMd5, context);
        }

        public bool Create(AccountPas account, string name)
        {
            return Account.Create(account, name);
        }
        public bool IsUsernameCanUse(string username)
        {
            return Account.IsUsernameCanUse(username);
        }


        public void InitCreater()
        {
            Account.InitCreater();
        }
    }
}
