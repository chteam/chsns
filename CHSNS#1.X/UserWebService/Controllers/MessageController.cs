/*
 * ×Þ½¡ 08-1-24
 */
namespace ChAlumna.Controllers
{
    using System;
	using Castle.MonoRail.Framework;
	[Filter(ExecuteEnum.BeforeAction, typeof(LoginedFilter))]
    public class MessageController : BaseController
    {
        public void index() {
            int tabs;
            switch (QueryString("mode")) {
                case "sent":
                    tabs = 1;
                    break;
                case "compose":
                    tabs = 2;
                    break;
                case "read":
                    tabs = 3;
                    break;
                case "inbox":
                default:
                    tabs = 0;
                    break;
            }
            ViewData.Add("tabs", tabs);
            ViewData.Add("Toid", QueryLong("Toid"));
			ViewData.Add("Toname", QueryString("Toname"));
        }
    }
}
