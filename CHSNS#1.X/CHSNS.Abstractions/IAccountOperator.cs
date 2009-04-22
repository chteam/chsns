using CHSNS.Model;
namespace CHSNS.Operator {
	public interface IAccountOperator {
		bool Create(AccountPas account, string name);
		bool IsUsernameCanUse(string username);
		int Login(string userName, string password, bool autoLogin, bool isPasswordMd5,IContext context);
		void Logout(IContext context);
        /// <summary>
        /// 初始化创建者
        /// </summary>
        void InitCreater(); 
    }
}
