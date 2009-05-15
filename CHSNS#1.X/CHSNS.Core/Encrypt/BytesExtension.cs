using System.Text;

namespace CHSNS {
    internal static class BytesExtension {

        /// <summary>
        /// 将byte数组转为大写字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static string ToHexUpperString(this byte[] data) {//加密转码
            var codes = new StringBuilder();
            for (var i = 0; i < data.Length; ++i) {
                codes.Append(data[i].ToString("x2"));
            }
            return codes.ToString().ToUpper();
        }        
        /// <summary>
        /// 将byte数组转为小写字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static string ToHexLowerString(this byte[] data) {//加密转码
            var codes = new StringBuilder();
            for (var i = 0; i < data.Length; ++i) {
                codes.Append(data[i].ToString("x2"));
            }
            return codes.ToString().ToLower();
        }
    }
}