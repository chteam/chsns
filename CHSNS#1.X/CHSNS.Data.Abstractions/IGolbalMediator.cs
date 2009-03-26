using System.Collections.Generic;
using CHSNS.ModelPas;

namespace CHSNS.Data
{
	public interface IGolbalService
	{
		List<Province> Provinces { get; }
		List<City> GetCitys(int ProvinceID);
	}
}