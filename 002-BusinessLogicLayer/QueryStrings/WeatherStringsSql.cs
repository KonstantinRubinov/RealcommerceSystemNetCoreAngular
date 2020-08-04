using System.Data.SqlClient;

namespace RealcommerceBLL
{
	static public class WeatherStringsSql
	{
		static private string queryWeatherString = "SELECT weatherKey, weatherText, weatherValue, weatherEpochTime from Weather";
		static private string queryWeatherByIdString = "SELECT weatherKey, weatherText, weatherValue, weatherEpochTime from Weather where weatherKey=@weatherKey";
		static private string queryWeatherPost = "INSERT INTO Weather (weatherKey, weatherText, weatherValue, weatherEpochTime) VALUES (@weatherKey, @weatherText, @weatherValue, @weatherEpochTime); SELECT weatherKey, weatherText, weatherValue, weatherEpochTime FROM Weather WHERE weatherKey = @weatherKey;";
		static private string queryWeatherUpdate = "UPDATE Weather SET weatherText = @weatherText, weatherValue = @weatherValue, weatherEpochTime = @weatherEpochTime WHERE weatherKey = @weatherKey; SELECT weatherKey, weatherText, weatherValue, weatherEpochTime FROM Weather WHERE weatherKey = @weatherKey;";
		static private string queryWeatherDelete = "DELETE FROM Weather WHERE weatherKey=@weatherKey";

		static public SqlCommand GetAllWeather()
		{
			return CreateSqlCommand(queryWeatherString);
		}

		static public SqlCommand GetWeather(string key)
		{
			return CreateSqlCommand(key, queryWeatherByIdString);
		}

		static public SqlCommand AddWeather(Weather weather)
		{
			return CreateSqlCommand(weather, queryWeatherPost);
		}

		static public SqlCommand UpdateWeather(Weather weather)
		{
			return CreateSqlCommand(weather, queryWeatherUpdate);
		}

		static public SqlCommand DeleteWeather(string Key)
		{
			return CreateSqlCommand(Key, queryWeatherDelete);
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);
			return command;
		}

		static private SqlCommand CreateSqlCommand(Weather weather, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);
			command.Parameters.AddWithValue("@weatherKey", weather.weatherKey);
			command.Parameters.AddWithValue("@weatherText", weather.weatherText);
			command.Parameters.AddWithValue("@weatherValue", weather.weatherValue);
			command.Parameters.AddWithValue("@weatherEpochTime", weather.weatherEpochTime);
			return command;
		}

		static private SqlCommand CreateSqlCommand(string Key, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);
			command.Parameters.AddWithValue("@weatherKey", Key);
			return command;
		}
	}
}