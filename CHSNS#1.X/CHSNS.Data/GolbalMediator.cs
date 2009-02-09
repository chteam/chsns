using CHSNS.ModelPas;

namespace CHSNS.Data {
	using System.Collections.Generic;
	using System.Linq;
	public class GolbalMediator : BaseMediator, IGolbalMediator {
		public GolbalMediator(IDBExt id) : base(id) { }
		/// <summary>
		/// Get ALL Provinces or Areas
		/// </summary>
		public List<Province> Provinces {
			get {
                ConfigSerializer c = new ConfigSerializer(DBExt.Context);
				return c.Load<List<Province>>("Province");
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
                ConfigSerializer c = new ConfigSerializer(DBExt.Context);
				return c.Load<List<City>>("City");
			}
		}
	}
}
