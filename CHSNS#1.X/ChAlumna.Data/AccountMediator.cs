using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CHSNS.Data {
	public class AccountMediator : BaseMediator {
		public AccountMediator(DBExt id) : base(id) { }
		public void Logout() {
			ChCookies.Clear();
			CHUser.Clear();
		}
		public Int16 Login(String Username, String Password, Boolean IsAutoLogin, Boolean IsPasswordMd5) {
			Encrypt en = new Encrypt();
			string md5pwd = IsPasswordMd5 ? en.MD5Encrypt(Password.Trim(), 32) : Password.Trim();
			Dictionary dict = new Dictionary();
			dict.Add(
				Username.Contains("@") ? "@Username" : "@Userid",
				Username.Trim()
			);
			dict.Add("@Password", md5pwd);
			DataRowCollection rets = DataBaseExecutor.GetRows("[Login]", dict);
			Int16 retint = -999;
			if (rets.Count != 0 && !rets[0].IsNull("Status")) {
				Int16.TryParse(rets[0]["Status"].ToString(), out retint);
				if (retint > 0) {
					ChCookies cks = new ChCookies();
					cks.SaveAll(rets[0]["Userid"].ToString(),
						rets[0]["Username"].ToString(),
						md5pwd,
						retint,
						IsAutoLogin
						);
				}
			}
			return retint;
		}
	}
}
