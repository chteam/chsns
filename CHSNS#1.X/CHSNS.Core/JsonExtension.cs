using Newtonsoft.Json.Linq;

namespace CHSNS
{
	public static class JsonExtension
	{
		public static JObject ToJObject(this string str)
		{
			var o = JObject.Parse(str);
			return o ;
		}
	}
}
