using System.Collections;

namespace CHSNS
{
	public static class JsonExtension
	{
		public static Hashtable ToJObject(this string str)
		{
			var o = JsonAdapter.Deserialize<Hashtable>(str);
			return o ;
		}
	}
}
