using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHSNS;

namespace System.Web.Mvc {
	public static class PathExt {
		public static CHPath Path(this UrlHelper u){
			return new CHPath();
		}
	}
}
