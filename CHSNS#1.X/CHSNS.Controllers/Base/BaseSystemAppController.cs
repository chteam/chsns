using CHSNS.Filter;

namespace CHSNS.Controllers {
	//
	
//	[DefaultAction("Index")]
//	[ControllerDetails(Area = "app")]
	[LoginedFilter]
	abstract public class BaseSystemAppController : BaseController {
		public void index() { }
	}
}