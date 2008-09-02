using System.Collections;

namespace CHSNS.Controllers
{
	//using Castle.Components.Common.EmailSender;
	using System.Web.Mvc;
	//using ChAlumna.TemplateEngine;
	//using ChAlumna.components;
//	[Rescue("index")]
	public class TestController : BaseBlockController 
	{
		//private DefaultControllerFactory factory;
		
		public ActionResult index() {
			string str = "";
			foreach (object  item in HttpContext.Session.Keys) {
				if (HttpContext.Session[item.ToString()] != null) 
					str += string.Format("{0}:{1}<br/>", item, HttpContext.Session[item.ToString()]);
			}
			return Content(str);
		}

		//#region NVelocity
		//public void nvelocity() {
		//    VelocityEngine velocity = new VelocityEngine();

		//    ExtendedProperties props = new ExtendedProperties();
		//    ArrayList paths = new ArrayList();
		//    paths.Add(".");
		//    paths.Add("C:\\Chsword\\Web\\");

		//    props.AddProperty("file.resource.loader.path", paths);

		//    velocity.Init(props);
		//    Template template = velocity.GetTemplate(@"\views\Components\utility.vm");





		//    StringWriter writer1 = new StringWriter();
		//        TextWriter sw = new StreamWriter(writer);
		//    NVelocityViewContextAdapter c=new NVelocityViewContextAdapter
		//    VelocityContext context = new VelocityContext();
		//    if (template != null) {
		//        template.Merge(context, writer1);
		//    }

		//    ViewData.Add("note", writer1.GetStringBuilder().ToString());

		//}
		//#endregion
		
	}
}
