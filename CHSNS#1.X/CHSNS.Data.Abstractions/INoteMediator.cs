using System;
using System.Linq;
using CHSNS.ModelPas;
using CHSNS.Models;
using System.Collections.Generic;
namespace CHSNS.Data {
	public interface INoteService {
		void Add(Note note);

		void Delete(long id, long pid, NoteType nt);
		NoteDetailsPas Details(long id, NoteType? nt);
		void Edit(Note note);
        List<NotePas> GetLastNotes(int? n);
        PagedList<NotePas> GetNotes(long pid, NoteType? nt, int p, int ep);
	}
}
