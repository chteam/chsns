
namespace ChAlumna.Controllers
{
	using Castle.MonoRail.Framework;
	//[Rescue("/error")]
	[Layout("basemaster")]
	public class RescuesController : SmartDispatcherController
	{
	//	[Rescue("/argerror", typeof(ArgumentException))]
		public void Index() {
			//throw new ArgumentException("dddd");
			//throw new Exception("fff");
		}
	}
}
