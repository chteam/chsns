using System;
namespace CHSNS.Data {
	public interface IApplicationMediator {
		System.Collections.Generic.IList<CHSNS.Models.Application> Applications { get; }
		System.Collections.Generic.IList<CHSNS.Models.Application> GetApps(long[] ids);
	}
}
