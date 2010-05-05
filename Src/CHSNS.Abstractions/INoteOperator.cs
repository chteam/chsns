using System.Collections.Generic;
using CHSNS.Model;
using CHSNS.Models;
//

namespace CHSNS.Operator {
	public interface INoteOperator {
		void Add(Note note);

		void Delete(long id, long pid, NoteType nt);
		NoteDetailsPas Details(long id, NoteType? nt);
        void Edit(Note note);
        List<NotePas> GetLastNotes(int? n);
        PagedList<NotePas> GetNotes(long pid, NoteType? nt, int p, int ep);
	}
}
