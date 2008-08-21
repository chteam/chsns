using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
//using System.Web.Mvc;

namespace CHSNS.NVelocityEngine {
	public class HtmlHelperAdapter {
		HtmlHelper HtmlHelper { get; set; }
		public HtmlHelperAdapter(System.Web.Mvc.ViewContext viewContext, System.Web.Mvc.IViewDataContainer viewDataContainer)
			{
			HtmlHelper = new HtmlHelper(viewContext, viewDataContainer);
		}
		public HtmlHelperAdapter(HtmlHelper hh) {
			HtmlHelper = hh;
		}
		public string RenderUserControl(string virtualPath) {
			//throw new Exception(virtualPath);
			return HtmlHelper.RenderUserControl(virtualPath);
				
		}
		public string RenderUserControl(string virtualPath, object controlData) {
			return HtmlHelper.RenderUserControl(virtualPath, controlData);
		}
		public string RenderUserControl(string virtualPath, object controlData, object propertySettings) {
			return HtmlHelper.RenderUserControl(virtualPath, controlData, propertySettings);
		}
	}
}
