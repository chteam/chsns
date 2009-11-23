namespace ChAlumna.Controllers
{
	using Castle.MonoRail.Framework;
	public class PublicFilter : IFilter
	{
		public bool Perform(ExecuteEnum exec, IRailsEngineContext context, Controller controller) {
			return true;
		}
	}
}
