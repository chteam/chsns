using System.Collections.Generic;
using CHSNS.ModelPas;

namespace CHSNS.Data
{
	public interface IGolbalMediator
	{
		List<Province> Provinces { get; }
		List<City> GetCitys(int ProvinceID);
	}
}