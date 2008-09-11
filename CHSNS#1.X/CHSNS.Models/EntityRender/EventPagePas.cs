using System.Data;

namespace CHSNS.Models {
	public class EventPagePas {
		public int FriendRequestCount { get; set; }
		public int ViewCount { get; set; }
		public int CommentCount { get; set; }
		public DataRowCollection NewReply { get; set; }
		public DataRowCollection RssSource { get; set; }
	}
}
