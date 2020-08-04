using System.Data;
using System.Diagnostics;

namespace RealcommerceBLL
{
	public class City
	{
		private string _cityLocalizedName;
		private string _cityCountryLocalizedName;
		private string _cityAdministrativeAreaLocalizedName;
		private string _cityKey;

		public string cityLocalizedName
		{
			get { return _cityLocalizedName; }
			set { _cityLocalizedName = value; }
		}

		public string cityCountryLocalizedName
		{
			get { return _cityCountryLocalizedName; }
			set { _cityCountryLocalizedName = value; }
		}

		public string cityAdministrativeAreaLocalizedName
		{
			get { return _cityAdministrativeAreaLocalizedName; }
			set { _cityAdministrativeAreaLocalizedName = value; }
		}

		public string cityKey
		{
			get { return _cityKey; }
			set { _cityKey = value; }
		}

		public static City ToObject(DataRow reader)
		{
			City city = new City();
			city.cityKey = reader[0].ToString();
			city.cityLocalizedName = reader[1].ToString();
			city.cityCountryLocalizedName = reader[2].ToString();
			city.cityAdministrativeAreaLocalizedName = reader[3].ToString();

			Debug.WriteLine("city:" + city.ToString());
			return city;
		}
	}
}