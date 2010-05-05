namespace CHSNS.Operator
{
	public interface IViewOperator {
		void Update(byte type,  long ownerid,long myId);
        CHSNS.Model.ViewListPas ViewList(byte type, int everyrow, long ownerid, int count);
	}
}
