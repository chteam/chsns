using System.Security.Cryptography;

namespace CHSNS {
    public static class SHACryptExtension {
        /// <summary>
        /// 进行SHA1(白宫密码)加密
        /// </summary>
        /// <param name="strIn">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string ToSHA1(this string strIn) {
            using (SHA1 sha1 = new SHA1CryptoServiceProvider())
            {
                byte[] tmpByte = sha1.ComputeHash(strIn.ToASCIIBytes());
                sha1.Clear();
                return tmpByte.ToHexUpperString();
            }
        }

        /// <summary>
        /// 进行SHA256加密
        /// </summary>
        /// <param name="strIn">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string SHA256Encrypt(string strIn) {
            using (SHA256 sha256 = new SHA256Managed())
            {
                var tmpByte = sha256.ComputeHash(strIn.ToASCIIBytes());
                sha256.Clear();
                return tmpByte.ToHexUpperString();
            }
        }


        /// <summary>
        /// 进行SHA512加密
        /// </summary>
        /// <param name="strIn">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string SHA512Encrypt(string strIn) {
            using (SHA512 sha512 = new SHA512Managed())
            {
                byte[] tmpByte = sha512.ComputeHash(strIn.ToASCIIBytes());
                sha512.Clear();
                return tmpByte.ToHexUpperString();
            }

        }
    }
}