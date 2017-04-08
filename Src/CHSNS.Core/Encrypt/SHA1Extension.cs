namespace CHSNS.Encrypt {
    using System.Security.Cryptography;

    public static class SHACryptExtension {

    
        /// <summary>
        /// 进行SHA256加密
        /// </summary>
        /// <param name="strIn">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string SHA256Encrypt(string strIn) {
            
            using (SHA256 sha256 = SHA256.Create())
            {
                var tmpByte = sha256.ComputeHash(strIn.ToASCIIBytes());
                
                return tmpByte.ToHexUpperString();
            }
        }


        /// <summary>
        /// 进行SHA512加密
        /// </summary>
        /// <param name="strIn">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string SHA512Encrypt(string strIn) {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] tmpByte = sha512.ComputeHash(strIn.ToASCIIBytes());
                return tmpByte.ToHexUpperString();
            }

        }
    }
}