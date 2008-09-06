using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.Models {
	public class MessageDetailsPas {
		public UserItemPas UserInbox { set; get; }
		public UserItemPas UserOutbox { set; get; }
		public Message Message { set; get; }
	}
}
