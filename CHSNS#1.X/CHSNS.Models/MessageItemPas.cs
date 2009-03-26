using System;

namespace CHSNS.Model {
	public class MessageItemPas {
		public long ID { get; set; }
		public long UserID { get; set; }
		public string Username { get; set; }
		public string Title { get; set; }
		public DateTime SendTime { get; set; }
		public bool IsSee { get; set; }
        public bool IsHtml { get; set; }
		public string Body { get; set; }
	}
}
