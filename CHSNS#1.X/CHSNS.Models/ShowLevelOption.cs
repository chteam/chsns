using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.Model {
	public class ShowLevelOption {
		public ShowLevelOption(string id, object selectedValue) {
			ID = id;
			SelectedValue = selectedValue;
		}
		public ShowLevelOption(string id, object selectedValue, string sourceStr) {
			ID = id;
			SelectedValue = selectedValue;
			SourceStr = sourceStr;
		}
		public string ID { get; set; }
		public string SourceStr { get; set; }
		public object SelectedValue { get; set; }
	}
}
