using System;
namespace CHSNS.Data {
	public interface INoteMediator {
		void Add(CHSNS.Models.Note note, long userid);
		int AddViewCount(long id);
		void Delete(long id, long userid);
		CHSNS.ModelPas.NoteDetailsPas Details(long id);
		void Edit(CHSNS.Models.Note note, long userid);
		System.Linq.IQueryable<CHSNS.ModelPas.NotePas> GetLastNotes();
		System.Linq.IQueryable<CHSNS.ModelPas.NotePas> GetNotes(long userid);
	}
}
