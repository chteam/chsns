

namespace ChAlumna.Controllers {
	using ChAlumna.Models;
	using Castle.MonoRail.Framework;
	using Chsword;
	using System.Collections;
	using System;
	using System.Linq;
	using ChAlumna.Config;
	using System.Transactions;
	using System.Data;
	[Filter(ExecuteEnum.BeforeAction, typeof(PublicFilter))]
	[DynamicActionProvider(typeof(WizardActionProvider))]
	public class RegController : BaseController, IWizardController
	{
		#region IWizardController 成员
		/// <summary>
		/// 定义一个组
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public WizardStepPage[] GetSteps(IRailsEngineContext context) {
			return new WizardStepPage[] {
				new AgreementStep(), 
				new StartStep(), 
				new FieldStep(), 
				new ConfirmStep(), 
				new DoneStep()
			};
		}

		public void OnAfterStep(string wizardName, string stepName, WizardStepPage step) { }

		public bool OnBeforeStep(string wizardName, string stepName, WizardStepPage step) {
			return true;
		}

		public void OnWizardStart() {

		}
		#endregion
		//重新发送验证码
		public void resend() {

		}
		[AccessibleThrough(Verb.Post)]
		public void send([DataBind("account")] Account account) {
			if (!SiteConfig.Currect.RegVisitConfig.IsAllowReg) {
				Flash["errors"] = "不允许注册";
				return;
			}
			Encrypt en = new Encrypt();
			Account[] l = (from a in DB.Account
						   where a.email == account.email
						   && a.password == en.MD5Encrypt(account.password, 32)
						   && a.status == (int)UserStatusType.Start
						   select a).ToArray();
			//	Account[] accounts = Account.FindAllByProperty("email", account.email);
			if (l.Length == 1) {
				account = l[0];
				Email.SystemSend("您的注册验证信息",
					String.Format(ChCache.GetConfig("Email", "verify"),
					SiteConfig.Currect.BaseConfig.Title,
					SiteConfig.Currect.BaseConfig.Url,
					account.email,
					account.userid,
					account.code
					),
					account.email,
					account.name
					);
				Flash["errors"] = "发送成功";
				RedirectToReferrer();
				return;
			}
			Flash["errors"] = "您的用户名或密码不正确";
			Flash["account"] = account;
			RedirectToReferrer();
			return;
		}
		/// <summary>
		/// 验证页面
		/// </summary>
		public void verify() {
			if (!verifyCode(Params["userid"], Params["code"], Session)) {
				Flash["errors"] = "您已经通过审核了，或还未注册账号";
			} else {
				Redirect("/reg/DoneStep.ashx");
			}
		}
		public static bool verifyCode(string userids, string codes, IDictionary Session) {
			long userid;
			long code;
			if (Int64.TryParse(userids, out userid) && Int64.TryParse(codes, out code)) {
				using (ChAlumnaDBDataContext Db = new ChAlumnaDBDataContext(SiteConfig.SiteConnectionString)) {
					Account[] accounts = (from a in Db.Account
										  where a.userid == userid
								   && a.code == code
								   && a.status == (int)UserStatusType.Start
										  select a).ToArray();
					if (accounts.Length >= 1) {
						Account account = accounts.First();
						account.status = (int)UserStatusType.Field;
						Db.SubmitChanges();
						
						//account.Update();
						string[] reginfo ={
							account.userid.ToString(),//0
							account.name,//1
							account.email,//2
							account.code.ToString()//3
							};
						Session["reginfo"] = reginfo;
						return true;
					}
				}
			}
			return false;
		}
	}
	public class AgreementStep : BaseWizardPage {}
	public class StartStep : BaseWizardPage {
		protected override void Reset() {
		//	Session.Remove("account");
		}
		public void Save([DataBind("account")] Account accountForm, [DataBind("profile")] Profile profile) {
			Session.Remove("account");

			if (!SiteConfig.Currect.RegVisitConfig.IsAllowReg) {
				Flash["errors"] = "网站已经关闭注册";
				RedirectToStep("StartStep");
				return;
			}

			if (HasValidationError(accountForm)) {
				Flash["errors"] = GetErrorSummary(accountForm);
				RedirectToStep("StartStep");
				return;
			}
			if ((from a in DB.Account
				 where a.email == accountForm.email
				 select 1).Count() != 0) {
				Flash["errors"] = "此用户名已经有人使用。";
				Flash["account"] = accountForm;
				RedirectToStep("StartStep");
				return;
			}
			Account account = RegSessionUtil.GetAccountFromSession(Session);
			Profile profile1 = RegSessionUtil.GetProfileFromSession(Session);
			profile1.field = profile.field;
			profile1.InField = true;
			Encrypt en = new Encrypt();

			account.name = accountForm.name;
			account.regtime = DateTime.Now;
			account.logintime = DateTime.Now;


			account.email = accountForm.email;
			account.trueemail = accountForm.email;
			account.password = en.MD5Encrypt(accountForm.password, 32);
			account.truepassword = account.password;

			account.question = account.question;
			account.answer = account.answer == null ? null : en.MD5Encrypt(account.answer, 32);

			DoNavigate();
		}
	}
	public class FieldStep : BaseWizardPage
	{
		protected override void RenderWizardView() {
			this.ViewData.Add("account", RegSessionUtil.GetAccountFromSession(Session));
			this.ViewData.Add("profile", RegSessionUtil.GetProfileFromSession(Session));
			this.ViewData.Add("provinces", DataSetCache.ProvinceOptionList());
			base.RenderWizardView();
		}
		public void Save([DataBind("FieldInformation")] FieldInformation sif) {
			Profile profile = RegSessionUtil.GetProfileFromSession(Session);
			//	if (profile.field == 1) {
			Account account = RegSessionUtil.GetAccountFromSession(Session);
			//using (TransactionScope ts = new TransactionScope()) {
			try {
				MsSqlExecutor mse = new MsSqlExecutor();
				DataRowCollection ret = mse.GetRows("Account_add",
					"@name", account.name,
					"@email", account.email,
					"@password", account.password,
					"@question", account.question,
					"@answer", account.answer
					);
				long userid = long.Parse(ret[0]["userid"].ToString());
				long code = long.Parse(ret[0]["code"].ToString());
				//object=0
				//	throw new Exception(account.userid.ToString());
				//profile
				profile.UserId = userid;
				profile.MagicBox = "";
				profile.CreateTime = DateTime.Now;
				profile.ShowTextTime = DateTime.Now;
				profile.FileSizeAll = 2097152;
				profile.FriendAll = 500;
				profile.MessageAll = 500;
				profile.AllShowLevel = (byte)ShowType.本站用户;


				DB.Profile.InsertOnSubmit(profile);
				//profile.Create();
				//base
				BasicInformation bif = new BasicInformation();

				bif.userid = userid;
				DB.BasicInformation.InsertOnSubmit(bif);
				//bif.Create();
				//school
				sif.userid = userid;

				DB.FieldInformation.InsertOnSubmit(sif);

				DB.SubmitChanges();
				if (SiteConfig.Currect.RegVisitConfig.IsEmailValidate) {
					string[] reginfo ={
									userid.ToString(),//0
									account.name,//1
									account.email,//2
									code.ToString()//3
								};
					Session.Add("reginfo", reginfo);
					Email.SystemSend("您的注册验证信息",
						String.Format(ChCache.GetConfig("Email", "verify"),
						SiteConfig.Currect.BaseConfig.Title,
						SiteConfig.Currect.BaseConfig.Url,
						account.email,
						userid,
						code
						),
						account.email,
						account.name
						);
				} else {
					RegController.verifyCode(userid.ToString(), code.ToString(), Session);
				}
				Session.Remove("account");
				DoNavigate();
			} catch (Exception e) {
				throw e;
			}

			//	} else {
			//throw new System.Exception("意外原因注册失败");
			//		DoNavigate();
			//	}
		}
	}
	public class ConfirmStep : BaseWizardPage {
		protected override void RenderWizardView() {
			if (SiteConfig.Currect.RegVisitConfig.IsEmailValidate) {
				//ViewData.Add("account", RegSessionUtil.GetAccountFromSession(Session));
				base.RenderWizardView();
			} else {
				RedirectToNextStep();
				return;
			}
		}
		public void Save(long code) {
			string[] a = (string[])Session["reginfo"];
			string userid = a[0];
			if (!RegController.verifyCode(a[0], code.ToString(), Session)) {
				Flash["errors"] = "验证码不正确";
				RedirectToReferrer();
			} else {
				RedirectToStep("DoneStep");
			}
		}
	}

	public class DoneStep : BaseWizardPage {
		protected override void RenderWizardView() {
			//ViewData.Add("account", RegSessionUtil.GetAccountFromSession(Session));
			base.RenderWizardView();
		}
	}
	class RegSessionUtil {
		internal static Account GetAccountFromSession(IDictionary session) {
			Account account = session["reg_account"] as Account;
			if (account == null) {
				account = new Account();
				session["reg_account"] = account;
			}
			return account;
		}
		internal static Profile GetProfileFromSession(IDictionary session) {
			Profile profile = session["reg_profile"] as Profile;
			if (profile == null) {
				profile = new Profile();
				session["reg_profile"] = profile;
			}
			return profile;
		}

		internal static string[] GetStringFromSession(IDictionary session) {
			string[] profile = session["reg_info"] as string[];
			if (profile == null) {
				//profile = new string[]();
				session["reg_info"] = profile;
			}
			return profile;
		}
	}
}
