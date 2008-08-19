/*
 * ×Þ½¡ 2008-1-24 
 * 
*/
namespace ChAlumna.Controllers
{
    using System;
	using Castle.MonoRail.Framework;
	[Filter(ExecuteEnum.BeforeAction, typeof(LoginedFilter))]
    public class ApplicationController : BaseController
    {
        public void myapp() {
			Application app = new Application();
			ViewData.Add("rows", app.MyApplicationRows());
        }
    }
}
