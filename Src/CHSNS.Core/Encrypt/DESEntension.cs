namespace CHSNS.Encrypt
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// A extension method fot des encrypt.
    /// </summary>
    public static class DESEntension
    {
        /// <summary>
        /// ���ڲ�λ����Կ
        /// </summary>
        private const string Replacecryptorkey = "6sf8eIh";

        /// <summary>
        /// ʹ��DES���� chsword 2005-2-12
        /// </summary>
        /// <param name="originalValue">�� ���� �� �ַ���</param>
        /// <param name="key">��Կ (��󳤶� 8)</param>
        /// <param name="iv">��ʼ ������(��󳤶�8)</param>
        /// <returns>���� ��� �ַ� ��</returns>
        public static string DESEncrypt(this string originalValue, string key, string iv)
        {
            
            //��key��IV�����8���ַ�
            key = (key + Replacecryptorkey).Substring(0, 8);
            iv = (iv + Replacecryptorkey).Substring(0, 8);
            using (var sa = TripleDES.Create())
            {
                sa.Key = key.ToUTF8Bytes(); 
                sa.IV = iv.ToUTF8Bytes();
                using (var ct = sa.CreateEncryptor())
                {
                    byte[] byt = originalValue.ToUTF8Bytes();
                    using (var ms = new MemoryStream())
                    {
                        var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                        cs.Write(byt, 0, byt.Length);
                        cs.FlushFinalBlock();
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// ʹ��DES���ܣ�Added by niehl 2005-4-6��
        /// </summary>
        /// <param name="originalValue">�����ܵ��ַ���</param>
        /// <param name="key">��Կ(��󳤶�8)</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string DESEncrypt(this string originalValue, string key)
        {
            return originalValue.DESEncrypt(key, key);
        }

        /// <summary>
        /// ʹ��DES���ܣ�Added by chsword 2005-2-12��
        /// </summary>
        /// <param name="encryptedValue">�����ܵ��ַ���</param>
        /// <param name="key">��Կ(��󳤶�8)</param>
        /// <param name="iv">m��ʼ������(��󳤶�8)</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string DESDecrypt(this string encryptedValue, string key, string iv)
        {
            ////��key��IV�����8���ַ�
            var keyBytes = Encoding.UTF8.GetBytes((key + Replacecryptorkey).Substring(0, 8));
            var ivBytes = Encoding.UTF8.GetBytes((iv + Replacecryptorkey).Substring(0, 8));
            using (var sa =TripleDES.Create())
            {
                sa.Key = keyBytes;
                sa.IV = ivBytes;
                using (var ct = sa.CreateDecryptor())
                {
                    byte[] byt = Convert.FromBase64String(encryptedValue);
                    using (var ms = new MemoryStream())
                    {
                        var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);

                        cs.Write(byt, 0, byt.Length);
                        cs.FlushFinalBlock();

                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// ʹ��DES���ܣ�Added by niehl 2005-4-6��
        /// </summary>
        /// <param name="encryptedValue">�����ܵ��ַ���</param>
        /// <param name="key">��Կ(��󳤶�8)</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string DESDecrypt(this string encryptedValue, string key)
        {
            return encryptedValue.DESDecrypt(key, key);
        }
    }
}