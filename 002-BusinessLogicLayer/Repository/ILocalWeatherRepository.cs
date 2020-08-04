using System.Collections.Generic;

namespace RealcommerceBLL
{
	public interface ILocalWeatherRepository
	{
		List<Weather> GetAllWeather();
		Weather GetWeather(string key);
		Weather AddWeather(Weather weather);
		Weather UpdateWeather(Weather weather);
		int DeleteWeather(string key);
	}
}