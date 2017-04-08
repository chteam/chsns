namespace CHSNS.Encrypt {
    using System.Security.Cryptography;

    public static class SHACryptExtension {

    
        /// <summary>
        /// ����SHA256����
        /// </summary>
        /// <param name="strIn">Ҫ���ܵ��ַ���</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string SHA256Encrypt(string strIn) {
            
            using (SHA256 sha256 = SHA256.Create())
            {
                var tmpByte = sha256.ComputeHash(strIn.ToASCIIBytes());
                
                return tmpByte.ToHexUpperString();
            }
        }


        /// <summary>
        /// ����SHA512����
        /// </summary>
        /// <param name="strIn">Ҫ���ܵ��ַ���</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string SHA512Encrypt(string strIn) {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] tmpByte = sha512.ComputeHash(strIn.ToASCIIBytes());
                return tmpByte.ToHexUpperString();
            }

        }
    }
}