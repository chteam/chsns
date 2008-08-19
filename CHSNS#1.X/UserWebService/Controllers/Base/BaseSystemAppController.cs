namespace ChAlumna.Controllers {
	using Castle.MonoRail.Framework;
	[Filter(ExecuteEnum.BeforeAction, typeof(LoginedFilter))]
	[DefaultAction("Index")]
	[ControllerDetails(Area = "app")]
	abstract public class BaseSystemAppController : BaseController {
		public void index() { }
	}
}