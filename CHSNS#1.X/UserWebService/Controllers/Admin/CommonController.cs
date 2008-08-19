
namespace ChAlumna.Controllers.Admin
{using ChAlumna.Config;
	using Castle.MonoRail.Framework;
	public class CommonController : BaseAdminController
	{
		public void config([DataBind("chsite")] BaseConfig chsite) {
			if (this.IsPost) {
				chsite.StyleList = SiteConfig.Currect.BaseConfig.StyleList;
				SiteConfig.Currect.BaseConfig = chsite;
				SiteConfig.Currect.Save();
				Flash.Now("msg", "成功更改");
				RedirectToReferrer();
			} else {
				chsite = SiteConfig.Currect.BaseConfig;
			}
			ViewData.Add("chsite", chsite);
		

		}
		public void regandvisit([DataBind("data")] RegVisitConfig data) {
			if (this.IsPost) {
				SiteConfig.Currect.RegVisitConfig = data;
				SiteConfig.Currect.Save();
				Flash.Now("msg", "成功更改");
				RedirectToReferrer();
			} else {
				data = SiteConfig.Currect.RegVisitConfig;
			}
			ViewData.Add("data", data);
		}
		public void publish([DataBind("data")] Publish data) {
			if (this.IsPost) {
				SiteConfig.Currect.Publish = data;
				SiteConfig.Currect.Save();
				Flash.Now("msg", "成功更改");
				RedirectToReferrer();
				
			} else {
				data = SiteConfig.Currect.Publish;
			}
			ViewData.Add("data", data);
		}
		#region Style
		public void addstyle(string style) {
			if (this.IsPost) {
				SiteConfig.Currect.BaseConfig.StyleList += string.Format("{0}|", style);
				SiteConfig.Currect.Save();
				Flash.Now("msg", "成功更改");
				RedirectToReferrer();
			}
		}
		#endregion
	}
}
