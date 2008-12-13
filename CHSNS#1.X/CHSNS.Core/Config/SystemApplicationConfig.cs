using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.Config {
	[Serializable]
	public class SystemApplicationConfig {
		public List<ApplicationItem> Items { get; set; }
	}
}
