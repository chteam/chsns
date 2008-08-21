using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using NVelocity;

namespace CHSNS.NVelocityEngine
{
	/// <summary>
	/// NVelocity的ViewPage
	/// 
	/// </summary>
	public class NVelocityView : IViewDataContainer
	{
		private readonly ViewContext _viewContext;
		private readonly Template _masterTemplate;
		private readonly Template _viewTemplate;

		public NVelocityView(Template viewTemplate, Template masterTemplate, ViewContext viewContext)
		{
			_viewTemplate = viewTemplate;
			_masterTemplate = masterTemplate;
			_viewContext = viewContext;
		}

		public Template ViewTemplate
		{
			get { return _viewTemplate; }
		}

		public Template MasterTemplate
		{
			get { return _masterTemplate; }
		}

		public ViewDataDictionary ViewData
		{
			get { return _viewContext.ViewData; }
			set { throw new NotSupportedException(); }
		}

		public void RenderView()
		{
			bool hasLayout = _masterTemplate != null;
			TextWriter writer = hasLayout ? new StringWriter() : _viewContext.HttpContext.Response.Output;

			VelocityContext context = CreateContext(_viewContext);

			_viewTemplate.Merge(context, writer);

			if(hasLayout)
			{
				context.Put("childContent", (writer as StringWriter).GetStringBuilder().ToString());

				_masterTemplate.Merge(context, _viewContext.HttpContext.Response.Output);
			}
		}

		private VelocityContext CreateContext(ViewContext context)
		{
			Hashtable entries = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
			//常值
			object[] builtInHelpers = new object[]{
						new StaticAccessorHelper<Byte>(),
						new StaticAccessorHelper<SByte>(),
						new StaticAccessorHelper<Int16>(),
						new StaticAccessorHelper<Int32>(),
						new StaticAccessorHelper<Int64>(),
						new StaticAccessorHelper<UInt16>(),
						new StaticAccessorHelper<UInt32>(),
						new StaticAccessorHelper<UInt64>(),
						new StaticAccessorHelper<Single>(),
						new StaticAccessorHelper<Double>(),
						new StaticAccessorHelper<Boolean>(),
						new StaticAccessorHelper<Char>(),
						new StaticAccessorHelper<Decimal>(),
						new StaticAccessorHelper<String>(),
						new StaticAccessorHelper<Guid>(),
						new StaticAccessorHelper<DateTime>()
					};

			foreach (object helper in builtInHelpers) {
				entries[helper.GetType().GetGenericArguments()[0].Name] = helper;
			}
			CreateAndAddHelpers(entries, context);
			//变值
			if (context.ViewData != null)
			{
				foreach(var pair in context.ViewData)
				{
					entries[pair.Key] = pair.Value;
				}
			}
			entries["viewdata"] = _viewContext.ViewData;
			entries["tempdata"] = _viewContext.TempData;
			entries["routedata"] = context.RouteData;
			entries["controller"] = _viewContext.Controller;
			entries["httpcontext"] = _viewContext.HttpContext;
			entries["viewcontext"] = _viewContext;
			foreach (String key in _viewContext.HttpContext.Request.QueryString.AllKeys) {
				if (key == null) continue;
				object value = _viewContext.HttpContext.Request.QueryString[key];
				if (value == null) continue;
				entries[key] = value;
			}
			foreach (String key in _viewContext.HttpContext.Request.Form.AllKeys) {
				if (key == null) continue;
				object value = _viewContext.HttpContext.Request.Form[key];
				if (value == null) continue;
				entries[key] = value;
			}
			entries["page"] = entries;
			

			return new VelocityContext(entries);
		}

		private void CreateAndAddHelpers(Hashtable entries, ViewContext context)
		{
			//var html = ;
			entries["html"] = entries["htmlhelper"] = new HtmlHelperAdapter(context, this);
			entries["url"] = entries["urlhelper"] = new UrlHelper(context);
			entries["ajax"] = entries["ajaxhelper"] = new AjaxHelper(context);
		}
	}
}