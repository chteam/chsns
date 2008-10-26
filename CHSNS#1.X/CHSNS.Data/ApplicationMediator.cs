﻿

using System;

namespace CHSNS.Data {
	using System.Collections.Generic;
	using System.Linq;

	using System.Web;
	using Models;
	public class ApplicationMediator : BaseMediator, CHSNS.Data.IApplicationMediator {
		private const string APPLISTALL = "APPLISTALL";
		public ApplicationMediator(DBExt id) : base(id) { }
		/// <summary>
		/// 缓存的应用列表
		/// </summary>
		public IList<Application> Applications {
			get {
				if (HttpContext.Current.Application[APPLISTALL] == null) {
					HttpContext.Current.Application.Lock();
					HttpContext.Current.Application[APPLISTALL] = DBExt.DB.Application.ToList();
					HttpContext.Current.Application.UnLock();
				}
				return HttpContext.Current.Application[APPLISTALL] as IList<Application>;
			}
		}

		public IList<Application> GetApps(long[] ids)
		{
			if (ids.Length == 0)
				return Applications.Where(c => c.IsSystem).ToList();
			return Applications.Where(c => ids.Contains(c.ID)).ToList();
		}
	}
}
