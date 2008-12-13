using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace CHSNS {
	public static class EnumExtension {
		static public Dictionary ToDictionary<T>(this Enum e) {
			var dict = new Dictionary();
			foreach (int s in Enum.GetValues(typeof(T))) {
				dict.Add(Enum.GetName(typeof(T), s), s);
			}
			return dict;
		}
		static public List<ListItem> ToListItem<T>() {
			var li = new List<ListItem>();
			foreach (int s in Enum.GetValues(typeof(T))) {
				li.Add(new ListItem {
					Value = s.ToString(),
					Text = Enum.GetName(typeof(T), s)
				}
				);
			}
			return li;
		}
	}
}
