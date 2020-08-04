using RealcommerceDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RealcommerceBLL
{
	public class LocalWeatherManager : SqlDataBase, ILocalWeatherRepository
	{
		public List<Weather> GetAllWeather()
		{
			DataTable dt = new DataTable();
			List<Weather> arrWeather = new List<Weather>();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(WeatherStringsSql.GetAllWeather());
			}

			foreach (DataRow ms in dt.Rows)
			{
				arrWeather.Add(Weather.ToObject(ms));
			}

			return arrWeather;
		}

		public Weather GetWeather(string key)
		{
			if (key.Equals(string.Empty) || key.Equals(""))
				throw new ArgumentOutOfRangeException();

			DataTable dt = new DataTable();
			Weather weather = new Weather();


			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(WeatherStringsSql.GetWeather(key));
			}

			foreach (DataRow ms in dt.Rows)
			{
				weather = Weather.ToObject(ms);
			}

			return weather;
		}

		public Weather AddWeather(Weather weather)
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(WeatherStringsSql.AddWeather(weather));
			}
			foreach (DataRow ms in dt.Rows)
			{
				weather = Weather.ToObject(ms);
			}

			return weather;
		}

		public Weather UpdateWeather(Weather weather)
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(WeatherStringsSql.UpdateWeather(weather));
			}
			foreach (DataRow ms in dt.Rows)
			{
				weather = Weather.ToObject(ms);
			}

			return weather;
		}

		public int DeleteWeather(string key)
		{
			if (key.Equals(string.Empty) || key.Equals(""))
				throw new ArgumentOutOfRangeException();

			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(WeatherStringsSql.DeleteWeather(key));
			}
			return i;
		}
	}
}