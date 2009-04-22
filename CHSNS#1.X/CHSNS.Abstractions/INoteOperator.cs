using CHSNS.Model;
using System.Collections.Generic;
using CHSNS.Abstractions;

namespace CHSNS.Operator {
	public interface INoteOperator {
		void Add(INote note);

		void Delete(long id, long pid, NoteType nt);
		NoteDetailsPas Details(long id, NoteType? nt);
        void Edit(INote note);
        List<NotePas> GetLastNotes(int? n);
        PagedList<NotePas> GetNotes(long pid, NoteType? nt, int p, int ep);
	}
}
