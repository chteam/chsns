using System;
namespace CHSNS.Service {
	public interface IViewService {
		void Update(byte type,  long ownerid);
		CHSNS.Model.ViewListPas ViewList(byte type, int everyrow, long ownerid, int count);
	}
}
