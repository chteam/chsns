using System;
using System.Collections;
using System.IO;
using System.Web.Mvc;
using Commons.Collections;
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;
using System.Web;

namespace CHSNS.NVelocityEngine
{
	public class NVelocityViewEngine : IViewEngine
	{
		private static readonly IDictionary DEFAULT_PROPERTIES = new Hashtable();
		private readonly VelocityEngine _engine;
		private readonly string _masterFolder;

		static NVelocityViewEngine()
		{
			string targetViewFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "views");
			DEFAULT_PROPERTIES.Add(RuntimeConstants.RESOURCE_LOADER, "file");
			DEFAULT_PROPERTIES.Add(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, targetViewFolder);
			DEFAULT_PROPERTIES.Add("master.folder", "masters");
		}

		public NVelocityViewEngine() : this(DEFAULT_PROPERTIES)
		{
		}

		public NVelocityViewEngine(IDictionary properties)
		{
			if( properties == null ) properties = DEFAULT_PROPERTIES;
			ExtendedProperties props = new ExtendedProperties();
			foreach(string key in properties.Keys)
			{
				props.AddProperty(key, properties[key]);
			}

			_masterFolder = props.GetString("master.folder", string.Empty);

			_engine = new VelocityEngine();
			_engine.Init(props);
		}
		public void RenderView(ViewContext viewContext) {
			CreateView(viewContext).RenderView();
		}

		#region Resole masterpage/view
		public NVelocityView CreateView(ViewContext viewContext) {
			string controllerName = (string)viewContext.RouteData.Values["controller"];
			string controllerFolder = controllerName;
			
			Template viewTemplate = ResolveView(viewContext);
			
			Template masterTemplate = ResolveMaster(viewContext);
			NVelocityView view = new NVelocityView(viewTemplate, masterTemplate, viewContext);
			return view;
		}
		private Template ResolveMaster(ViewContext viewContext) {
			Template masterTemplate = null;
			if (!string.IsNullOrEmpty(viewContext.MasterName)) {
				string masterPath = ViewLocator.GetMasterLocation(viewContext, viewContext.MasterName);
				
				if (!_engine.TemplateExists(masterPath))
					throw new InvalidOperationException("Could not find view for master template named " + viewContext.MasterName +
														". I searched for '" + masterPath + "' file. Maybe the file doesn't exist?");
				masterTemplate = _engine.GetTemplate(masterPath);
			}
			return masterTemplate;
		}

		private Template ResolveView(ViewContext viewContext) {
			string viewPath = ViewLocator.GetViewLocation(viewContext, viewContext.ViewName);
			if (!_engine.TemplateExists(viewPath))
				throw new InvalidOperationException("Could not find view " + viewContext.ViewName +
													". I searched for '" + viewPath + "' file. Maybe the file doesn't exist?");
			return _engine.GetTemplate(viewPath);
		}
		#endregion

		
		#region ViewLocator
		IViewLocator _viewLocator = null;
		public IViewLocator ViewLocator {
			get {
				if (this._viewLocator == null) {
					this._viewLocator = new NVelocityViewLocator();
				}
				return this._viewLocator;
			}
			set {
				this._viewLocator = value;
			}
		}
		#endregion
	}
}
