using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealcommerceBLL
{
	public interface IApiWeatherRepository
	{
		Task<List<City>> GetCityCode(string city);
		Task<Weather> GetCityWeather(string key);
	}
}