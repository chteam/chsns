using System;
using System.Linq;
using CHSNS.Model;
using CHSNS.Models;
using System.Collections.Generic;
namespace CHSNS.Service {
	public interface INoteService {
		void Add(Note note);

		void Delete(long id, long pid, NoteType nt);
		NoteDetailsPas Details(long id, NoteType? nt);
		void Edit(Note note);
        List<NotePas> GetLastNotes(int? n);
        PagedList<NotePas> GetNotes(long pid, NoteType? nt, int p, int ep);
	}
}
