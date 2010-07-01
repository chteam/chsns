using System.Security.Cryptography;

namespace CHSNS {
    public static class SHACryptExtension {
        /// <summary>
        /// ����SHA1(�׹�����)����
        /// </summary>
        /// <param name="strIn">Ҫ���ܵ��ַ���</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string ToSHA1(this string strIn) {
            using (SHA1 sha1 = new SHA1CryptoServiceProvider())
            {
                byte[] tmpByte = sha1.ComputeHash(strIn.ToASCIIBytes());
                sha1.Clear();
                return tmpByte.ToHexUpperString();
            }
        }

        /// <summary>
        /// ����SHA256����
        /// </summary>
        /// <param name="strIn">Ҫ���ܵ��ַ���</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string SHA256Encrypt(string strIn) {
            using (SHA256 sha256 = new SHA256Managed())
            {
                var tmpByte = sha256.ComputeHash(strIn.ToASCIIBytes());
                sha256.Clear();
                return tmpByte.ToHexUpperString();
            }
        }


        /// <summary>
        /// ����SHA512����
        /// </summary>
        /// <param name="strIn">Ҫ���ܵ��ַ���</param>
        /// <returns>���ܺ���ַ���</returns>
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