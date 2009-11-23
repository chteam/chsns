	using System.Linq;
	using System;
	using System.Collections;
	using CHSNS.Extension;
	using CHSNS.Models;
using CHSNS;
	namespace CHSNS.Controllers.Admin
{

	public class FieldController : BaseAdminController 
	{

		#region field-school
		public void Field_index() {
			ViewData.Add("provinces", DataSetCache.ProvinceOptionList());
			long pid = this.QueryLong("pid");
	
			if (pid == 0)
				pid = 247102;
			ViewData["pid"] = pid;
			var fs = (from _f in DB.Field
					  where _f.PID == pid
					  orderby _f.IsTrue, _f.Class
					  select _f).ToList();
			ViewData["fs"] = fs;
		}
		public void Field_AddMini(Int64 uniid, String xueyuans) {
			if (IsPost) {
				IList list = xueyuans.Split('\n');
				DoField f = new DoField();
				TempData["msg"] = f.AddMiniField(uniid, list, 0);
			}
			ViewData.Add("provinces", DataSetCache.ProvinceOptionList());
		}
		public void Field_AddQinshi(Int64 uniid, String qinshis) {
			if (IsPost) {
				IList list = qinshis.Split('\n');
				DoField school = new DoField();
				TempData["msg"] = school.AddQinshi(uniid, list);

			}
			ViewData.Add("provinces", DataSetCache.ProvinceOptionList());
		}
		#endregion
	}
}
