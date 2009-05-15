using System.Globalization;
using System.IO;
using System.Text;

namespace CHSNS {
    public static class HtmlEncodeExtension {
        public static string HtmlEncode(this string s) {
            if (s == null) {
                return null;
            }
            var sb = new StringBuilder();
            var output = new StringWriter(sb);
            HtmlEncode(s, output);
            return sb.ToString();
        }



        static void HtmlEncode(string s, TextWriter output) {
            var length = s.Length;
            for (var i = 0; i < length; i++) {
                var ch = s[i];
                var ch2 = ch;
                if (ch2 != '"') {
                    switch (ch2) {
                        case '<':
                            output.Write("&lt;");
                            goto Label_00AE;

                        case '=':
                            goto Label_0071;

                        case '>':
                            output.Write("&gt;");
                            goto Label_00AE;

                        case '&':
                            goto Label_0064;
                    }
                    goto Label_0071;
                }
                output.Write("&quot;");
                goto Label_00AE;
            Label_0064:
                output.Write("&amp;");
                goto Label_00AE;
            Label_0071:
                if ((ch >= '\x00a0') && (ch < 'Ā')) {
                    output.Write("&#" + ((int)ch).ToString(NumberFormatInfo.InvariantInfo) + ";");
                }
                else {
                    output.Write(ch);
                }
            Label_00AE:
                ;
            }
        }
    }
}