using RealcommerceDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RealcommerceBLL
{
	public class LocalCityManager : SqlDataBase, ILocalCityRepository
	{
		public List<City> GetAllCities()
		{
			DataTable dt = new DataTable();
			List<City> arrCity = new List<City>();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(CityStringsSql.GetAllCities());
			}

			foreach (DataRow ms in dt.Rows)
			{
				arrCity.Add(City.ToObject(ms));
			}

			return arrCity;
		}

		public City GetCity(string key)
		{
			if (key.Equals(string.Empty) || key.Equals(""))
				throw new ArgumentOutOfRangeException();

			DataTable dt = new DataTable();
			City city = new City();


			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(CityStringsSql.GetCity(key));
			}

			foreach (DataRow ms in dt.Rows)
			{
				city = City.ToObject(ms);
			}

			return city;
		}

		public City AddCity(City city)
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(CityStringsSql.AddCity(city));
			}
			foreach (DataRow ms in dt.Rows)
			{
				city = City.ToObject(ms);
			}

			return city;
		}

		public int DeleteCity(string key)
		{
			if (key.Equals(string.Empty) || key.Equals(""))
				throw new ArgumentOutOfRangeException();

			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(CityStringsSql.DeleteCity(key));
			}
			return i;
		}
	}
}