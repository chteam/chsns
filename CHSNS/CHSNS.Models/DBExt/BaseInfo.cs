using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.Models {
	public partial class DBExt {
		static public BaseInfo BaseInfo(long userid){
			CHSNSDataContext DB = new CHSNSDataContext();
			BaseInfo bi = DB.BaseInfo.Where(q => q.UserID == userid).SingleOrDefault();
			if (bi == null) {
				bi = new BaseInfo() {
					Birthday = DateTime.Now,
					CityID = 0,
					ProvinceID = 0,
					Name = "",
					Sex = false,
					UserID = userid
				};
			}
			return bi;
		}
	}
}
