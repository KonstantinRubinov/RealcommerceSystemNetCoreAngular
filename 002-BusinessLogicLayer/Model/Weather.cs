using System.Data;
using System.Diagnostics;

namespace RealcommerceBLL
{
	public class Weather
	{
		private string _weatherKey;
		private string _weatherText;
		private string _weatherValue;
		private long _weatherEpochTime;

		public string weatherKey
		{
			get { return _weatherKey; }
			set { _weatherKey = value; }
		}

		public string weatherText
		{
			get { return _weatherText; }
			set { _weatherText = value; }
		}

		public string weatherValue
		{
			get { return _weatherValue; }
			set { _weatherValue = value; }
		}

		public long weatherEpochTime
		{
			get { return _weatherEpochTime; }
			set { _weatherEpochTime = value; }
		}

		public static Weather ToObject(DataRow reader)
		{
			Weather weather = new Weather();
			weather.weatherKey = reader[0].ToString();
			weather.weatherText = reader[1].ToString();
			weather.weatherValue = reader[2].ToString();
			weather.weatherEpochTime = long.Parse(reader[3].ToString());

			Debug.WriteLine("weather:" + weather.ToString());
			return weather;
		}
	}
}