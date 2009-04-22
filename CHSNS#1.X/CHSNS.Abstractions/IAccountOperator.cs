using CHSNS.Abstractions;
using CHSNS.Model;
namespace CHSNS.Operator {
	public interface IAccountOperator {
        bool Create(AccountPas account, string name, int initScore);
		bool IsUsernameCanUse(string username);
		IProfile Login(string userName, string password,int logOnScore);
		
        /// <summary>
        /// 初始化创建者
        /// </summary>
        void InitCreater(); 
    }
}
