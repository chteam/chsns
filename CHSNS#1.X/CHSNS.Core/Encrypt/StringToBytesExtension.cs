using System.Text;

namespace CHSNS
{
    internal static class StringToBytesExtension
    {
        internal static byte[] ToASCIIBytes(this string strKey) {
            return Encoding.ASCII.GetBytes(strKey);
        }
        internal static byte[] ToUTF8Bytes(this string strKey) {
            return Encoding.UTF8 .GetBytes(strKey);
        }
    }
}