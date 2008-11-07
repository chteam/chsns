namespace CHSNS.Data {
	using System.Collections.Generic;
	using System.Linq;
	using Models;
	public class GolbalMediator : BaseMediator, IGolbalMediator {
		public GolbalMediator(IDBExt id) : base(id) { }
		private const string CACHE_PROVINCES = "area.provinceall";
		private const string CACHE_CITYS = "area.cityall";

		/// <summary>
		/// Get ALL Provinces or Areas
		/// </summary>
		public List<Province> Provinces {
			get {
				if (!CHCache.Contains(CACHE_PROVINCES)) {
					CHCache.Add(CACHE_PROVINCES, DBExt.DB.Province.ToList());
				}
				return CHCache.Get<List<Province>>(CACHE_PROVINCES);
			}
		}
		/// <summary>
		/// Get Citys in the Cache has the Province ID
		/// </summary>
		/// <param name="ProvinceID"></param>
		/// <returns></returns>
		public List<City> GetCitys(int ProvinceID) {
			return Citys.Where(x => x.PID == ProvinceID).ToList();
		}

		List<City> Citys {
			get {
				if (!CHCache.Contains(CACHE_CITYS)) {
					CHCache.Add(CACHE_CITYS, DBExt.DB.City.ToList());
				}
				return CHCache.Get<List<City>>(CACHE_CITYS);
			}
		}
	}
}
