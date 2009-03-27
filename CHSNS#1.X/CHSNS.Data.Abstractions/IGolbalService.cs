using System.Collections.Generic;
using CHSNS.Model;

namespace CHSNS.Service
{
	public interface IGolbalService
	{
		List<Province> Provinces { get; }
		List<City> GetCitys(int ProvinceID);
	}
}