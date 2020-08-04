using RealcommerceDAL;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace RealcommerceBLL
{
	public class ApiWeatherManager : IApiWeatherRepository
	{
		public async Task<List<City>> GetCityCode(string city)
		{
			//http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=qiLiilQeNDyI0JIQukEn8VY3IcNuA8QR&q=Ashdod&language=en-us
			List<City> cities = new List<City>();
			JArray jdatas;
			string url = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=" + ConnectionStrings.GetApiKey() + "&q=" + city + "&language=" + "en-us";
			using (HttpClient client = new HttpClient())
			{
				string data = await client.GetStringAsync(url);
				jdatas = JArray.Parse(data);
			}
			foreach (JObject jdata in jdatas)
			{
				cities.Add(createDataCity(jdata));
			}
			return cities;
		}

		public async Task<Weather> GetCityWeather(string key)
		{
			// http://dataservice.accuweather.com/currentconditions/v1/215613?apikey=qiLiilQeNDyI0JIQukEn8VY3IcNuA8QR;
			Weather weather = new Weather();
			JArray jdatas;
			string url = "http://dataservice.accuweather.com/currentconditions/v1/" + key + "?apikey=" + ConnectionStrings.GetApiKey();
			using (HttpClient client = new HttpClient())
			{

				string data = await client.GetStringAsync(url);
				jdatas = JArray.Parse(data);
			}
			foreach (JObject jdata in jdatas)
			{
				weather = createDataCityWeather(jdata, key);
			}
			return weather;
		}

		private City createDataCity(JObject data)
		{
			City city = new City();

			try
			{
				city.cityLocalizedName = data.GetValue("LocalizedName").ToString();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("LocalizedName Exception: " + ex.Message);
				city.cityLocalizedName = "";
			}

			try
			{
				city.cityCountryLocalizedName = data["Country"]["LocalizedName"].ToString();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("CountryLocalizedName Exception: " + ex.Message);
				city.cityCountryLocalizedName = "";
			}

			try
			{
				city.cityAdministrativeAreaLocalizedName = data["AdministrativeArea"]["LocalizedName"].ToString();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("AdministrativeAreaLocalizedName Exception: " + ex.Message);
				city.cityAdministrativeAreaLocalizedName = "";
			}

			try
			{
				city.cityKey = data.GetValue("Key").ToString();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Key Exception: " + ex.Message);
				city.cityKey = "";
			}

			return city;
		}


		private Weather createDataCityWeather(JObject data, string key)
		{
			Weather weather = new Weather();

			try
			{
				weather.weatherKey = key;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Key Exception: " + ex.Message);
				weather.weatherKey = "";
			}

			try
			{
				weather.weatherText = data.GetValue("WeatherText").ToString();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("WeatherText Exception: " + ex.Message);
				weather.weatherText = "";
			}

			try
			{

				weather.weatherValue = data["Temperature"]["Metric"]["Value"].ToString();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("WeatherValue Exception: " + ex.Message);
				weather.weatherValue = "";
			}

			try
			{
				weather.weatherEpochTime = long.Parse(data.GetValue("EpochTime").ToString());
			}
			catch (Exception ex)
			{
				Debug.WriteLine("EpochTime Exception: " + ex.Message);
				weather.weatherEpochTime = -1;
			}

			return weather;
		}
	}
}