using CHSNS.Models.Abstractions;

namespace CHSNS.Model {
	public class NoteDetailsPas {
		public UserCountPas User { get; set; }
		public INote Note { get; set; }
	}
}
