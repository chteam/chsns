using CHSNS.Model;
using CHSNS.Operator;
using System.Collections.Generic;

namespace CHSNS.Service {

	public class GolbalService {
        static readonly GolbalService Instance = new GolbalService();
        private readonly IGolbalOperator _golbal;
        public GolbalService() {
            _golbal = new GolbalOperator();
        }

        public static GolbalService GetInstance() {
            return Instance;
        }
		/// <summary>
		/// Get ALL Provinces or Areas
		/// </summary>
		public List<Province> Provinces(IContext context) {
            return _golbal.Provinces(context);
		}
		/// <summary>
		/// Get Citys in the Cache has the Province ID
		/// </summary>
		/// <param name="context"></param>
		/// <param name="provinceId"></param>
		/// <returns></returns>
		public List<City> GetCitys(IContext context,int provinceId) {
		    return _golbal.GetCitys(context, provinceId);
		}
	}
}
