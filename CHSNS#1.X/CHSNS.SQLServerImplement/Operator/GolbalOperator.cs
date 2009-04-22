using CHSNS.Model;

namespace CHSNS.Operator {
    using System.Collections.Generic;
    using System.Linq;
    public class GolbalOperator : BaseOperator, IGolbalOperator {
        /// <summary>
        /// Get ALL Provinces or Areas
        /// </summary>
        public List<Province> Provinces(IContext context) {

            var c = new ConfigSerializer(context);
            return c.Load<List<Province>>("Province");

        }
        /// <summary>
        /// Get Citys in the Cache has the Province ID
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        public List<City> GetCitys(IContext context, int ProvinceID) {
            var c = new ConfigSerializer(context);
            var Citys = c.Load<List<City>>("City");
            return Citys.Where(x => x.PID == ProvinceID).ToList();
        }
    }
}
