using System.Collections.Generic;
using CHSNS.Model;

namespace CHSNS.Operator
{
	public interface IGolbalOperator
	{
		List<Province> Provinces { get; }
		List<City> GetCitys(int ProvinceID);
	}
}