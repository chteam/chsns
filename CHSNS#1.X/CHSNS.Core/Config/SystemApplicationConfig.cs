using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.Config {
	[Serializable]
	public class SystemApplicationConfig {
		public IEnumerable<ApplicationItem> Items { get; set; }
	}
}
