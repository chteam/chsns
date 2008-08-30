using System.Web.Mvc;
using CHSNS.Helper;

namespace CHSNS.Helper {
	public static class UrlHelperCHHelperExt {
		public static ChHelper CH(this UrlHelper vc) {
			return new ChHelper();
		}
	}
}
