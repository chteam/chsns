using System;
using System.Collections.Generic;

namespace CHSNS.Config {
	[Serializable]
	public class SystemApplicationConfig {
		public List<ApplicationItem> Items { get; set; }
	}
}
