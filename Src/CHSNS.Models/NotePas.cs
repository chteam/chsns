using System;

namespace CHSNS.Model {
	public class NotePas {
		public long Id { get; set; }
		public string Title { get; set; }
		public long ViewCount { get; set; }
		public long CommentCount { get; set; }
		public DateTime AddTime { get; set; }
		public string WriteName { get; set; }
		public long UserId { get; set; }
		public string Body { get; set; }
		
	}
}
