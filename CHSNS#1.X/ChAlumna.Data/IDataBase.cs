
namespace CHSNS.Data
{
	using System.Collections;
	using System.Data;
	using ChAlumna.Models;
	public interface IDataBase
	{
		IDictionary Session {
			get;
			set;
		}
		DataRowCollection RssList(int count);
		DataRowCollection UserListRows(long ownerid, int nowpage, byte type);
		DataRowCollection MyApplicationRows { get;}
		void Note_Add(Note l);
		void Note_Edit(Note l);
		void Comment_Remove(long id);
		int UserStatus(long userid, long? groupid);
	}
}
