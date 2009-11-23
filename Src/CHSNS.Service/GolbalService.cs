using CHSNS.Model;
using CHSNS.Operator;

namespace CHSNS.Service {
	using System.Collections.Generic;
	using System.Linq;
	public class GolbalService {
        static readonly GolbalService _instance = new GolbalService();
        private readonly IGolbalOperator Golbal;
        public GolbalService() {
            Golbal = new GolbalOperator();
        }

        public static GolbalService GetInstance() {
            return _instance;
        }
		/// <summary>
		/// Get ALL Provinces or Areas
		/// </summary>
		public List<Province> Provinces(IContext context) {
            return Golbal.Provinces(context);
		}
		/// <summary>
		/// Get Citys in the Cache has the Province ID
		/// </summary>
		/// <param name="context"></param>
		/// <param name="provinceID"></param>
		/// <returns></returns>
		public List<City> GetCitys(IContext context,int provinceID) {
		    return Golbal.GetCitys(context, provinceID);
		}
	}
}
