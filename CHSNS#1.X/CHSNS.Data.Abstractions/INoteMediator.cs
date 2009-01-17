using System;
using System.Linq;
using CHSNS.ModelPas;
using CHSNS.Models;
namespace CHSNS.Data {
	public interface INoteMediator {
		void Add(Note note);

		void Delete(long id, long pid, NoteType nt);
		NoteDetailsPas Details(long id, NoteType? nt);
		void Edit(Note note);
		IQueryable<NotePas> GetLastNotes(int? n);
		IQueryable<NotePas> GetNotes(long pid, NoteType? nt);
	}
}
