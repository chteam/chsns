namespace CHSNS
{
	using System;
	using System.IO;
	using System.Security.Cryptography;
	using System.Text;
	using System.Web.Security;

	/// <summary>
	/// 加密类,进行Has加密
	/// IsReturnNum:是否返回为加密后字符的Byte代码
	/// IsCaseSensitive：是否区分大小写。
	/// 方法：此类提供MD5，SHA1，SHA256，SHA512等四种算法，加密字串的长度依次增大。
	/// </summary>
	public class Encrypt
	{
		//private string strIN;
		private bool isReturnNum;
		private bool isCaseSensitive;
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="IsCaseSensitive">是否区分大小写</param>
		/// <param name="IsReturnNum">是否返回为加密后字符的Byte代码</param>
		public Encrypt(bool IsCaseSensitive, bool IsReturnNum)
		{
			this.isReturnNum = IsReturnNum;
			this.isCaseSensitive = IsCaseSensitive;
		}
		/// <summary>
		/// 构造函数，区分大小写，且返回正常码
		/// </summary>
		public Encrypt() {
			this.isReturnNum = false;
			this.isCaseSensitive =false ;
		}

		private string getstrIN(string strIN)
		{
			//string strIN = strIN;
			if (strIN.Length == 0)
			{
				strIN = "~NULL~";
			}
			if (isCaseSensitive == false)
			{
				strIN = strIN.ToUpper();
			}
			return strIN;
		}
		/// <summary>
		/// Md5加密
		/// </summary>
		/// <param name="str">要加密的字符串</param>
		/// <param name="code">生成MD5码的位数16/32</param>
		/// <returns>返回MD5码</returns>
		public string MD5Encrypt(string str,int code)
		{
			if (code == 16)
			{
				return FormsAuthentication.HashPasswordForStoringInConfigFile(str.Trim(), "MD5").ToLower().Substring(8, 16);
			}
			if (code == 32)
			{
				return FormsAuthentication.HashPasswordForStoringInConfigFile(str.Trim(), "MD5");
			}
			return "00000000000000000000000000000000";
		}
		/// <summary>
		/// 进行SHA1(白宫密码)加密
		/// </summary>
		/// <param name="strIN">要加密的字符串</param>
		/// <returns>加密后的字符串</returns>
		public string SHA1Encrypt(string strIN)
		{
			//string strIN = getstrIN(strIN);
			byte[] tmpByte;
			SHA1 sha1 = new SHA1CryptoServiceProvider();

			tmpByte = sha1.ComputeHash(GetKeyByteArray(strIN));
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
			byte[] tmpByte;
			SHA256 sha256 = new SHA256Managed();

			tmpByte =
				sha256.ComputeHash(GetKeyByteArray(strIN));
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
			byte[] tmpByte;
			SHA512 sha512 = new SHA512Managed();

			tmpByte =
				sha512.ComputeHash(GetKeyByteArray(strIN));
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

			SymmetricAlgorithm sa;
			ICryptoTransform ct;
			MemoryStream ms;
			CryptoStream cs;
			byte[] byt;

			sa = new DESCryptoServiceProvider();
			sa.Key = Encoding.UTF8.GetBytes(key);
			sa.IV = Encoding.UTF8.GetBytes(IV);
			ct = sa.CreateEncryptor();

			byt = Encoding.UTF8.GetBytes(originalValue);

			ms = new MemoryStream();
			cs = new CryptoStream(ms, ct,
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

				SymmetricAlgorithm sa;
				ICryptoTransform ct;
				MemoryStream ms;
				CryptoStream cs;
				byte[] byt;

				sa = new DESCryptoServiceProvider();
				sa.Key = Encoding.UTF8.GetBytes(key);
				sa.IV = Encoding.UTF8.GetBytes(IV);
				ct = sa.CreateDecryptor();

				byt = Convert.FromBase64String(encryptedValue);

				ms = new MemoryStream();
				cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
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

			if (this.isReturnNum == false)
			{
				ASCIIEncoding Asc = new ASCIIEncoding();
				tmpString = Asc.GetString(Byte);
			}
			else
			{
				int iCounter;

				for
					(iCounter = 0; iCounter < Byte.Length; iCounter++)
				{
					tmpString = tmpString +
						Byte[iCounter].ToString();
				}

			}

			return tmpString;
		}

		private byte[] GetKeyByteArray(string strKey)
		{

			ASCIIEncoding Asc = new ASCIIEncoding();

			int tmpStrLen = strKey.Length;
			byte[] tmpByte = new byte[tmpStrLen - 1];

			tmpByte = Asc.GetBytes(strKey);

			return tmpByte;

		}

	}
}
