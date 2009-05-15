	using System;
	using System.IO;
	using System.Security.Cryptography;
	using System.Text;
namespace CHSNS
{


	/// <summary>
	/// 加密类,进行Has加密
	/// IsReturnNum:是否返回为加密后字符的Byte代码
	/// IsCaseSensitive：是否区分大小写。
	/// 方法：此类提供MD5，SHA1，SHA256，SHA512等四种算法，加密字串的长度依次增大。
	/// </summary>
	public class Encrypt
	{
		//private string strIN;
	//	private readonly bool isReturnNum;
		//private readonly bool isCaseSensitive;
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="IsCaseSensitive">是否区分大小写</param>
		/// <param name="IsReturnNum">是否返回为加密后字符的Byte代码</param>
        //public Encrypt(bool IsCaseSensitive, bool IsReturnNum)
        //{
        ////	isReturnNum = IsReturnNum;
        //    isCaseSensitive = IsCaseSensitive;
        //}
		/// <summary>
		/// 构造函数，区分大小写，且返回正常码
		/// </summary>
		public Encrypt() {
			//isReturnNum = false;
			//isCaseSensitive =false ;
		}





	


	}
}
