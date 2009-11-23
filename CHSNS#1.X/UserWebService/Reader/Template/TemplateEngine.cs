
	using System;
	using System.IO;
	using CHSNS;
namespace CHSNS.Template {
	public class TemplateEngine
	{
		static public string ToString(Dictionary dict, string view) {
			NVelocityTemplateEngine engine = new NVelocityTemplateEngine();
			engine.TemplateDir = Castle.MonoRail.Framework.Configuration.MonoRailConfiguration.GetConfig()
				.ViewEngineConfig.ViewPathRoot;
			engine.BeginInit();
			StringWriter writer = new StringWriter();
			engine.Process(dict, view, writer);
			return writer.GetStringBuilder().ToString();
		}
	}
}
