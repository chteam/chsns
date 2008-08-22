using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CHSNS  {
	public static class UrlHelperCHHelperExt {
		public static ChHelper CH(this UrlHelper vc) {
			return new ChHelper();
		}
	}
}
