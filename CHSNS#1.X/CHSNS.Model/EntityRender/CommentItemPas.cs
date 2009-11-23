using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.Models {
	public class CommentItemPas {
		public long ID { get; set; }
		public long OwnerID { get; set; }
		public DateTime AddTime { get; set; }
		public string Body { get; set; }
		public bool IsDel { get; set; }
	}
}
