namespace CHSNS.Service {
    using System.Linq;
    using CHSNS.Model;
    using CHSNS.Operator;
    using System.Collections.Generic;

    public class GolbalService {

         public ISerializer Serializer { get;  set; }
         public GolbalService(IContext context)
         {
             Serializer = new ConfigSerializer(context);
         }

        /// <summary>
        /// Get ALL Provinces or Areas
        /// </summary>
        public List<Province> Provinces
        {
            get { return Serializer.Load<List<Province>>("Province"); }
        }

        /// <summary>
        /// Get Citys in the Cache has the Province ID
        /// </summary>
        /// <param name="provinceId"></param>
        /// <returns></returns>
        public List<City> GetCitys(int provinceId)
        {
            var citys = Serializer.Load<List<City>>("City");
            return citys.Where(x => x.PId == provinceId).ToList();
        }
    }
}
