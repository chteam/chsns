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
        const int KEYLENGTH = 24;
        const int VILENGTH = 8;
        /// <summary>
        /// 用于补位的密钥
        /// </summary>
        private const string Replacecryptorkey = "0ac1c24311e940bb993027bc8a0e97b0569b4c72728945e696df5f6fde80e0746f873cdcdac040a49da7e7428434d4ca88d4fa871fd34dbfb5cb3c6b8427fb1b";

        /// <summary>
        /// 使用DES加密 chsword 2005-2-12
        /// </summary>
        /// <param name="originalValue">待 加密 的 字符串</param>
        /// <param name="key">密钥 (最大长度 8)</param>
        /// <param name="iv">初始 化向量(最大长度8)</param>
        /// <returns>加密 后的 字符 串</returns>
        public static string DESEncrypt(this string originalValue, string key, string iv)
        {

            //将key和IV处理成8个字符
            var keyBytes = $"{key}{Replacecryptorkey}".Substring(0, KEYLENGTH).ToUTF8Bytes();
            var ivBytes = $"{iv}{Replacecryptorkey}".Substring(0, VILENGTH).ToUTF8Bytes();
            using (var sa = TripleDES.Create())
            {
                using (var ct = sa.CreateEncryptor(keyBytes, ivBytes))
                {
                    byte[] byt = originalValue.ToUTF8Bytes();
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                        {
                            cs.Write(byt, 0, byt.Length);
                            cs.FlushFinalBlock();
                            return Convert.ToBase64String(ms.ToArray());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 使用DES加密（Added by niehl 2005-4-6）
        /// </summary>
        /// <param name="originalValue">待加密的字符串</param>
        /// <param name="key">密钥(最大长度8)</param>
        /// <returns>加密后的字符串</returns>
        public static string DESEncrypt(this string originalValue, string key)
        {
            return originalValue.DESEncrypt(key, key);
        }

        /// <summary>
        /// 使用DES解密（Added by chsword 2005-2-12）
        /// </summary>
        /// <param name="encryptedValue">待解密的字符串</param>
        /// <param name="key">密钥(最大长度8)</param>
        /// <param name="iv">m初始化向量(最大长度8)</param>
        /// <returns>解密后的字符串</returns>
        public static string DESDecrypt(this string encryptedValue, string key, string iv)
        {
            //将key和IV处理成8个字符
 
            var keyBytes = Encoding.UTF8.GetBytes($"{key}{Replacecryptorkey}".Substring(0, KEYLENGTH));
            var ivBytes = Encoding.UTF8.GetBytes($"{iv}{Replacecryptorkey}".Substring(0, VILENGTH));

            using (var sa =TripleDES.Create())
            {
                using (var ct = sa.CreateDecryptor(keyBytes, ivBytes))
                {
                    byte[] byt = Convert.FromBase64String(encryptedValue);
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                        {
                            cs.Write(byt, 0, byt.Length);
                            cs.FlushFinalBlock();
                            return Encoding.UTF8.GetString(ms.ToArray());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 使用DES解密（Added by niehl 2005-4-6）
        /// </summary>
        /// <param name="encryptedValue">待解密的字符串</param>
        /// <param name="key">密钥(最大长度8)</param>
        /// <returns>解密后的字符串</returns>
        public static string DESDecrypt(this string encryptedValue, string key)
        {
            return encryptedValue.DESDecrypt(key, key);
        }
    }
}