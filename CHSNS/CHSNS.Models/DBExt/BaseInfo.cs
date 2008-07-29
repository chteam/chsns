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
				MsSqlDB mdb = new MsSqlDB();
				mdb.SqlExecute("insert into BaseInfo(userid) values(@ui)", "ui", userid);
			}
			return bi;
		}
		static public void BaseInfo_Save(BaseInfo bi) {
			MsSqlDB db = new MsSqlDB();
			db.SqlExecute(@"update BaseInfo 
set [name]=@name,[sex]=@sex,provinceid=@provinceid,cityid=@cityid,birthday=@birthday
where userid=@userid",
				"name", bi.Name,
			"Sex", bi.Sex,
			"ProvinceID", bi.ProvinceID,
			"CityID", bi.CityID,
			"Birthday", bi.Birthday,
			"UserID", bi.UserID
			);
		}

	}
}
