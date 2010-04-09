using System.Web.Mvc;

namespace CHSNS {
	public static class EmptyExt {
		public static ActionResult Empty(this Controller controller) {
			return new EmptyResult();
            
		}
	}
}