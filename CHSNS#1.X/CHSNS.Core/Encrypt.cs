	using System;
	using System.IO;
	using System.Security.Cryptography;
	using System.Text;
namespace CHSNS
{


	/// <summary>
	/// ������,����Has����
	/// IsReturnNum:�Ƿ񷵻�Ϊ���ܺ��ַ���Byte����
	/// IsCaseSensitive���Ƿ����ִ�Сд��
	/// �����������ṩMD5��SHA1��SHA256��SHA512�������㷨�������ִ��ĳ�����������
	/// </summary>
	public class Encrypt
	{
		//private string strIN;
		private readonly bool isReturnNum;
		private readonly bool isCaseSensitive;
		/// <summary>
		/// ���캯��
		/// </summary>
		/// <param name="IsCaseSensitive">�Ƿ����ִ�Сд</param>
		/// <param name="IsReturnNum">�Ƿ񷵻�Ϊ���ܺ��ַ���Byte����</param>
		public Encrypt(bool IsCaseSensitive, bool IsReturnNum)
		{
			isReturnNum = IsReturnNum;
			isCaseSensitive = IsCaseSensitive;
		}
		/// <summary>
		/// ���캯�������ִ�Сд���ҷ���������
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
		/// ����SHA1(�׹�����)����
		/// </summary>
		/// <param name="strIN">Ҫ���ܵ��ַ���</param>
		/// <returns>���ܺ���ַ���</returns>
		public string SHA1Encrypt(string strIN)
		{
			//string strIN = getstrIN(strIN);
			SHA1 sha1 = new SHA1CryptoServiceProvider();

			byte[] tmpByte = sha1.ComputeHash(GetKeyByteArray(strIN));
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
			SHA256 sha256 = new SHA256Managed();

			byte[] tmpByte = sha256.ComputeHash(GetKeyByteArray(strIN));
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
			SHA512 sha512 = new SHA512Managed();

			byte[] tmpByte = sha512.ComputeHash(GetKeyByteArray(strIN));
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
