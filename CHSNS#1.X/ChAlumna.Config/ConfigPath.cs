namespace ChAlumna.Config
{
	public class ConfigPath
	{
		/// <summary>
		/// SiteConfig.config
		/// </summary>
		public string SiteConfig {
			get {
				return GetConfigFile("SiteConfig");
			}
		}

		/// <summary>
		/// Routing.config
		/// </summary>
		public string Routing {
			get {
				return GetConfigFile("Routing");
			}
		}
		/// <summary>
		/// SmtpConfig,config
		/// </summary>
		public string SmtpConfig {
			get {
				return GetConfigFile("SmtpConfig");
			}
		}
		string GetConfigFile(string name) {
			
			return System.Web.HttpContext.Current.Server.MapPath(
						string.Format("~/{0}/Config/{1}.config",
						SystemConfig.Currect.Path,
						name
					)
				);
		}
	}
}
