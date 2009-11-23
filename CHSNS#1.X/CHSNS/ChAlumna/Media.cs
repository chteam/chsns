using System;
using System.Text.RegularExpressions;
using Chsword;
namespace CHSNS {


	public class Media {
		static public string[] GetMediaPic(string url) {
			if (url.ToLower().StartsWith("http://player.youku.com/player.php/sid/")) {
				return getPicYouKu(url);
			} else {
				return new string[0];
			}
		}
		static string[] getPicYouKu(string url) {
			string id = url.Replace(@"http://player.youku.com/player.php/sid/","").Replace(@"/v.swf","");
			string newurl = string.Format(
@"http://v.youku.com/player/getPlayList/VideoIDS/{0}/version/5/source/out?onData=%5Btype%20Function%5D&n=3"
			, id);
			HttpProc hp = new HttpProc(newurl);
			string html = hp.Proc().Replace(@"\/","/");
			Regex re = new Regex("(http://[^\"]+)[\\w\\W]+\"title\":\"([^\"]+)\"");//"http://([^\"]+)");
			Match m = re.Match(html);
			if (m.Success) {
				string[] ret = new string[2];
				ret[0] = m.Groups[1].Value;//0ÊÇurl
				ret[1] = Regular.UnicodeToChinese(m.Groups[2].Value);//1ÊÇtitle
				return ret;
			} else
				return new string[0];
		}
	}
}
