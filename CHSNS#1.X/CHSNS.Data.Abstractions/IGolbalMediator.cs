using System;
namespace CHSNS.Data {
	public interface IGolbalMediator {
		System.Collections.Generic.List<CHSNS.Models.City> GetCitys(int ProvinceID);
		System.Collections.Generic.List<CHSNS.Models.Province> Provinces { get; }
	}
}
