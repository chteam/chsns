using System.Collections.Generic;
using CHSNS.Model;

namespace CHSNS.Operator
{
	public interface IGolbalOperator
	{
	    List<Province> Provinces(IContext context);
		List<City> GetCitys(IContext context,int ProvinceID);
	}
}