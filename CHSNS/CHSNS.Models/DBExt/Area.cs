using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.Models {
	public partial class DBExt {
		static string CACHE_PROVINCES = "area.provinceall";
		static string CACHE_CITYS = "area.cityall";

		/// <summary>
		/// Get ALL Provinces or Areas
		/// </summary>
		static public List<Province> Provinces{
			get{
				if (!CHCache.Contains(CACHE_PROVINCES)) {
					CHSNSDataContext DB = new CHSNSDataContext();
					CHCache.Add(CACHE_PROVINCES, DB.Province.ToList<Province>());
				}
				return CHCache.Get<List<Province>>(CACHE_PROVINCES);
			}
		}
		/// <summary>
		/// Get Citys in the Cache has the Province ID
		/// </summary>
		/// <param name="ProvinceID"></param>
		/// <returns></returns>
		public static List<City> GetCitys(int ProvinceID){
			return DBExt.Citys.Where(x => x.ProvinceID == ProvinceID).ToList<City>();
		}

		static List<City> Citys{
			get {
				if (!CHCache.Contains(CACHE_CITYS)) {
					CHSNSDataContext DB = new CHSNSDataContext();
					CHCache.Add(CACHE_CITYS, DB.City.ToList<City>());
				}
				return CHCache.Get<List<City>>(CACHE_CITYS);
			}
		}
	}
}
