using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CHSNS.Models {
	public class CommentListPas {
		public int Nowpage { get; set; }
		public int EveryPage { get; set; }

		public long NoteID { get; set; }
		public long OwnerID { get; set; }
		public byte ShowType { get; set; }

		public long Count { get; set; }

		public string CountElement { get; set; }
		public DataRowCollection Rows { get; set; }

	}
}
