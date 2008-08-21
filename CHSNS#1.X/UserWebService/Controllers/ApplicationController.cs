/*
 * ×Þ½¡ 2008-1-24 
 * 
*/
namespace CHSNS.Controllers
{
    using System;
	
	[LoginedFilter]
    public class ApplicationController : BaseController
    {
        public void myapp() {
			Application app = new Application();
			ViewData.Add("rows", app.MyApplicationRows());
        }
    }
}
