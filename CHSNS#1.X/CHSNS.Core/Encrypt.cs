namespace CHSNS
{
	using System;
	using System.IO;
	using System.Security.Cryptography;
	using System.Text;
	using System.Web.Security;

	/// <summary>
	/// ������,����Has����
	/// IsReturnNum:�Ƿ񷵻�Ϊ���ܺ��ַ���Byte����
	/// IsCaseSensitive���Ƿ����ִ�Сд��
	/// �����������ṩMD5��SHA1��SHA256��SHA512�������㷨�������ִ��ĳ�����������
	/// </summary>
	public class Encrypt
	{
		//private string strIN;
		private bool isReturnNum;
		private bool isCaseSensitive;
		/// <summary>
		/// ���캯��
		/// </summary>
		/// <param name="IsCaseSensitive">�Ƿ����ִ�Сд</param>
		/// <param name="IsReturnNum">�Ƿ񷵻�Ϊ���ܺ��ַ���Byte����</param>
		public Encrypt(bool IsCaseSensitive, bool IsReturnNum)
		{
			this.isReturnNum = IsReturnNum;
			this.isCaseSensitive = IsCaseSensitive;
		}
		/// <summary>
		/// ���캯�������ִ�Сд���ҷ���������
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
		/// Md5����
		/// </summary>
		/// <param name="str">Ҫ���ܵ��ַ���</param>
		/// <param name="code">����MD5���λ��16/32</param>
		/// <returns>����MD5��</returns>
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
		/// ����SHA1(�׹�����)����
		/// </summary>
		/// <param name="strIN">Ҫ���ܵ��ַ���</param>
		/// <returns>���ܺ���ַ���</returns>
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
		/// ����SHA256����
		/// </summary>
		/// <param name="strIN">Ҫ���ܵ��ַ���</param>
		/// <returns>���ܺ���ַ���</returns>
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
		/// ����SHA512����
		/// </summary>
		/// <param name="strIN">Ҫ���ܵ��ַ���</param>
		/// <returns>���ܺ���ַ���</returns>
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
		/// ʹ��DES���ܣ�Added by niehl 2005-4-6��
		/// </summary>
		/// <param name="originalValue">�����ܵ��ַ���</param>
		/// <param name="key">��Կ(��󳤶�8)</param>
		/// <param name="IV">��ʼ������(��󳤶�8)</param>
		/// <returns>���ܺ���ַ���</returns>
		public string DESEncrypt(string originalValue, string key, string IV)
		{
			//��key��IV�����8���ַ�
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
		/// ʹ��DES���ܣ�Added by niehl 2005-4-6��
		/// </summary>
		/// <param name="originalValue">�����ܵ��ַ���</param>
		/// <param name="key">��Կ(��󳤶�8)</param>
		/// <returns>���ܺ���ַ���</returns>
		public string DESEncrypt(string originalValue, string key)
		{
			return DESEncrypt(originalValue, key, key);
		}

		/// <summary>
		/// ʹ��DES���ܣ�Added by niehl 2005-4-6��
		/// </summary>
		/// <param name="encryptedValue">�����ܵ��ַ���</param>
		/// <param name="key">��Կ(��󳤶�8)</param>
		/// <param name="IV">m��ʼ������(��󳤶�8)</param>
		/// <returns>���ܺ���ַ���</returns>
		public string DESDecrypt(string encryptedValue, string key, string IV)
		{
			try{
				//��key��IV�����8���ַ�
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
		/// ʹ��DES���ܣ�Added by niehl 2005-4-6��
		/// </summary>
		/// <param name="encryptedValue">�����ܵ��ַ���</param>
		/// <param name="key">��Կ(��󳤶�8)</param>
		/// <returns>���ܺ���ַ���</returns>
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
