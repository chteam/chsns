using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
//using System.Web.Mvc;

namespace CHSNS.NVelocityEngine {
	public class HtmlHelperAdapter : HtmlHelper {
		HtmlHelper HtmlHelper { get; set; }
		public HtmlHelperAdapter(System.Web.Mvc.ViewContext viewContext, System.Web.Mvc.IViewDataContainer viewDataContainer)
			:base(viewContext,viewDataContainer){}


	}
}
