namespace ChAlumna.Controllers {
	using System;
	using Castle.MonoRail.Framework;
	public class AdminFilter : IFilter {
		public bool Perform(ExecuteEnum exec, IRailsEngineContext context, Controller controller) {
			if (!ChSession.isAdmin) {
				context.Response.Redirect("event", "index");
				return false;
			}
			return true;
		}
	}
}
