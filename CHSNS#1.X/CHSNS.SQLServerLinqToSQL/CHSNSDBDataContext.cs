using System;
namespace CHSNS.Models {
	public partial class CHSNSDBDataContext {
		//public CHSNSDBDataContext(string s) : base(s) { }
		//public CHSNSDBDataContext(EntityConnection connection) : base(connection) { }

		public Guid NEWID() {
			return Guid.NewGuid();
		}

		public void SaveChanges(){
			this.SubmitChanges();
		}
		public void AddToNote(Note note){
			this.Note.InsertOnSubmit(note);
		}
		public void AddToEntry(Entry entry) {
			Entry.InsertOnSubmit(entry);
		}
		public void AddToEntryVersion(EntryVersion entryversion) {
			EntryVersion.InsertOnSubmit(entryversion);
		}
		
	}
}


