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
		private readonly bool isReturnNum;
		private readonly bool isCaseSensitive;
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="IsCaseSensitive">是否区分大小写</param>
		/// <param name="IsReturnNum">是否返回为加密后字符的Byte代码</param>
		public Encrypt(bool IsCaseSensitive, bool IsReturnNum)
		{
			isReturnNum = IsReturnNum;
			isCaseSensitive = IsCaseSensitive;
		}
		/// <summary>
		/// 构造函数，区分大小写，且返回正常码
		/// </summary>
		public Encrypt() {
			isReturnNum = false;
			isCaseSensitive =false ;
		}

		public bool IsCaseSensitive
		{
			get { return isCaseSensitive; }
		}

		/// <summary>
		/// 进行SHA1(白宫密码)加密
		/// </summary>
		/// <param name="strIN">要加密的字符串</param>
		/// <returns>加密后的字符串</returns>
		public string SHA1Encrypt(string strIN)
		{
			//string strIN = getstrIN(strIN);
			SHA1 sha1 = new SHA1CryptoServiceProvider();

			byte[] tmpByte = sha1.ComputeHash(GetKeyByteArray(strIN));
			sha1.Clear();

			return GetStringValue(tmpByte);

		}
		/// <summary>
		/// 进行SHA256加密
		/// </summary>
		/// <param name="strIN">要加密的字符串</param>
		/// <returns>加密后的字符串</returns>
		public string SHA256Encrypt(string strIN)
		{
			//string strIN = getstrIN(strIN);
			SHA256 sha256 = new SHA256Managed();

			byte[] tmpByte = sha256.ComputeHash(GetKeyByteArray(strIN));
			sha256.Clear();

			return GetStringValue(tmpByte);

		}
		/// <summary>
		/// 进行SHA512加密
		/// </summary>
		/// <param name="strIN">要加密的字符串</param>
		/// <returns>加密后的字符串</returns>
		public string SHA512Encrypt(string strIN)
		{
			//string strIN = getstrIN(strIN);
			SHA512 sha512 = new SHA512Managed();

			byte[] tmpByte = sha512.ComputeHash(GetKeyByteArray(strIN));
			sha512.Clear();

			return GetStringValue(tmpByte);

		}

		/// <summary>
		/// 使用DES加密（Added by niehl 2005-4-6）
		/// </summary>
		/// <param name="originalValue">待加密的字符串</param>
		/// <param name="key">密钥(最大长度8)</param>
		/// <param name="IV">初始化向量(最大长度8)</param>
		/// <returns>加密后的字符串</returns>
		public string DESEncrypt(string originalValue, string key, string IV)
		{
			//将key和IV处理成8个字符
			key += "12345678";
			IV += "12345678";
			key = key.Substring(0, 8);
			IV = IV.Substring(0, 8);

			SymmetricAlgorithm sa = new DESCryptoServiceProvider
			                        	{
			                        		Key = Encoding.UTF8.GetBytes(key),
			                        		IV = Encoding.UTF8.GetBytes(IV)
			                        	};
			ICryptoTransform ct = sa.CreateEncryptor();

			byte[] byt = Encoding.UTF8.GetBytes(originalValue);

			var ms = new MemoryStream();
			var cs = new CryptoStream(ms, ct,
			                                   CryptoStreamMode.Write);
			cs.Write(byt, 0, byt.Length);
			cs.FlushFinalBlock();

			cs.Close();

			return Convert.ToBase64String(ms.ToArray());

		}
		/// <summary>
		/// 使用DES加密（Added by niehl 2005-4-6）
		/// </summary>
		/// <param name="originalValue">待加密的字符串</param>
		/// <param name="key">密钥(最大长度8)</param>
		/// <returns>加密后的字符串</returns>
		public string DESEncrypt(string originalValue, string key)
		{
			return DESEncrypt(originalValue, key, key);
		}

		/// <summary>
		/// 使用DES解密（Added by niehl 2005-4-6）
		/// </summary>
		/// <param name="encryptedValue">待解密的字符串</param>
		/// <param name="key">密钥(最大长度8)</param>
		/// <param name="IV">m初始化向量(最大长度8)</param>
		/// <returns>解密后的字符串</returns>
		public string DESDecrypt(string encryptedValue, string key, string IV)
		{
			try{
				//将key和IV处理成8个字符
				key += "12345678";
				IV += "12345678";
				key = key.Substring(0, 8);
				IV = IV.Substring(0, 8);

				SymmetricAlgorithm sa = new DESCryptoServiceProvider
				                        	{
				                        		Key = Encoding.UTF8.GetBytes(key),
				                        		IV = Encoding.UTF8.GetBytes(IV)
				                        	};
				ICryptoTransform ct = sa.CreateDecryptor();

				byte[] byt = Convert.FromBase64String(encryptedValue);

				var ms = new MemoryStream();
				var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
				cs.Write(byt, 0, byt.Length);
				cs.FlushFinalBlock();

				cs.Close();

				return Encoding.UTF8.GetString(ms.ToArray());
			}
			catch
			{
				return "";
			}

		}

		/// <summary>
		/// 使用DES解密（Added by niehl 2005-4-6）
		/// </summary>
		/// <param name="encryptedValue">待解密的字符串</param>
		/// <param name="key">密钥(最大长度8)</param>
		/// <returns>解密后的字符串</returns>
		public string DESDecrypt(string encryptedValue, string key)
		{
			return DESDecrypt(encryptedValue, key, key);
		}

		private string GetStringValue(byte[] Byte)
		{
			string tmpString = "";

			if (isReturnNum == false)
			{
				var Asc = new ASCIIEncoding();
				tmpString = Asc.GetString(Byte);
			}
			else
			{
				int iCounter;

				for
					(iCounter = 0; iCounter < Byte.Length; iCounter++)
				{
					tmpString = tmpString +
						Byte[iCounter];
				}

			}

			return tmpString;
		}

		private static byte[] GetKeyByteArray(string strKey)
		{

			var Asc = new ASCIIEncoding();

			byte[] tmpByte = Asc.GetBytes(strKey);

			return tmpByte;

		}

	}
}
