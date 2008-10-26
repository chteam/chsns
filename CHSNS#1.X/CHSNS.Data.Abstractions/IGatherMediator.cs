using System;
namespace CHSNS.Data {
	public interface IGatherMediator {
		CHSNS.ModelPas.EventPagePas EventGather(long userid);
	}
}
