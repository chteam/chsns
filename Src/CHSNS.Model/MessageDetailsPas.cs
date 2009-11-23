using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.Model {
	public class MessageDetailsPas {
		public NameIdPas UserInbox { set; get; }
		public NameIdPas UserOutbox { set; get; }
		public MessageItemPas Message { set; get; }
	}
}
