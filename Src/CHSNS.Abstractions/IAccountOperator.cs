using CHSNS.Models;
namespace CHSNS.Operator {
	public interface IAccountOperator {
        bool Create(Account account, string name, int initScore);
		bool IsUsernameCanUse(string username);
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名或Id</param>
        /// <param name="password">密钥</param>
        /// <param name="logOnScore">登录后得到的积分</param>
        /// <returns></returns>
		Profile Login(string userName, string password,int logOnScore);
		
        /// <summary>
        /// 初始化创建者
        /// </summary>
        void InitCreater(); 
    }
}
