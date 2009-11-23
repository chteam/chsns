using CHSNS.Model;

namespace CHSNS.Operator
{
	public interface IGatherOperator
	{
		EventPagePas EventGather(long userid);
	}
}