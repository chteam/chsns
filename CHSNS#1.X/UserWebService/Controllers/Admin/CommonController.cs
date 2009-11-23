
namespace CHSNS.Controllers.Admin
{using CHSNS.Config;
	using System.Web.Mvc;
	
	public class CommonController : BaseAdminController
	{
		public ActionResult Config() {
			BaseConfig chsite = null ;
			if (this.IsPost) {
				BindingHelperExtensions.UpdateFrom(chsite, Request.Form, "chsite.");
				chsite.StyleList = SiteConfig.Current.BaseConfig.StyleList;
				SiteConfig.Current.BaseConfig = chsite;
				SiteConfig.Current.Save();
				TempData.Add("msg", "成功更改");
				return this.RedirectToReferrer();
			} else {
				chsite = SiteConfig.Current.BaseConfig;
			}
			ViewData.Add("chsite", chsite);
			return View();

		}
		public ActionResult Regandvisit( ) {
			RegVisitConfig data=null;
			if (this.IsPost) {
				BindingHelperExtensions.UpdateFrom(data, Request.Form, "data.");
				SiteConfig.Current.RegVisitConfig = data;
				SiteConfig.Current.Save();
				TempData.Add("msg", "成功更改");
				return this.RedirectToReferrer();
			} else {
				data = SiteConfig.Current.RegVisitConfig;
			}
			ViewData.Add("data", data);
			return View();
		}
		public ActionResult Publish() {
			Publish data = null;
			if (this.IsPost) {
				BindingHelperExtensions.UpdateFrom(data, Request.Form, "data.");
				SiteConfig.Current.Publish = data;
				SiteConfig.Current.Save();
				TempData.Add("msg", "成功更改");
				return this.RedirectToReferrer();
				
			} else {
				data = SiteConfig.Current.Publish;
			}
			ViewData.Add("data", data);
			return View();
		}
		#region Style
		public ActionResult AddStyle(string style) {
			if (this.IsPost) {
				SiteConfig.Current.BaseConfig.StyleList += string.Format("{0}|", style);
				SiteConfig.Current.Save();
				TempData.Add("msg", "成功更改");
				return this.RedirectToReferrer();
			}
			return View();
		}
		#endregion
	}
}
