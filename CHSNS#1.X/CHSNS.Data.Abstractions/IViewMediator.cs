using System;
namespace CHSNS.Data {
	public interface IViewService {
		void ViewCreate(byte type, int everyrow, long ownerid);
		CHSNS.ModelPas.ViewListPas ViewList(byte type, int everyrow, long ownerid, int count);
	}
}
