namespace CHSNS.Helper {
	//
	public class PersonalHelper
    {
		public string TrimLast(string s) {
			if (!string.IsNullOrEmpty(s))
				s = s.Remove(s.Length - 1);
			return s;
		}
    }
}
