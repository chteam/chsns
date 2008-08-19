namespace ChAlumna.Controllers
{

	using System;
	using System.Linq;
	//using Castle.Components.Common.EmailSender;
	using Castle.MonoRail.Framework;
	using System.Collections.Generic;
	using ChAlumna.Models;
	using ChAlumna.Config;
	//using ChAlumna.TemplateEngine;
	//using ChAlumna.components;
	[Rescue("index")]
	public class testController : BaseBlockController 
	{
		//private DefaultControllerFactory factory;
		
		public void index() {
			var ret = (from u in DB.Account
					  where u.userid == 10000
					  select u.name).ToList();

			ViewData.Add("test", Template.TemplateEngine.ToString(new Dictionary(), "Mail/test.vm"));

			//RenderView("EmailSent");
			return;
			//throw new Exception("发出一个错误");
				#region aaaaaaa	//NVelocityViewEngine v = new NVelocityViewEngine();
			////;
			////v.Initialize();
			//StringWriter writer = new StringWriter();
			//v.Process(writer,
			//    Context,
			// factory.CreateController("test", "x"),
			//"x.vm"
			//);
			//this.x
			//ViewData.Add("note", writer.GetStringBuilder().ToString());
			//Castle.Components.Common.TemplateEngine.NVelocityTemplateEngine 


			
			//(engine as ISupportInitialize).BeginInit();

			//StringWriter writer = new StringWriter();
		//	StringWriter contextWriter = new StringWriter();
			//engine.Process(
			//    new Hashtable(),
			//    "ShouldProcessAStringTemplate",
			//    contextWriter,
			//    "#component(ad)"
			//    );
			
			

			//ViewData.Add("note", ChServer.MapPath(engine.TemplateDir));
			//engine.Process(
			//    new Hashtable(),
			//    //"ProfileEditChild\\Basic.vm",
			//    @"home\index.vm",
			//    contextWriter);
			//ViewData.Add("note", contextWriter.GetStringBuilder().ToString());
		//	ComponentDirective c = new ComponentDirective(new ViewCo;
		
	
			//ProfileEditChild p = new ProfileEditChild();
			
			//p.Template = "basic";
			
			//ViewData.Add("note", p.ToString());
			//ProfileEditChild p = new ProfileEditChild();
			//IRailsEngineContext railsContext = MonoRailHttpHandler.CurrentContext;
			//NVelocityViewEngine n = new NVelocityViewEngine();
			//n.Initialize();
			//n.Process(railsContext, this, @"\views\Components\ProfileEditChild\Basic.vm");
		//    IRailsEngineContext railsContext = MonoRailHttpHandler.CurrentContext;
			
		//    // NVelocityViewContextAdapter contextAdapter;
		//    //contextAdapter = new NVelocityViewContextAdapter(componentName, node, viewEngine, renderer);
		//    //contextAdapter.Context = context;
		//    //contextAdapter.TextWriter = writer;
		
		////	p.Init(railsContext, contextAdapter);
		
		//    //p.Context = Context;
			//    ViewData.Add("note", p.ToString());
			#endregion
			//return;
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
