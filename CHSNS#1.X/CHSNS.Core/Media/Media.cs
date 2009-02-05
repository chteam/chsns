using System.Text.RegularExpressions;
using CHSNS;
namespace CHSNS {
	public class Media {
		public string Title { get; set; }
		public string Pic { get; set; }
		public Media(string videourl) {
			Title = Pic = "";
			if (videourl.ToLower().StartsWith("http://player.youku.com/player.php/sid/")) {
				getPicYouKu(videourl);
			}
		}
		void getPicYouKu(string url) {
			var id = url.Replace(@"http://player.youku.com/player.php/sid/", "").Replace(@"/v.swf", "");
			var newurl = string.Format(
@"http://v.youku.com/player/getPlayList/VideoIDS/{0}/version/5/source/out?onData=%5Btype%20Function%5D&n=3"
			, id);
			var hp = new HttpProc(newurl);
			var html = hp.Proc().Replace(@"\/", "/");
			var re = new Regex("(http://[^\"]+)[\\w\\W]+\"title\":\"([^\"]+)\"");//"http://([^\"]+)");
			var m = re.Match(html);
			if (!m.Success) return;
			Pic = m.Groups[1].Value;//0ÊÇurl
			Title = Regular.UnicodeToChinese(m.Groups[2].Value);//1ÊÇtitle
		}
	}
}
