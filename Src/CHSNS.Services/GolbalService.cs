namespace CHSNS.Service
{
    using System.Linq;
    using CHSNS.Model;
    using System.Collections.Generic;
    
    using Models;

   
    public class GolbalService
    {
        /// <summary>
        /// Get ALL Provinces or Areas
        /// </summary>
        public static List<Province> Provinces
        {
            get { return ConfigSerializer.Instance.Load<List<Province>>("Province"); }
        }

        /// <summary>
        /// Get Citys in the Cache has the Province ID
        /// </summary>
        /// <param name="provinceId"></param>
        /// <returns></returns>
        public static List<City> GetCitys(int provinceId)
        {
            var citys = ConfigSerializer.Instance.Load<List<City>>("City");
            return citys.Where(x => x.ParentId == provinceId).ToList();
        }
    }
}
