﻿using System;
using CHSNS.ModelPas;
namespace CHSNS.Data {
	public interface IAccountMediator {
		bool Create(AccountPas account, string name);
		bool IsUsernameCanUse(string username);
		int Login(string Username, string Password, bool IsAutoLogin, bool IsPasswordMd5);
		void Logout();
	}
}