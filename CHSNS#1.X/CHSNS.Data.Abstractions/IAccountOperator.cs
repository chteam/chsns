using CHSNS.Model;
namespace CHSNS.Operator {
	public interface IAccountOperator {
		bool Create(AccountPas account, string name);
		bool IsUsernameCanUse(string username);
		int Login(string Username, string Password, bool IsAutoLogin, bool IsPasswordMd5);
		void Logout();
        /// <summary>
        /// 初始化创建者
        /// </summary>
        void InitCreater(); 
    }
}
