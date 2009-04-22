using System.Data;

namespace CHSNS.Models {
	public class EventPagePas {
		public long FriendRequestCount { get; set; }
		public long ViewCount { get; set; }
		public long ReplyCount { get; set; }
		public DataRowCollection NewReply { get; set; }
		public DataRowCollection RssSource { get; set; }
	}
}
