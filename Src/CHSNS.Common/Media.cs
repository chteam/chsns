using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CHSNS
{
    public class Media
    {
        public Media(string videourl)
        {
            Title = Pic = "";
            if (videourl.ToLower().StartsWith("http://player.youku.com/player.php/sid/"))
            {
                GetPicYouKu(videourl);
            }
        }

        public string Title { get; set; }
        public string Pic { get; set; }

        private void GetPicYouKu(string url)
        {
            string id = url.Replace(@"http://player.youku.com/player.php/sid/", "").Replace(@"/v.swf", "");
            string newurl = string.Format(
                @"http://v.youku.com/player/getPlayList/VideoIDS/{0}/version/5/source/out?onData=%5Btype%20Function%5D&n=3"
                , id);
            var hp = new HttpProc(newurl);
            string html = hp.Proc().Replace(@"\/", "/");
            var re = new Regex("(http://[^\"]+)[\\w\\W]+\"title\":\"([^\"]+)\""); //"http://([^\"]+)");
            Match m = re.Match(html);
            if (!m.Success) return;
            Pic = m.Groups[1].Value; //0ÊÇurl
            Title = UnicodeToChinese(m.Groups[2].Value); //1ÊÇtitle
        }

        private static string UnicodeToChinese(string str)
        {
            return ConvertTo(str, "unicode");
        }

        private static string ConvertTo(string str, string encode)
        {
            var tmpStr = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '\\' && str[i + 1] == 'u')
                {
                    string s1 = str.Substring(i + 2, 2);
                    string s2 = str.Substring(i + 4, 2);
                    int t1 = Convert.ToInt32(s1, 16);
                    int t2 = Convert.ToInt32(s2, 16);
                    var array = new byte[2];
                    array[0] = (byte) t2;
                    array[1] = (byte) t1;
                    string s = Encoding.GetEncoding(encode).GetString(array);
                    tmpStr.Append(s);
                    i = i + 5;
                }
                else
                {
                    tmpStr.Append(str[i]);
                }
            }
            return tmpStr.ToString();
        }
    }
}