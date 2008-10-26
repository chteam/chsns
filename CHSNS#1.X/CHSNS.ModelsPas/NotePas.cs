using System;

namespace CHSNS.ModelPas {
	public class NotePas {
		public long ID { get; set; }
		public string Title { get; set; }
		public long ViewCount { get; set; }
		public long CommentCount { get; set; }
		public DateTime AddTime { get; set; }
		public string WriteName { get; set; }
		public long UserID { get; set; }
		public string Body { get; set; }
	}
}
