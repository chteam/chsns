using System.Collections;

namespace CHSNS.Helper
{

	public class StringHelper 
	{
		public string TagsEncode(string v) {
			//v = ServerUtility.UrlEncode(v);
			return v.Replace(".", "%2E");
		}

		public IList Split(string str, string sp) {
			if (str.EndsWith(sp) || str.StartsWith(sp)) {
				str = str.Trim(sp.ToCharArray());
			}
			return str.Split(sp.ToCharArray());
		}
		public string TrimLast(string s) {
			if (!string.IsNullOrEmpty(s))
				s = s.Remove(s.Length - 1);
			return s;
		}
		public string DateDiv(object o) {
			return Date.GetTimeDiv(o);
		}
	}
}
