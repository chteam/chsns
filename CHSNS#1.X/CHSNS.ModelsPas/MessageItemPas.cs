using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.ModelPas {
	public class MessageItemPas {
		public long ID { get; set; }
		public long UserID { get; set; }
		public string Username { get; set; }
		public string Title { get; set; }
		public DateTime SendTime { get; set; }
		public bool IsSee { get; set; }
		public string Body { get; set; }
	}
}
