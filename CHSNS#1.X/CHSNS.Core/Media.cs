using System.Text.RegularExpressions;
using CHSNS;
namespace CHSNS {


	public class Media {
		static public string[] GetMediaPic(string url)
		{
			if (url.ToLower().StartsWith("http://player.youku.com/player.php/sid/")) {
				return getPicYouKu(url);
			}
			return new string[0];
		}

		static string[] getPicYouKu(string url) {
			string id = url.Replace(@"http://player.youku.com/player.php/sid/","").Replace(@"/v.swf","");
			string newurl = string.Format(
@"http://v.youku.com/player/getPlayList/VideoIDS/{0}/version/5/source/out?onData=%5Btype%20Function%5D&n=3"
			, id);
			var hp = new HttpProc(newurl);
			string html = hp.Proc().Replace(@"\/","/");
			var re = new Regex("(http://[^\"]+)[\\w\\W]+\"title\":\"([^\"]+)\"");//"http://([^\"]+)");
			Match m = re.Match(html);
			if (m.Success) {
				var ret = new string[2];
				ret[0] = m.Groups[1].Value;//0ÊÇurl
				ret[1] = Regular.UnicodeToChinese(m.Groups[2].Value);//1ÊÇtitle
				return ret;
			}
			return new string[0];
		}
	}
}
