using System;

//using System.Web.UI.WebControls;

namespace CHSNS {
	public static class EnumExtension {
		/// <summary>
		/// 转为Dictionary
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="e"></param>
		/// <returns></returns>
		static public Dictionary ToDictionary<T>(this Enum e) {
			var dict = new Dictionary();
			foreach (int s in Enum.GetValues(typeof(T))) {
				dict.Add(Enum.GetName(typeof(T), s), s);
			}
			return dict;
		}

		
	}
}
