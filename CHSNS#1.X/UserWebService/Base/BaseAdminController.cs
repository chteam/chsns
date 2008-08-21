
namespace ChAlumna.Controllers {
	using Castle.MonoRail.Framework;
	[Filter(ExecuteEnum.BeforeAction, typeof(AdminFilter))]
	[Helper(typeof(StringHelper))]
	[Layout("adminmaster")]
	[ControllerDetails(Area = "Admin")]
	abstract public class BaseAdminController : BaseBlockController {
	} 

}
