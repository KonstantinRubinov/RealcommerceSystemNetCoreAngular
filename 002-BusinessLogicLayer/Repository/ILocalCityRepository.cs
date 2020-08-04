using System.Collections.Generic;

namespace RealcommerceBLL
{
	public interface ILocalCityRepository
	{
		List<City> GetAllCities();
		City GetCity(string key);
		City AddCity(City city);
		int DeleteCity(string key);
	}
}