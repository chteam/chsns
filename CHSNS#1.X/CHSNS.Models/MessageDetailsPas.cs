using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.ModelPas {
	public class MessageDetailsPas {
		public NameIDPas UserInbox { set; get; }
		public NameIDPas UserOutbox { set; get; }
		public MessageItemPas Message { set; get; }
	}
}
