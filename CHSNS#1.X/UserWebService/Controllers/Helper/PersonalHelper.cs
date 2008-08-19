namespace ChAlumna {
	using Castle.MonoRail.Framework.Helpers;
	public class PersonalHelper : AbstractHelper
    {
		public string TrimLast(string s) {
			if (!string.IsNullOrEmpty(s))
				s = s.Remove(s.Length - 1);
			return s;
		}
    }
}
