using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CHSNS.NVelocityEngine {
	public class NVelocityViewLocator  : ViewLocator
    {
		public NVelocityViewLocator()
        {
            base.ViewLocationFormats = new string[] { "~/Views/{1}/{0}.vm",
                                                      "~/Views/{1}/{0}.vm",
                                                      "~/Views/Shared/{0}.vm",
                                                      "~/Views/Shared/{0}.vm"
            };
            base.MasterLocationFormats = new string[] { "" };
        }

	}
}
